namespace Karate_Club.Instructors
{
	partial class frmAddInstructor
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.tpExperience = new System.Windows.Forms.TabPage();
			this.txtYearsOfExperience = new System.Windows.Forms.TextBox();
			this.lblPhone = new System.Windows.Forms.Label();
			this.btnBackToSpecializations = new System.Windows.Forms.Button();
			this.btnGoToExperience = new System.Windows.Forms.Button();
			this.tpSpecializations = new System.Windows.Forms.TabPage();
			this.btnBackToQualifications = new System.Windows.Forms.Button();
			this.btnBackToPersonalInfo = new System.Windows.Forms.Button();
			this.btnGoToSpecializations = new System.Windows.Forms.Button();
			this.tpQualifications = new System.Windows.Forms.TabPage();
			this.btnGoToQualifications = new System.Windows.Forms.Button();
			this.tpPersonalInfo = new System.Windows.Forms.TabPage();
			this.tcInstructorInfo = new System.Windows.Forms.TabControl();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.ctrAddEditPerson1 = new Karate_Club.People.Controls.ctrAddEditPerson();
			this.ctrQualifications1 = new Karate_Club.Instructors.Controls.ctrQualifications();
			this.ctrSpecializations1 = new Karate_Club.Instructors.Controls.ctrSpecializations();
			this.panel1.SuspendLayout();
			this.tpExperience.SuspendLayout();
			this.tpSpecializations.SuspendLayout();
			this.tpQualifications.SuspendLayout();
			this.tpPersonalInfo.SuspendLayout();
			this.tcInstructorInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClose);
			this.panel1.Controls.Add(this.btnSave);
			this.panel1.Location = new System.Drawing.Point(411, 674);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(287, 44);
			this.panel1.TabIndex = 20;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.LimeGreen;
			this.label2.Location = new System.Drawing.Point(12, 59);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(1084, 45);
			this.label2.TabIndex = 19;
			this.label2.Text = "Add New Member";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// tpExperience
			// 
			this.tpExperience.BackColor = System.Drawing.Color.White;
			this.tpExperience.Controls.Add(this.pictureBox4);
			this.tpExperience.Controls.Add(this.txtYearsOfExperience);
			this.tpExperience.Controls.Add(this.lblPhone);
			this.tpExperience.Controls.Add(this.btnBackToSpecializations);
			this.tpExperience.Location = new System.Drawing.Point(4, 39);
			this.tpExperience.Name = "tpExperience";
			this.tpExperience.Padding = new System.Windows.Forms.Padding(3);
			this.tpExperience.Size = new System.Drawing.Size(1014, 447);
			this.tpExperience.TabIndex = 3;
			this.tpExperience.Text = "Experience";
			// 
			// txtYearsOfExperience
			// 
			this.txtYearsOfExperience.BackColor = System.Drawing.Color.White;
			this.txtYearsOfExperience.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtYearsOfExperience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtYearsOfExperience.ForeColor = System.Drawing.Color.Black;
			this.txtYearsOfExperience.Location = new System.Drawing.Point(297, 36);
			this.txtYearsOfExperience.Name = "txtYearsOfExperience";
			this.txtYearsOfExperience.Size = new System.Drawing.Size(300, 26);
			this.txtYearsOfExperience.TabIndex = 86;
			this.txtYearsOfExperience.Tag = "Phone number";
			this.txtYearsOfExperience.TextChanged += new System.EventHandler(this.txtYearsOfExperience_TextChanged);
			this.txtYearsOfExperience.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtYearsOfExperience_KeyPress);
			// 
			// lblPhone
			// 
			this.lblPhone.AutoSize = true;
			this.lblPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPhone.ForeColor = System.Drawing.Color.Black;
			this.lblPhone.Location = new System.Drawing.Point(41, 39);
			this.lblPhone.Name = "lblPhone";
			this.lblPhone.Size = new System.Drawing.Size(182, 20);
			this.lblPhone.TabIndex = 87;
			this.lblPhone.Text = "Years of experience:";
			// 
			// btnBackToSpecializations
			// 
			this.btnBackToSpecializations.BackColor = System.Drawing.Color.Gainsboro;
			this.btnBackToSpecializations.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBackToSpecializations.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnBackToSpecializations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBackToSpecializations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBackToSpecializations.ForeColor = System.Drawing.Color.Black;
			this.btnBackToSpecializations.Location = new System.Drawing.Point(20, 385);
			this.btnBackToSpecializations.Name = "btnBackToSpecializations";
			this.btnBackToSpecializations.Size = new System.Drawing.Size(95, 35);
			this.btnBackToSpecializations.TabIndex = 5;
			this.btnBackToSpecializations.Text = "Back";
			this.btnBackToSpecializations.UseVisualStyleBackColor = false;
			this.btnBackToSpecializations.Click += new System.EventHandler(this.btnBackToSpecializations_Click);
			// 
			// btnGoToExperience
			// 
			this.btnGoToExperience.BackColor = System.Drawing.Color.Gainsboro;
			this.btnGoToExperience.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGoToExperience.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnGoToExperience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGoToExperience.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGoToExperience.ForeColor = System.Drawing.Color.Black;
			this.btnGoToExperience.Location = new System.Drawing.Point(895, 385);
			this.btnGoToExperience.Name = "btnGoToExperience";
			this.btnGoToExperience.Size = new System.Drawing.Size(95, 35);
			this.btnGoToExperience.TabIndex = 2;
			this.btnGoToExperience.Text = "Next";
			this.btnGoToExperience.UseVisualStyleBackColor = false;
			this.btnGoToExperience.Click += new System.EventHandler(this.btnGoToExperience_Click);
			// 
			// tpSpecializations
			// 
			this.tpSpecializations.BackColor = System.Drawing.Color.White;
			this.tpSpecializations.Controls.Add(this.label3);
			this.tpSpecializations.Controls.Add(this.btnGoToExperience);
			this.tpSpecializations.Controls.Add(this.btnBackToQualifications);
			this.tpSpecializations.Controls.Add(this.ctrSpecializations1);
			this.tpSpecializations.Cursor = System.Windows.Forms.Cursors.Default;
			this.tpSpecializations.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tpSpecializations.Location = new System.Drawing.Point(4, 39);
			this.tpSpecializations.Name = "tpSpecializations";
			this.tpSpecializations.Padding = new System.Windows.Forms.Padding(3);
			this.tpSpecializations.Size = new System.Drawing.Size(1014, 447);
			this.tpSpecializations.TabIndex = 2;
			this.tpSpecializations.Text = "Specializations";
			// 
			// btnBackToQualifications
			// 
			this.btnBackToQualifications.BackColor = System.Drawing.Color.Gainsboro;
			this.btnBackToQualifications.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBackToQualifications.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnBackToQualifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBackToQualifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBackToQualifications.ForeColor = System.Drawing.Color.Black;
			this.btnBackToQualifications.Location = new System.Drawing.Point(20, 385);
			this.btnBackToQualifications.Name = "btnBackToQualifications";
			this.btnBackToQualifications.Size = new System.Drawing.Size(95, 35);
			this.btnBackToQualifications.TabIndex = 4;
			this.btnBackToQualifications.Text = "Back";
			this.btnBackToQualifications.UseVisualStyleBackColor = false;
			this.btnBackToQualifications.Click += new System.EventHandler(this.btnBackToQualifications_Click);
			// 
			// btnBackToPersonalInfo
			// 
			this.btnBackToPersonalInfo.BackColor = System.Drawing.Color.Gainsboro;
			this.btnBackToPersonalInfo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnBackToPersonalInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnBackToPersonalInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnBackToPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnBackToPersonalInfo.ForeColor = System.Drawing.Color.Black;
			this.btnBackToPersonalInfo.Location = new System.Drawing.Point(20, 385);
			this.btnBackToPersonalInfo.Name = "btnBackToPersonalInfo";
			this.btnBackToPersonalInfo.Size = new System.Drawing.Size(95, 35);
			this.btnBackToPersonalInfo.TabIndex = 3;
			this.btnBackToPersonalInfo.Text = "Back";
			this.btnBackToPersonalInfo.UseVisualStyleBackColor = false;
			this.btnBackToPersonalInfo.Click += new System.EventHandler(this.btnBackToPersonalInfo_Click);
			// 
			// btnGoToSpecializations
			// 
			this.btnGoToSpecializations.BackColor = System.Drawing.Color.Gainsboro;
			this.btnGoToSpecializations.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGoToSpecializations.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnGoToSpecializations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGoToSpecializations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGoToSpecializations.ForeColor = System.Drawing.Color.Black;
			this.btnGoToSpecializations.Location = new System.Drawing.Point(895, 385);
			this.btnGoToSpecializations.Name = "btnGoToSpecializations";
			this.btnGoToSpecializations.Size = new System.Drawing.Size(95, 35);
			this.btnGoToSpecializations.TabIndex = 2;
			this.btnGoToSpecializations.Text = "Next";
			this.btnGoToSpecializations.UseVisualStyleBackColor = false;
			this.btnGoToSpecializations.Click += new System.EventHandler(this.btnGoToSpecializations_Click);
			// 
			// tpQualifications
			// 
			this.tpQualifications.BackColor = System.Drawing.Color.White;
			this.tpQualifications.Controls.Add(this.label1);
			this.tpQualifications.Controls.Add(this.btnBackToPersonalInfo);
			this.tpQualifications.Controls.Add(this.btnGoToSpecializations);
			this.tpQualifications.Controls.Add(this.ctrQualifications1);
			this.tpQualifications.Cursor = System.Windows.Forms.Cursors.Default;
			this.tpQualifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tpQualifications.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.tpQualifications.Location = new System.Drawing.Point(4, 39);
			this.tpQualifications.Name = "tpQualifications";
			this.tpQualifications.Padding = new System.Windows.Forms.Padding(3);
			this.tpQualifications.Size = new System.Drawing.Size(1014, 447);
			this.tpQualifications.TabIndex = 1;
			this.tpQualifications.Text = "Qualifications";
			// 
			// btnGoToQualifications
			// 
			this.btnGoToQualifications.BackColor = System.Drawing.Color.Gainsboro;
			this.btnGoToQualifications.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGoToQualifications.FlatAppearance.BorderColor = System.Drawing.Color.Black;
			this.btnGoToQualifications.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnGoToQualifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnGoToQualifications.ForeColor = System.Drawing.Color.Black;
			this.btnGoToQualifications.Location = new System.Drawing.Point(895, 385);
			this.btnGoToQualifications.Name = "btnGoToQualifications";
			this.btnGoToQualifications.Size = new System.Drawing.Size(95, 35);
			this.btnGoToQualifications.TabIndex = 1;
			this.btnGoToQualifications.Text = "Next";
			this.btnGoToQualifications.UseVisualStyleBackColor = false;
			this.btnGoToQualifications.Click += new System.EventHandler(this.btnGoToQualifications_Click);
			// 
			// tpPersonalInfo
			// 
			this.tpPersonalInfo.BackColor = System.Drawing.Color.White;
			this.tpPersonalInfo.Controls.Add(this.btnGoToQualifications);
			this.tpPersonalInfo.Controls.Add(this.ctrAddEditPerson1);
			this.tpPersonalInfo.Cursor = System.Windows.Forms.Cursors.Default;
			this.tpPersonalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tpPersonalInfo.ForeColor = System.Drawing.Color.Black;
			this.tpPersonalInfo.Location = new System.Drawing.Point(4, 39);
			this.tpPersonalInfo.Name = "tpPersonalInfo";
			this.tpPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
			this.tpPersonalInfo.Size = new System.Drawing.Size(1014, 447);
			this.tpPersonalInfo.TabIndex = 0;
			this.tpPersonalInfo.Text = "Pernsonal Info";
			// 
			// tcInstructorInfo
			// 
			this.tcInstructorInfo.Controls.Add(this.tpPersonalInfo);
			this.tcInstructorInfo.Controls.Add(this.tpQualifications);
			this.tcInstructorInfo.Controls.Add(this.tpSpecializations);
			this.tcInstructorInfo.Controls.Add(this.tpExperience);
			this.tcInstructorInfo.Cursor = System.Windows.Forms.Cursors.Hand;
			this.tcInstructorInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tcInstructorInfo.ItemSize = new System.Drawing.Size(136, 35);
			this.tcInstructorInfo.Location = new System.Drawing.Point(43, 160);
			this.tcInstructorInfo.Name = "tcInstructorInfo";
			this.tcInstructorInfo.Padding = new System.Drawing.Point(10, 3);
			this.tcInstructorInfo.SelectedIndex = 0;
			this.tcInstructorInfo.Size = new System.Drawing.Size(1022, 490);
			this.tcInstructorInfo.TabIndex = 18;
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(34, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(273, 20);
			this.label1.TabIndex = 88;
			this.label1.Text = "Select instructor qualifications:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Black;
			this.label3.Location = new System.Drawing.Point(34, 30);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(287, 20);
			this.label3.TabIndex = 89;
			this.label3.Text = "Select instructor specializations:";
			// 
			// btnClose
			// 
			this.btnClose.AutoSize = true;
			this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(70)))), ((int)(((byte)(36)))));
			this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnClose.ForeColor = System.Drawing.Color.White;
			this.btnClose.Image = global::Karate_Club.Properties.Resources.close_24;
			this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnClose.Location = new System.Drawing.Point(12, 0);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(117, 44);
			this.btnClose.TabIndex = 18;
			this.btnClose.Text = "       Close";
			this.btnClose.UseVisualStyleBackColor = false;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// btnSave
			// 
			this.btnSave.AutoSize = true;
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.ForeColor = System.Drawing.Color.White;
			this.btnSave.Image = global::Karate_Club.Properties.Resources.save_24;
			this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Location = new System.Drawing.Point(158, 0);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(117, 44);
			this.btnSave.TabIndex = 17;
			this.btnSave.Text = "       Save";
			this.btnSave.UseVisualStyleBackColor = false;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = global::Karate_Club.Properties.Resources.experience_24;
			this.pictureBox4.Location = new System.Drawing.Point(251, 37);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(24, 24);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox4.TabIndex = 88;
			this.pictureBox4.TabStop = false;
			// 
			// ctrAddEditPerson1
			// 
			this.ctrAddEditPerson1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
			this.ctrAddEditPerson1.BackColor = System.Drawing.Color.White;
			this.ctrAddEditPerson1.Location = new System.Drawing.Point(16, 19);
			this.ctrAddEditPerson1.Name = "ctrAddEditPerson1";
			this.ctrAddEditPerson1.Size = new System.Drawing.Size(983, 340);
			this.ctrAddEditPerson1.TabIndex = 0;
			// 
			// ctrQualifications1
			// 
			this.ctrQualifications1.BackColor = System.Drawing.Color.White;
			this.ctrQualifications1.Location = new System.Drawing.Point(38, 65);
			this.ctrQualifications1.Name = "ctrQualifications1";
			this.ctrQualifications1.Size = new System.Drawing.Size(455, 303);
			this.ctrQualifications1.TabIndex = 4;
			// 
			// ctrSpecializations1
			// 
			this.ctrSpecializations1.BackColor = System.Drawing.Color.White;
			this.ctrSpecializations1.Location = new System.Drawing.Point(38, 65);
			this.ctrSpecializations1.Name = "ctrSpecializations1";
			this.ctrSpecializations1.Size = new System.Drawing.Size(455, 303);
			this.ctrSpecializations1.TabIndex = 5;
			// 
			// frmAddInstructor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1108, 742);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.tcInstructorInfo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmAddInstructor";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Instructor";
			this.Load += new System.EventHandler(this.frmAddInstructor_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.tpExperience.ResumeLayout(false);
			this.tpExperience.PerformLayout();
			this.tpSpecializations.ResumeLayout(false);
			this.tpSpecializations.PerformLayout();
			this.tpQualifications.ResumeLayout(false);
			this.tpQualifications.PerformLayout();
			this.tpPersonalInfo.ResumeLayout(false);
			this.tcInstructorInfo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion
		private People.Controls.ctrAddEditPerson ctrAddEditPerson1;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TabPage tpExperience;
		private System.Windows.Forms.Button btnBackToSpecializations;
		private System.Windows.Forms.Button btnGoToExperience;
		private System.Windows.Forms.TabPage tpSpecializations;
		private System.Windows.Forms.Button btnBackToQualifications;
		private System.Windows.Forms.Button btnBackToPersonalInfo;
		private System.Windows.Forms.Button btnGoToSpecializations;
		private System.Windows.Forms.TabPage tpQualifications;
		private System.Windows.Forms.Button btnGoToQualifications;
		private System.Windows.Forms.TabPage tpPersonalInfo;
		private System.Windows.Forms.TabControl tcInstructorInfo;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.TextBox txtYearsOfExperience;
		private System.Windows.Forms.Label lblPhone;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.Label label1;
		private Controls.ctrQualifications ctrQualifications1;
		private System.Windows.Forms.Label label3;
		private Controls.ctrSpecializations ctrSpecializations1;
	}
}