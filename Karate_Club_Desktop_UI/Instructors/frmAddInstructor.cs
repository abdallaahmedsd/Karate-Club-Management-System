using Karate_Club.Global_Classes;
using Karate_Club_Business.Instructors;
using System;
using System.Windows.Forms;

namespace Karate_Club.Instructors
{
	public partial class frmAddInstructor : Form
	{
		// This event will be raised when a new instructor added successfully
		// Apply Publisher Subscriber Desgin Pattern => Observer Design Pattern
		public event EventHandler<InstructorAddedEventArgs> NewInstructorAdded;

		private void OnNewInstructorAdded(int? instructorID)
		{
			OnNewInstructorAdded(this, new InstructorAddedEventArgs(instructorID));
		}

		// Raise the event and call all subscribers from different places
		protected virtual void OnNewInstructorAdded(object sender, InstructorAddedEventArgs e)
		{
			NewInstructorAdded?.Invoke(this, e);
		}

		ClsInstructor _instructor;

		public frmAddInstructor()
		{
			InitializeComponent();
		}

		private bool _ValidateEmptyFields(TextBox textBox)
		{
			if (string.IsNullOrWhiteSpace(textBox.Text))
			{
				errorProvider1.SetError(textBox, "This field is required!");
				return false;
			}
			else
			{
				errorProvider1.SetError(textBox, null);
				return true;
			}
		}

		private void _LoadQualificationsAndSpecializations()
		{
			ctrQualifications1.LoadQualifications();
			ctrSpecializations1.LoadSpecializations();
		}

		private void _FillInstructorObject()
		{
			_instructor = new ClsInstructor();

			// Get personal info from the ctrAddEditPerson1 and set it to _instructor class
			_instructor.FirstName = ctrAddEditPerson1.PersonalInfo.FirstName;
			_instructor.LastName = ctrAddEditPerson1.PersonalInfo.LastName;
			_instructor.Gender = ctrAddEditPerson1.PersonalInfo.Gender;
			_instructor.Birthdate = ctrAddEditPerson1.PersonalInfo.Birthdate;
			_instructor.Phone = ctrAddEditPerson1.PersonalInfo.Phone;
			_instructor.Email = ctrAddEditPerson1.PersonalInfo.Email;
			_instructor.Address = ctrAddEditPerson1.PersonalInfo.Address;
			_instructor.ImagePath = ctrAddEditPerson1.PersonalInfo.ImagePath;

			// Get qualifications from ctrQualifications1
			_instructor.Qualifications = ctrQualifications1.GetSelectedQualifications();

			// Get specializations from ctrSpecializations1
			_instructor.Specializations = ctrSpecializations1.GetSelectedSpecializations();

			_instructor.YearsOfExperience = byte.Parse(txtYearsOfExperience.Text);
			_instructor.IsActive = true;
		}

		private bool _AreAllDataValid()
		{
			// Check if all personal data are provided correctly 
			if (!ctrAddEditPerson1.AreAllFieldsValid())
			{
				MessageBox.Show("Some fields are not valid in the personal info tab. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			// Check if all emergency conatct data are provided correctly
			if (!_ValidateEmptyFields(txtYearsOfExperience))
			{
				MessageBox.Show("Some fields are not valid in the experience tab. Hover over the red icons to see the message provided.", "Not valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}

			return true;
		}

		private void txtYearsOfExperience_TextChanged(object sender, EventArgs e)
		{
			_ValidateEmptyFields(txtYearsOfExperience);
		}

		private void txtYearsOfExperience_KeyPress(object sender, KeyPressEventArgs e)
		{
			clsUtilities.IsNumber(e);
		}

		private void frmAddInstructor_Load(object sender, EventArgs e)
		{
			_LoadQualificationsAndSpecializations();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!_AreAllDataValid())
				return;

			_FillInstructorObject();

			if (MessageBox.Show("Are you sure you want to add a instructor?", "Confirm Adding New Instructor", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				if (_instructor.Save())
				{
					MessageBox.Show($"Instructor has been added successfully with ID ({_instructor.InstructorID}).", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);


					// To prevent the user from adding instructor mulitiple times 
					tpPersonalInfo.Enabled = false;
					tpQualifications.Enabled = false;
					tpSpecializations.Enabled = false;
					tpExperience.Enabled = false;
					btnSave.Enabled = false;

					// Raise the InstructorAddedEvent
					OnNewInstructorAdded(_instructor.InstructorID);
				}
				else
				{
					MessageBox.Show($"Cannot add new instructor. Something went wrong.", "Falied", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnGoToQualifications_Click(object sender, EventArgs e)
		{
			// first check if all required fields are specified
			if (!ctrAddEditPerson1.AreAllFieldsValid())
			{
				MessageBox.Show("Some fields are not valid. Hover over the red icons to see the message provided.", "Not Valid", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			tcInstructorInfo.SelectTab("tpQualifications");
		}

		private void btnBackToPersonalInfo_Click(object sender, EventArgs e)
		{
			tcInstructorInfo.SelectTab("tpPersonalInfo");
		}

		private void btnGoToSpecializations_Click(object sender, EventArgs e)
		{
			tcInstructorInfo.SelectTab("tpSpecializations");
		}

		private void btnBackToQualifications_Click(object sender, EventArgs e)
		{
			tcInstructorInfo.SelectTab("tpQualifications");
		}

		private void btnGoToExperience_Click(object sender, EventArgs e)
		{
			tcInstructorInfo.SelectTab("tpExperience");
		}

		private void btnBackToSpecializations_Click(object sender, EventArgs e)
		{
			tcInstructorInfo.SelectTab("tpSpecializations");
		}
	}

	public class InstructorAddedEventArgs : EventArgs
	{
		public int? InstructorID { get; }

		public InstructorAddedEventArgs(int? instructorID)
		{
			InstructorID = instructorID;
		}
	}
}
