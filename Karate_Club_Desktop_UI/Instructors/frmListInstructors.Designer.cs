namespace Karate_Club.Instructors
{
	partial class frmListInstructors
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
		private async void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListInstructors));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
			this.deactivateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateEmegencyContactInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updatePersonalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.updateMemberInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.addNewInstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnPreviousPage = new System.Windows.Forms.Button();
			this.btnNextPage = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.btnAddInstructor = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtFilterValue = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cbFilterBy = new System.Windows.Forms.ComboBox();
			this.lblTotalRecordsCount = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.cmsInstructors = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cbPage = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.dgvInstructors = new System.Windows.Forms.DataGridView();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.cmsInstructors.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvInstructors)).BeginInit();
			this.SuspendLayout();
			// 
			// deactivateToolStripMenuItem
			// 
			this.deactivateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deactivateToolStripMenuItem.Image")));
			this.deactivateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deactivateToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.deactivateToolStripMenuItem.Name = "deactivateToolStripMenuItem";
			this.deactivateToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
			this.deactivateToolStripMenuItem.Text = "Deactivate";
			// 
			// activateToolStripMenuItem
			// 
			this.activateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("activateToolStripMenuItem.Image")));
			this.activateToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.activateToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
			this.activateToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
			this.activateToolStripMenuItem.Text = "Activate";
			// 
			// updateEmegencyContactInformationToolStripMenuItem
			// 
			this.updateEmegencyContactInformationToolStripMenuItem.Image = global::Karate_Club.Properties.Resources.emergency_contact_32;
			this.updateEmegencyContactInformationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.updateEmegencyContactInformationToolStripMenuItem.Name = "updateEmegencyContactInformationToolStripMenuItem";
			this.updateEmegencyContactInformationToolStripMenuItem.Size = new System.Drawing.Size(318, 38);
			this.updateEmegencyContactInformationToolStripMenuItem.Text = "Edit Emegency Contact Info";
			// 
			// updatePersonalInformationToolStripMenuItem
			// 
			this.updatePersonalInformationToolStripMenuItem.Image = global::Karate_Club.Properties.Resources.personal_info_32;
			this.updatePersonalInformationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.updatePersonalInformationToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.updatePersonalInformationToolStripMenuItem.Name = "updatePersonalInformationToolStripMenuItem";
			this.updatePersonalInformationToolStripMenuItem.Size = new System.Drawing.Size(318, 38);
			this.updatePersonalInformationToolStripMenuItem.Text = "Edit Personal Info";
			// 
			// updateMemberInfoToolStripMenuItem
			// 
			this.updateMemberInfoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updatePersonalInformationToolStripMenuItem,
            this.updateEmegencyContactInformationToolStripMenuItem});
			this.updateMemberInfoToolStripMenuItem.Image = global::Karate_Club.Properties.Resources.edit_32;
			this.updateMemberInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.updateMemberInfoToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.updateMemberInfoToolStripMenuItem.Name = "updateMemberInfoToolStripMenuItem";
			this.updateMemberInfoToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
			this.updateMemberInfoToolStripMenuItem.Text = "Edit";
			// 
			// addNewInstructorToolStripMenuItem
			// 
			this.addNewInstructorToolStripMenuItem.Image = global::Karate_Club.Properties.Resources.add_32;
			this.addNewInstructorToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.addNewInstructorToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.addNewInstructorToolStripMenuItem.Name = "addNewInstructorToolStripMenuItem";
			this.addNewInstructorToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
			this.addNewInstructorToolStripMenuItem.Text = "Add New Subscription";
			// 
			// showInfoToolStripMenuItem
			// 
			this.showInfoToolStripMenuItem.Image = global::Karate_Club.Properties.Resources.info_32;
			this.showInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.showInfoToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.showInfoToolStripMenuItem.Name = "showInfoToolStripMenuItem";
			this.showInfoToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
			this.showInfoToolStripMenuItem.Text = "Show Info";
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::Karate_Club.Properties.Resources.delete_32;
			this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.deleteToolStripMenuItem.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(265, 38);
			this.deleteToolStripMenuItem.Text = "Delete Permanently";
			// 
			// btnPreviousPage
			// 
			this.btnPreviousPage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnPreviousPage.FlatAppearance.BorderSize = 0;
			this.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnPreviousPage.Image = global::Karate_Club.Properties.Resources.left_arrow_24;
			this.btnPreviousPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnPreviousPage.Location = new System.Drawing.Point(1121, 437);
			this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnPreviousPage.Name = "btnPreviousPage";
			this.btnPreviousPage.Size = new System.Drawing.Size(44, 35);
			this.btnPreviousPage.TabIndex = 178;
			this.btnPreviousPage.UseVisualStyleBackColor = true;
			// 
			// btnNextPage
			// 
			this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnNextPage.FlatAppearance.BorderSize = 0;
			this.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnNextPage.Image = global::Karate_Club.Properties.Resources.right_arrow_24;
			this.btnNextPage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnNextPage.Location = new System.Drawing.Point(1173, 437);
			this.btnNextPage.Margin = new System.Windows.Forms.Padding(4);
			this.btnNextPage.Name = "btnNextPage";
			this.btnNextPage.Size = new System.Drawing.Size(44, 35);
			this.btnNextPage.TabIndex = 177;
			this.btnNextPage.UseVisualStyleBackColor = true;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Karate_Club.Properties.Resources.karate_girl_boy_with_black_belts;
			this.pictureBox1.Location = new System.Drawing.Point(622, 141);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(386, 256);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 166;
			this.pictureBox1.TabStop = false;
			// 
			// btnAddInstructor
			// 
			this.btnAddInstructor.BackColor = System.Drawing.Color.White;
			this.btnAddInstructor.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnAddInstructor.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.btnAddInstructor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.btnAddInstructor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnAddInstructor.Image = ((System.Drawing.Image)(resources.GetObject("btnAddInstructor.Image")));
			this.btnAddInstructor.Location = new System.Drawing.Point(1497, 411);
			this.btnAddInstructor.Name = "btnAddInstructor";
			this.btnAddInstructor.Padding = new System.Windows.Forms.Padding(3);
			this.btnAddInstructor.Size = new System.Drawing.Size(90, 60);
			this.btnAddInstructor.TabIndex = 171;
			this.btnAddInstructor.UseVisualStyleBackColor = false;
			this.btnAddInstructor.Click += new System.EventHandler(this.btnAddInstructor_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.Location = new System.Drawing.Point(848, 443);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 25);
			this.label4.TabIndex = 176;
			this.label4.Text = "Page:";
			// 
			// txtFilterValue
			// 
			this.txtFilterValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtFilterValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtFilterValue.Location = new System.Drawing.Point(382, 441);
			this.txtFilterValue.Multiline = true;
			this.txtFilterValue.Name = "txtFilterValue";
			this.txtFilterValue.Size = new System.Drawing.Size(220, 30);
			this.txtFilterValue.TabIndex = 168;
			this.txtFilterValue.TextChanged += new System.EventHandler(this.txtFilterValue_TextChanged);
			this.txtFilterValue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterValue_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(42, 443);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 25);
			this.label3.TabIndex = 175;
			this.label3.Text = "Filter By:";
			// 
			// cbFilterBy
			// 
			this.cbFilterBy.BackColor = System.Drawing.Color.White;
			this.cbFilterBy.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbFilterBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbFilterBy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.cbFilterBy.FormattingEnabled = true;
			this.cbFilterBy.ItemHeight = 20;
			this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Member ID",
            "Person ID",
            "Full Name",
            "Gender"});
			this.cbFilterBy.Location = new System.Drawing.Point(156, 441);
			this.cbFilterBy.Name = "cbFilterBy";
			this.cbFilterBy.Size = new System.Drawing.Size(220, 28);
			this.cbFilterBy.TabIndex = 167;
			this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
			// 
			// lblTotalRecordsCount
			// 
			this.lblTotalRecordsCount.AutoSize = true;
			this.lblTotalRecordsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTotalRecordsCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.lblTotalRecordsCount.Location = new System.Drawing.Point(180, 863);
			this.lblTotalRecordsCount.Name = "lblTotalRecordsCount";
			this.lblTotalRecordsCount.Size = new System.Drawing.Size(24, 25);
			this.lblTotalRecordsCount.TabIndex = 174;
			this.lblTotalRecordsCount.Text = "0";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.label2.Location = new System.Drawing.Point(42, 863);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(116, 25);
			this.label2.TabIndex = 173;
			this.label2.Text = "# Records:";
			// 
			// cmsInstructors
			// 
			this.cmsInstructors.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.cmsInstructors.ImageScalingSize = new System.Drawing.Size(20, 20);
			this.cmsInstructors.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showInfoToolStripMenuItem,
            this.addNewInstructorToolStripMenuItem,
            this.updateMemberInfoToolStripMenuItem,
            this.activateToolStripMenuItem,
            this.deactivateToolStripMenuItem,
            this.deleteToolStripMenuItem});
			this.cmsInstructors.Name = "cmsMembers";
			this.cmsInstructors.Size = new System.Drawing.Size(266, 262);
			// 
			// cbPage
			// 
			this.cbPage.BackColor = System.Drawing.Color.White;
			this.cbPage.Cursor = System.Windows.Forms.Cursors.Hand;
			this.cbPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cbPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			this.cbPage.FormattingEnabled = true;
			this.cbPage.ItemHeight = 20;
			this.cbPage.Items.AddRange(new object[] {
            "None",
            "Driver ID",
            "Person ID",
            "National No",
            "Full Name"});
			this.cbPage.Location = new System.Drawing.Point(934, 441);
			this.cbPage.Name = "cbPage";
			this.cbPage.Size = new System.Drawing.Size(164, 28);
			this.cbPage.TabIndex = 170;
			this.cbPage.SelectedIndexChanged += new System.EventHandler(this.cbPage_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(70)))), ((int)(((byte)(36)))));
			this.label1.Location = new System.Drawing.Point(0, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(1631, 58);
			this.label1.TabIndex = 169;
			this.label1.Text = "Manage Instructors";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// dgvInstructors
			// 
			this.dgvInstructors.AllowUserToAddRows = false;
			this.dgvInstructors.AllowUserToDeleteRows = false;
			this.dgvInstructors.AllowUserToOrderColumns = true;
			this.dgvInstructors.AllowUserToResizeRows = false;
			this.dgvInstructors.BackgroundColor = System.Drawing.Color.White;
			this.dgvInstructors.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvInstructors.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
			dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
			dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
			dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvInstructors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
			this.dgvInstructors.ColumnHeadersHeight = 40;
			this.dgvInstructors.GridColor = System.Drawing.Color.DarkGray;
			this.dgvInstructors.Location = new System.Drawing.Point(47, 484);
			this.dgvInstructors.Name = "dgvInstructors";
			this.dgvInstructors.ReadOnly = true;
			this.dgvInstructors.RowHeadersWidth = 51;
			this.dgvInstructors.RowTemplate.Height = 25;
			this.dgvInstructors.Size = new System.Drawing.Size(1540, 360);
			this.dgvInstructors.TabIndex = 172;
			// 
			// frmListInstructors
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(1648, 940);
			this.Controls.Add(this.btnPreviousPage);
			this.Controls.Add(this.btnNextPage);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.btnAddInstructor);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtFilterValue);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cbFilterBy);
			this.Controls.Add(this.lblTotalRecordsCount);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cbPage);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dgvInstructors);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmListInstructors";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manage Instructors";
			this.Load += new System.EventHandler(this.frmListInstructors_LoadAsync);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.cmsInstructors.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvInstructors)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.ToolStripMenuItem deactivateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateEmegencyContactInformationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updatePersonalInformationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem updateMemberInfoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addNewInstructorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showInfoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.Button btnPreviousPage;
		private System.Windows.Forms.Button btnNextPage;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button btnAddInstructor;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtFilterValue;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbFilterBy;
		private System.Windows.Forms.Label lblTotalRecordsCount;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ContextMenuStrip cmsInstructors;
		private System.Windows.Forms.ComboBox cbPage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.DataGridView dgvInstructors;
	}
}