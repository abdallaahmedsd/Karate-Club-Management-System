﻿using Karate_Club.Emergency_Contacts;
using Karate_Club.Global_Classes;
using Karate_Club.Members;
using Karate_Club_Business;
using System;
using System.Data;
using System.Windows.Forms;

using static System.Math;

namespace Karate_Club
{
    public partial class frmListMembers : Form
    {
        private enum enMode { add, update, delete}
        private enMode _mode = enMode.add;
        private ushort _pageNumber = 0; 
        private DataTable _dtMembers;

        public frmListMembers()
        {
            InitializeComponent();
        }

        // this function will subscribe to an event in frmAddMember form.
        // This function will be called only if new member has been added.
        // It will refresh the number of pages and will reload the data from the database
        private void _OnNewMemberAdded(object sender, MemberAddedEventArgs e) => _LoadRefreshMembersPerPage();

        private void _OnPersonalInfoUpdated_frmEditPersonalInfo() => _LoadRefreshMembersPerPage();

        private void _OnEmergencyContactInfoUpdated() => _LoadRefreshMembersPerPage();

        private void _OnPersonalInfoUpdated_frmMemberCard() => _LoadRefreshMembersPerPage(); // Will be fired incase there has been updating by frmMemberCard

        private void _Subscribe(frmAddMember frm)  => frm.NewMemberAdded += _OnNewMemberAdded;

        private void _Subscribe(frmEditPersonalInfo frm) => frm.PersonalInfoUpdated += _OnPersonalInfoUpdated_frmEditPersonalInfo;

        private void _Subscribe(frmEditEmergencyContactInfo frm) => frm.EmergencyContactInfoUpdated += _OnEmergencyContactInfoUpdated;

        private void _Subscribe(frmMemberCard frm) => frm.MemberInfoUpdated += _OnPersonalInfoUpdated_frmMemberCard;

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
            if(_mode == enMode.add || _mode == enMode.delete)
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
            uint numberOfPages = totalMembersCount > 0 ? (uint)Ceiling((double)totalMembersCount / clsUtilities.RowsPerPage) : 0;

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
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;
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

        private void _OpenMemberCardForm()
        {
            _mode = enMode.update;

            int memberID = (int)dgvMembers.CurrentRow.Cells["MemberID"].Value;

            frmMemberCard frm = new frmMemberCard(memberID);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void frmListMembers_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtilities.CustomizeDataGridView(dgvMembers);

            _LoadRefreshMembersPerPage();
            cbFilterBy.SelectedItem = "None";
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            _mode = enMode.add;

            frmAddMember frm = new frmAddMember();

            // Subscribe to the event in frmAddMember Form 
            _Subscribe(frm);
            frm.ShowDialog();
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
                clsUtilities.IsNumber(e);
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load members data from the database and view it in the DataGridView
            _dtMembers = clsMember.GetMembersPerPage(_pageNumber, clsUtilities.RowsPerPage);
            _FillDataGridView(_dtMembers);
        }

        private void updatePersonalInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = enMode.update;

            int personID = (int)dgvMembers.CurrentRow.Cells["PersonID"].Value;

            frmEditPersonalInfo frm = new frmEditPersonalInfo(personID);

            // Subscribe to the event in frmEditPersonalInfo Form 
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void updateEmegencyContactInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = enMode.update;

            int memberID = (int)dgvMembers.CurrentRow.Cells["MemberID"].Value;
            clsMember member = clsMember.Find(memberID);

            if(member != null)
            {
                frmEditEmergencyContactInfo frm = new frmEditEmergencyContactInfo(member.EmergencyContactID);
                _Subscribe(frm);
                frm.ShowDialog();
            }
        }

        // This function will supress the ContextMenuStrip from being shown incase the DataGridView is empty
        private void dgvMembers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvMembers.Rows.Count == 0 || dgvMembers.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvMembers.CurrentCell = dgvMembers[e.ColumnIndex, e.RowIndex];
                    cmsMembers.Show(Cursor.Position);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _OpenMemberCardForm();
        }

        private void dgvMembers_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            _OpenMemberCardForm();
        }
    }
}