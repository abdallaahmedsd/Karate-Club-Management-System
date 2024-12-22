using Karate_Club.Global_Classes;
using Karate_Club_Business.Instructors;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Karate_Club.Instructors.Controls
{
	public partial class ctrSpecializations : UserControl
	{
		public ctrSpecializations()
		{
			InitializeComponent();
		}

		public void LoadSpecializations()
		{
			DataTable qualificationDT = ClsSpecialization.GetAll();
			if (qualificationDT.Rows.Count > 0)
			{

				foreach (DataRow row in qualificationDT.Rows)
				{
					int qualificationID = (int)row["SpecializationID"];
					string title = (string)row["Title"];

					Global.CheckListBoxItem qualificationItem = new Global.CheckListBoxItem(qualificationID, title);

					clbSpecializations.Items.Add(qualificationItem);
				}
			}
		}

		public List<ClsSpecialization> GetSelectedSpecializations()
		{
			List<ClsSpecialization> qualifications = new List<ClsSpecialization>();

			foreach (Global.CheckListBoxItem item in clbSpecializations.CheckedItems)
			{
				qualifications.Add(new ClsSpecialization { SpecializationID = item.ID, Title = item.Text });
			}

			return qualifications;
		}

		public void CheckSpecializations(List<ClsSpecialization> qualifications)
		{
			if(qualifications.Count > 0)
			{
				for (int idx = 0; idx < clbSpecializations.Items.Count; idx++)
				{

					Global.CheckListBoxItem item = (Global.CheckListBoxItem)clbSpecializations.Items[idx];

					// Check if the key qualificationID  exists in the list of qualifications 
					if (qualifications.FirstOrDefault(x => x.SpecializationID == item.ID) != null)
					{
						// If the case ID  exists in the CheckedListBox items, set its checked state
						clbSpecializations.SetItemChecked(idx, true);
					}
				}
			}
		}
	}
}
