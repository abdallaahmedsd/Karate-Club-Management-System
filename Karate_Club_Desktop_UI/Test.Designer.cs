namespace Karate_Club
{
    partial class Test
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
            this.ctrMemberCard1 = new Karate_Club.Members.Controls.ctrMemberCard();
            this.SuspendLayout();
            // 
            // ctrMemberCard1
            // 
            this.ctrMemberCard1.BackColor = System.Drawing.Color.White;
            this.ctrMemberCard1.Location = new System.Drawing.Point(128, 69);
            this.ctrMemberCard1.Name = "ctrMemberCard1";
            this.ctrMemberCard1.Size = new System.Drawing.Size(1153, 522);
            this.ctrMemberCard1.TabIndex = 0;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 683);
            this.Controls.Add(this.ctrMemberCard1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Members.Controls.ctrMemberCard ctrMemberCard1;
    }
}