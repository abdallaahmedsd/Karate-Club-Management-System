namespace Karate_Club
{
    partial class frmAddMember
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
            this.tcMemberInfo = new System.Windows.Forms.TabControl();
            this.tpPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnGoToEmergencyContactfo = new System.Windows.Forms.Button();
            this.ctrAddEditPerson1 = new Karate_Club.People.Controls.ctrAddEditPerson();
            this.tpEmergencyContactInfo = new System.Windows.Forms.TabPage();
            this.btnBackToPersonalInfo = new System.Windows.Forms.Button();
            this.btnGoToSubscriptionInfo = new System.Windows.Forms.Button();
            this.ctrAddEditEmergencyContact1 = new Karate_Club.Emergency_Contacts.ctrAddEditEmergencyContact();
            this.tpSubscriptionInfo = new System.Windows.Forms.TabPage();
            this.btnGoToCurrentBelt = new System.Windows.Forms.Button();
            this.btnBackToEmergencyContactInfo = new System.Windows.Forms.Button();
            this.ctrAddEditSubscription1 = new Karate_Club.Subscriptions.ctrAddEditSubscription();
            this.tpCurrentBelt = new System.Windows.Forms.TabPage();
            this.btnBackToSubscriptionInfo = new System.Windows.Forms.Button();
            this.cbCurrentBelt = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcMemberInfo.SuspendLayout();
            this.tpPersonalInfo.SuspendLayout();
            this.tpEmergencyContactInfo.SuspendLayout();
            this.tpSubscriptionInfo.SuspendLayout();
            this.tpCurrentBelt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMemberInfo
            // 
            this.tcMemberInfo.Controls.Add(this.tpPersonalInfo);
            this.tcMemberInfo.Controls.Add(this.tpEmergencyContactInfo);
            this.tcMemberInfo.Controls.Add(this.tpSubscriptionInfo);
            this.tcMemberInfo.Controls.Add(this.tpCurrentBelt);
            this.tcMemberInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tcMemberInfo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcMemberInfo.ItemSize = new System.Drawing.Size(136, 35);
            this.tcMemberInfo.Location = new System.Drawing.Point(41, 159);
            this.tcMemberInfo.Name = "tcMemberInfo";
            this.tcMemberInfo.Padding = new System.Drawing.Point(10, 3);
            this.tcMemberInfo.SelectedIndex = 0;
            this.tcMemberInfo.Size = new System.Drawing.Size(1022, 490);
            this.tcMemberInfo.TabIndex = 0;
            this.tcMemberInfo.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcMemberInfo_Selecting);
            // 
            // tpPersonalInfo
            // 
            this.tpPersonalInfo.BackColor = System.Drawing.Color.White;
            this.tpPersonalInfo.Controls.Add(this.btnGoToEmergencyContactfo);
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
            // btnGoToEmergencyContactfo
            // 
            this.btnGoToEmergencyContactfo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGoToEmergencyContactfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToEmergencyContactfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGoToEmergencyContactfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToEmergencyContactfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToEmergencyContactfo.ForeColor = System.Drawing.Color.Black;
            this.btnGoToEmergencyContactfo.Location = new System.Drawing.Point(895, 385);
            this.btnGoToEmergencyContactfo.Name = "btnGoToEmergencyContactfo";
            this.btnGoToEmergencyContactfo.Size = new System.Drawing.Size(95, 35);
            this.btnGoToEmergencyContactfo.TabIndex = 1;
            this.btnGoToEmergencyContactfo.Text = "Next";
            this.btnGoToEmergencyContactfo.UseVisualStyleBackColor = false;
            this.btnGoToEmergencyContactfo.Click += new System.EventHandler(this.btnGoToEmergencyContactfo_Click);
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
            // tpEmergencyContactInfo
            // 
            this.tpEmergencyContactInfo.BackColor = System.Drawing.Color.White;
            this.tpEmergencyContactInfo.Controls.Add(this.btnBackToPersonalInfo);
            this.tpEmergencyContactInfo.Controls.Add(this.btnGoToSubscriptionInfo);
            this.tpEmergencyContactInfo.Controls.Add(this.ctrAddEditEmergencyContact1);
            this.tpEmergencyContactInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpEmergencyContactInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpEmergencyContactInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            this.tpEmergencyContactInfo.Location = new System.Drawing.Point(4, 39);
            this.tpEmergencyContactInfo.Name = "tpEmergencyContactInfo";
            this.tpEmergencyContactInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmergencyContactInfo.Size = new System.Drawing.Size(1014, 447);
            this.tpEmergencyContactInfo.TabIndex = 1;
            this.tpEmergencyContactInfo.Text = "Emegency Contact Info";
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
            // btnGoToSubscriptionInfo
            // 
            this.btnGoToSubscriptionInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGoToSubscriptionInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToSubscriptionInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGoToSubscriptionInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToSubscriptionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToSubscriptionInfo.ForeColor = System.Drawing.Color.Black;
            this.btnGoToSubscriptionInfo.Location = new System.Drawing.Point(895, 385);
            this.btnGoToSubscriptionInfo.Name = "btnGoToSubscriptionInfo";
            this.btnGoToSubscriptionInfo.Size = new System.Drawing.Size(95, 35);
            this.btnGoToSubscriptionInfo.TabIndex = 2;
            this.btnGoToSubscriptionInfo.Text = "Next";
            this.btnGoToSubscriptionInfo.UseVisualStyleBackColor = false;
            this.btnGoToSubscriptionInfo.Click += new System.EventHandler(this.btnGoToSubscriptionInfo_Click);
            // 
            // ctrAddEditEmergencyContact1
            // 
            this.ctrAddEditEmergencyContact1.BackColor = System.Drawing.Color.White;
            this.ctrAddEditEmergencyContact1.Location = new System.Drawing.Point(16, 17);
            this.ctrAddEditEmergencyContact1.Name = "ctrAddEditEmergencyContact1";
            this.ctrAddEditEmergencyContact1.Size = new System.Drawing.Size(511, 176);
            this.ctrAddEditEmergencyContact1.TabIndex = 0;
            // 
            // tpSubscriptionInfo
            // 
            this.tpSubscriptionInfo.BackColor = System.Drawing.Color.White;
            this.tpSubscriptionInfo.Controls.Add(this.btnGoToCurrentBelt);
            this.tpSubscriptionInfo.Controls.Add(this.btnBackToEmergencyContactInfo);
            this.tpSubscriptionInfo.Controls.Add(this.ctrAddEditSubscription1);
            this.tpSubscriptionInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.tpSubscriptionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpSubscriptionInfo.Location = new System.Drawing.Point(4, 39);
            this.tpSubscriptionInfo.Name = "tpSubscriptionInfo";
            this.tpSubscriptionInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpSubscriptionInfo.Size = new System.Drawing.Size(1014, 447);
            this.tpSubscriptionInfo.TabIndex = 2;
            this.tpSubscriptionInfo.Text = "Subscription Info";
            // 
            // btnGoToCurrentBelt
            // 
            this.btnGoToCurrentBelt.BackColor = System.Drawing.Color.Gainsboro;
            this.btnGoToCurrentBelt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToCurrentBelt.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnGoToCurrentBelt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoToCurrentBelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoToCurrentBelt.ForeColor = System.Drawing.Color.Black;
            this.btnGoToCurrentBelt.Location = new System.Drawing.Point(895, 385);
            this.btnGoToCurrentBelt.Name = "btnGoToCurrentBelt";
            this.btnGoToCurrentBelt.Size = new System.Drawing.Size(95, 35);
            this.btnGoToCurrentBelt.TabIndex = 2;
            this.btnGoToCurrentBelt.Text = "Next";
            this.btnGoToCurrentBelt.UseVisualStyleBackColor = false;
            this.btnGoToCurrentBelt.Click += new System.EventHandler(this.btnGoToCurrentBelt_Click);
            // 
            // btnBackToEmergencyContactInfo
            // 
            this.btnBackToEmergencyContactInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBackToEmergencyContactInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToEmergencyContactInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBackToEmergencyContactInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToEmergencyContactInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToEmergencyContactInfo.ForeColor = System.Drawing.Color.Black;
            this.btnBackToEmergencyContactInfo.Location = new System.Drawing.Point(20, 385);
            this.btnBackToEmergencyContactInfo.Name = "btnBackToEmergencyContactInfo";
            this.btnBackToEmergencyContactInfo.Size = new System.Drawing.Size(95, 35);
            this.btnBackToEmergencyContactInfo.TabIndex = 4;
            this.btnBackToEmergencyContactInfo.Text = "Back";
            this.btnBackToEmergencyContactInfo.UseVisualStyleBackColor = false;
            this.btnBackToEmergencyContactInfo.Click += new System.EventHandler(this.btnBackToEmergencyContactInfo_Click);
            // 
            // ctrAddEditSubscription1
            // 
            this.ctrAddEditSubscription1.BackColor = System.Drawing.Color.White;
            this.ctrAddEditSubscription1.Location = new System.Drawing.Point(16, 17);
            this.ctrAddEditSubscription1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrAddEditSubscription1.Name = "ctrAddEditSubscription1";
            this.ctrAddEditSubscription1.Size = new System.Drawing.Size(594, 196);
            this.ctrAddEditSubscription1.TabIndex = 0;
            // 
            // tpCurrentBelt
            // 
            this.tpCurrentBelt.BackColor = System.Drawing.Color.White;
            this.tpCurrentBelt.Controls.Add(this.btnBackToSubscriptionInfo);
            this.tpCurrentBelt.Controls.Add(this.cbCurrentBelt);
            this.tpCurrentBelt.Controls.Add(this.pictureBox2);
            this.tpCurrentBelt.Controls.Add(this.label3);
            this.tpCurrentBelt.Location = new System.Drawing.Point(4, 39);
            this.tpCurrentBelt.Name = "tpCurrentBelt";
            this.tpCurrentBelt.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrentBelt.Size = new System.Drawing.Size(1014, 447);
            this.tpCurrentBelt.TabIndex = 3;
            this.tpCurrentBelt.Text = "Current Belt";
            // 
            // btnBackToSubscriptionInfo
            // 
            this.btnBackToSubscriptionInfo.BackColor = System.Drawing.Color.Gainsboro;
            this.btnBackToSubscriptionInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackToSubscriptionInfo.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBackToSubscriptionInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackToSubscriptionInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackToSubscriptionInfo.ForeColor = System.Drawing.Color.Black;
            this.btnBackToSubscriptionInfo.Location = new System.Drawing.Point(20, 385);
            this.btnBackToSubscriptionInfo.Name = "btnBackToSubscriptionInfo";
            this.btnBackToSubscriptionInfo.Size = new System.Drawing.Size(95, 35);
            this.btnBackToSubscriptionInfo.TabIndex = 5;
            this.btnBackToSubscriptionInfo.Text = "Back";
            this.btnBackToSubscriptionInfo.UseVisualStyleBackColor = false;
            this.btnBackToSubscriptionInfo.Click += new System.EventHandler(this.btnBackToSubscriptionInfo_Click);
            // 
            // cbCurrentBelt
            // 
            this.cbCurrentBelt.BackColor = System.Drawing.Color.White;
            this.cbCurrentBelt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cbCurrentBelt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrentBelt.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCurrentBelt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(54)))), ((int)(((byte)(79)))));
            this.cbCurrentBelt.FormattingEnabled = true;
            this.cbCurrentBelt.ItemHeight = 20;
            this.cbCurrentBelt.Location = new System.Drawing.Point(278, 27);
            this.cbCurrentBelt.Name = "cbCurrentBelt";
            this.cbCurrentBelt.Size = new System.Drawing.Size(300, 28);
            this.cbCurrentBelt.TabIndex = 96;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Karate_Club.Properties.Resources.subscription_type_24;
            this.pictureBox2.Location = new System.Drawing.Point(224, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 98;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(29, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 97;
            this.label3.Text = "Current Belt Rank:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(70)))), ((int)(((byte)(36)))));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1084, 45);
            this.label2.TabIndex = 1;
            this.label2.Text = "Add New Member";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btnClose.Location = new System.Drawing.Point(436, 673);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 44);
            this.btnClose.TabIndex = 16;
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
            this.btnSave.Location = new System.Drawing.Point(582, 673);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 44);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "       Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // frmAddMember
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1108, 742);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tcMemberInfo);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddMember";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Member";
            this.Load += new System.EventHandler(this.frmAddMember_Load);
            this.tcMemberInfo.ResumeLayout(false);
            this.tpPersonalInfo.ResumeLayout(false);
            this.tpEmergencyContactInfo.ResumeLayout(false);
            this.tpSubscriptionInfo.ResumeLayout(false);
            this.tpCurrentBelt.ResumeLayout(false);
            this.tpCurrentBelt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tcMemberInfo;
        private System.Windows.Forms.TabPage tpPersonalInfo;
        private System.Windows.Forms.TabPage tpEmergencyContactInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tpSubscriptionInfo;
        private People.Controls.ctrAddEditPerson ctrAddEditPerson1;
        private Emergency_Contacts.ctrAddEditEmergencyContact ctrAddEditEmergencyContact1;
        private System.Windows.Forms.Button btnGoToEmergencyContactfo;
        private System.Windows.Forms.Button btnGoToSubscriptionInfo;
        private System.Windows.Forms.Button btnBackToPersonalInfo;
        private System.Windows.Forms.Button btnBackToEmergencyContactInfo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabPage tpCurrentBelt;
        private Subscriptions.ctrAddEditSubscription ctrAddEditSubscription1;
        private System.Windows.Forms.ComboBox cbCurrentBelt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGoToCurrentBelt;
        private System.Windows.Forms.Button btnBackToSubscriptionInfo;
    }
}