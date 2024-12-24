using Karate_Club_Business;
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

namespace Karate_Club
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
			ctrQualifications1.LoadQualifications();
			ctrSpecializations1.LoadSpecializations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ctrAddEditPerson1.LoadPersonInfo(1);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

		private void button1_Click_2(object sender, EventArgs e)
		{
			List<ClsQualification> lst = ctrQualifications1.GetSelectedQualifications();

			List<ClsSpecialization> lst2 = ctrSpecializations1.GetSelectedSpecializations();

			foreach (ClsQualification c in lst)
			{

			}
			//ClsInstructor instructor = ClsInstructor.Find(3);

			//instructor.YearsOfExperience = 200;

			//if (instructor.Save())
			//	MessageBox.Show(instructor.YearsOfExperience.ToString());
			//else
			//	MessageBox.Show("something went wrong");

			//ClsInstructor instructor = new ClsInstructor
			//{
			//	FirstName = "Test",
			//	LastName = "Test",
			//	Gender = 'm',
			//	Birthdate = new DateTime(1998, 8, 25),
			//	Phone = "30282123",
			//	Email = "test@gmail.com",
			//	Address = "Main st 123",
			//	ImagePath = null,
			//	Qualifications = new List<ClsQualification>()
			//	{
			//		new ClsQualification
			//		{
			//			QualificationID = 1,
			//			Title = "Test",
			//		},
			//		new ClsQualification
			//		{
			//			QualificationID = 2,
			//			Title = "Test",
			//		},
			//		new ClsQualification
			//		{
			//			QualificationID = 3,
			//			Title = "Test",
			//		},
			//	},
			//	Specializations = new List<ClsSpecialization>()
			//	{
			//		new ClsSpecialization
			//		{
			//			SpecializationID = 1,
			//			Title = "Test",
			//		},
			//		new ClsSpecialization
			//		{
			//			SpecializationID = 2,
			//			Title = "Test",
			//		},
			//		new ClsSpecialization
			//		{
			//			SpecializationID = 3,
			//			Title = "Test",
			//		},
			//	},
			//	YearsOfExperience = 16,
			//	IsActive = true,
			//};
		}

		private void button2_Click(object sender, EventArgs e)
		{
			List<ClsQualification> lst = new List<ClsQualification>()
				{
					new ClsQualification
					{
						QualificationID = 1,
						Title = "Test",
					},
					new ClsQualification
					{
						QualificationID = 2,
						Title = "Test",
					},
					new ClsQualification
					{
						QualificationID = 3,
						Title = "Test",
					},
				};

			ctrQualifications1.CheckQualifications(lst);

			List<ClsSpecialization> lst2 = new List<ClsSpecialization>()
				{
					new ClsSpecialization
					{
						SpecializationID = 1,
						Title = "Test",
					},
					new ClsSpecialization
					{
						SpecializationID = 2,
						Title = "Test",
					},
					new ClsSpecialization
					{
						SpecializationID = 3,
						Title = "Test",
					},
				};

			ctrSpecializations1.CheckSpecializations(lst2);
		}
	}
}
