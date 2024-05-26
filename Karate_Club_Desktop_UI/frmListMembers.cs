using Karate_Club.Global_Classes;
using Karate_Club_Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace Karate_Club
{
    public partial class frmListMembers : Form
    {
        int _pageNumber = 0;
        private DataTable _dtMembers;

        public frmListMembers()
        {
            InitializeComponent();

            // Cusomize the appearance of the DataGridView
            clsUtilities.CustomizeDataGridView(dgvMembers);
        }

        private void _FillDataGridView(DataTable dtMembers)
        {
            if (dtMembers != null)
            {
                dgvMembers.DataSource = dtMembers;

                // Change the columns name
                dgvMembers.Columns["MemberID"].HeaderText = "Member ID";
                dgvMembers.Columns["PersonID"].HeaderText = "Person ID";
                dgvMembers.Columns["FullName"].HeaderText = "Full Name";
                dgvMembers.Columns["EmergencyContactName"].HeaderText = "E.C Name";
                dgvMembers.Columns["EmergencyContactPhone"].HeaderText = "E.C Phone";
                dgvMembers.Columns["EmergencyContactEmail"].HeaderText = "E.C Email";
                dgvMembers.Columns["CurrentBelt"].HeaderText = "Current Belt";

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvMembers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                lblTotalRecordsCount.Text = dtMembers.Rows.Count.ToString();
            }
        }

        private void _LoadRefreshMembersPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            _HandleNumberOfPages();

            // load members data per page and save them in the DataTable "_dtMembers"
            // in case the page number is equal to zero assign null to the DataTable "_dtMembers"
            _dtMembers = _pageNumber > 0 ? clsMember.GetMembersPerPage(_pageNumber, clsUtilities.RowsPerPage) : null;
            _FillDataGridView(_dtMembers);
        }

        private void _HandleNumberOfPages()
        {
            uint totalMembersCount = clsMember.GetTotalMemberCount();

            // Calculate the number of pages depending on "totalMembersCount"
            uint numberOfPages = totalMembersCount > 0 ? (uint)Math.Ceiling((double)totalMembersCount / clsUtilities.RowsPerPage) : 0;

            cbPage.Items.Clear();

            if (numberOfPages == 0)
            {
                cbPage.Items.Add(0);
                cbPage.Enabled = false;
            }
            else
            {
                for (int i = 1; i <= numberOfPages; i++)
                    cbPage.Items.Add(i);

                cbPage.Enabled = true;
            }

            // Select the first page to to load its data if any
            cbPage.SelectedIndex = 0;
            _pageNumber = int.TryParse(cbPage.Text, out int result) == true ? result : 0;
        }

        private void _Filter()
        {
            string filterColumn = string.Empty;
            string filterValue = txtFilterValue.Text.Trim();

            // Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "None":
                    filterColumn = "None";
                    break;
                case "Member ID":
                    filterColumn = "MemberID";
                    break;
                case "Person ID":
                    filterColumn = "PersonID";
                    break;
                case "Full Name":
                    filterColumn = "FullName";
                    break;
                case "Belt Rank":
                    filterColumn = "CurrentBelt";
                    break;
                case "Gender":
                    filterColumn = "Gender";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtMembers.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "MemberID" || filterColumn == "PersonID")
                    //in this case we deal with integer not string.
                    _dtMembers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtMembers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvMembers.Rows.Count.ToString();
        }

        private void frmListMembers_Load(object sender, EventArgs e)
        {
            _LoadRefreshMembersPerPage();
            cbFilterBy.SelectedItem = "None";
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "None");

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtMembers != null)
            {
                _dtMembers.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvMembers.Rows.Count.ToString();
            }
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Member ID" || cbFilterBy.Text == "Person ID")
                // Check if the key pressed is a control key (like Backspace)
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    e.Handled = true; // Suppress the character
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = int.TryParse(cbPage.Text, out int result) == true ? result : 0;

            // Load members data from the database and view it in the DataGridView
            _dtMembers = clsMember.GetMembersPerPage(_pageNumber, clsUtilities.RowsPerPage);
            _FillDataGridView(_dtMembers);
        }

    }
}