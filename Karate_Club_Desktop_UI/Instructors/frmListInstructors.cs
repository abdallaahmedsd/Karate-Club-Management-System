using Karate_Club.Global_Classes;
using Karate_Club_Business.Instructors;
using Karate_Club_Business.Instructors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_Club.Instructors
{
	public partial class frmListInstructors : Form
	{
		private enum enMode { add, update, delete }
		private enMode _mode = enMode.add;
		private ushort _pageNumber = 0;
		private uint _currentPageNumber = 0;
		private uint _totalNumberOfPages = 0;
		private DataTable _dtInstructors;

		public frmListInstructors()
		{
			InitializeComponent();
		}

		private void _FillDataGridView(DataTable dtInstructors)
		{
			if (dtInstructors != null && dtInstructors.Rows.Count > 0)
			{
				dgvInstructors.DataSource = dtInstructors;

				// Change the columns name
				dgvInstructors.Columns["InstructorID"].HeaderText = "Instructor ID";
				dgvInstructors.Columns["PersonID"].HeaderText = "Person ID";
				dgvInstructors.Columns["FullName"].HeaderText = "Full Name";

				//Set AutoSizeMode for the FullName column to AutoSize
				dgvInstructors.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

				lblTotalRecordsCount.Text = dtInstructors.Rows.Count.ToString();
			}
		}

		private async Task _LoadRefreshInstructorsPerPageAsync()
		{
			// Get the number of pages and show them in the ComoboBox "cbPage"
			if (_mode == enMode.add || _mode == enMode.delete)
				_HandleNumberOfPages();

			// load Instructors data per page and save them in the DataTable "_dtInstructors"
			// in case the page number is equal to zero assign null to the DataTable "_dtInstructors"
			_dtInstructors = await Task.Run(() => _pageNumber > 0 ? ClsInstructor.GetInstructorsPerPageAsync(_pageNumber, clsUtilities.RowsPerPage) : null);
			_FillDataGridView(_dtInstructors);
		}

		private void _HandleNumberOfPages()
		{
			uint totalInstructorsCount = ClsInstructor.Count();

			// Calculate the number of pages depending on "totalInstructorsCount"
			uint numberOfPages = totalInstructorsCount > 0 ? (uint)Math.Ceiling((double)totalInstructorsCount / clsUtilities.RowsPerPage) : 0;

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
				case "Instructor ID":
					filterColumn = "InstructorID";
					break;
				case "Person ID":
					filterColumn = "PersonID";
					break;
				case "Full Name":
					filterColumn = "FullName";
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
				_dtInstructors.DefaultView.RowFilter = string.Empty;
			}
			else
			{

				if (filterColumn == "InstructorID" || filterColumn == "PersonID")
					//in this case we deal with integer not string.
					_dtInstructors.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
				else
					_dtInstructors.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
			}

			// Updates the total records count label
			lblTotalRecordsCount.Text = dgvInstructors.Rows.Count.ToString();
		}

		private void _OpenInstructorCardForm()
		{
			//_mode = enMode.update;

			//int InstructorID = (int)dgvInstructors.CurrentRow.Cells["InstructorID"].Value;

			//frmInstructorCard frm = new frmInstructorCard(InstructorID);
			//_Subscribe(frm);
			//frm.ShowDialog();
		}

		private void _HandleCurrentPage()
		{
			cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
		}

		private async void frmListInstructors_LoadAsync(object sender, EventArgs e)
		{
			// Cusomize the appearance of the DataGridView
			clsUtilities.CustomizeDataGridView(dgvInstructors);

			await _LoadRefreshInstructorsPerPageAsync();
			cbFilterBy.SelectedItem = "None";
		}

		private void btnAddInstructor_Click(object sender, EventArgs e)
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

			if (_dtInstructors != null)
			{
				_dtInstructors.DefaultView.RowFilter = string.Empty;
				lblTotalRecordsCount.Text = dgvInstructors.Rows.Count.ToString();
			}
		}

		private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (cbFilterBy.Text == "Instructor ID" || cbFilterBy.Text == "Person ID")
				clsUtilities.IsNumber(e);
		}

		private async void cbPage_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Get the selected page number
			_pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

			// Load members data from the database and view it in the DataGridView
			_dtInstructors = await ClsInstructor.GetInstructorsPerPageAsync(_pageNumber, clsUtilities.RowsPerPage);
			_FillDataGridView(_dtInstructors);
		}
	}
}
