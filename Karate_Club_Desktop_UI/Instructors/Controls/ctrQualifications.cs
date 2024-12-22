using Karate_Club.Global_Classes;
using Karate_Club_Business.Instructors;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Karate_Club.Instructors.Controls
{
	public partial class ctrQualifications : UserControl
	{
		public ctrQualifications()
		{
			InitializeComponent();
		}

		public void LoadQualifications()
		{
			DataTable qualificationDT = ClsQualification.GetAll();
			if (qualificationDT.Rows.Count > 0)
			{

				foreach (DataRow row in qualificationDT.Rows)
				{
					int qualificationID = (int)row["QualificationID"];
					string title = (string)row["Title"];

					Global.CheckListBoxItem qualificationItem = new Global.CheckListBoxItem(qualificationID, title);

					clbQualifications.Items.Add(qualificationItem);
				}
			}
		}

		public List<ClsQualification> GetSelectedQualifications()
		{
			List<ClsQualification> qualifications = new List<ClsQualification>();

			foreach (Global.CheckListBoxItem item in clbQualifications.CheckedItems)
			{
				qualifications.Add(new ClsQualification { QualificationID = item.ID, Title = item.Text });
			}

			return qualifications;
		}

		public void CheckQualifications(List<ClsQualification> qualifications)
		{
			if(qualifications.Count > 0)
			{
				for (int idx = 0; idx < clbQualifications.Items.Count; idx++)
				{

					Global.CheckListBoxItem item = (Global.CheckListBoxItem)clbQualifications.Items[idx];

					// Check if the key qualificationID  exists in the list of qualifications 
					if (qualifications.FirstOrDefault(x => x.QualificationID == item.ID) != null)
					{
						// If the case ID  exists in the CheckedListBox items, set its checked state
						clbQualifications.SetItemChecked(idx, true);
					}
				}
			}
		}
	}
}
