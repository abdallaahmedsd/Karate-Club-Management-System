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
			this.button1 = new System.Windows.Forms.Button();
			this.ctrQualifications1 = new Karate_Club.Instructors.Controls.ctrQualifications();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button1.Location = new System.Drawing.Point(607, 596);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(178, 60);
			this.button1.TabIndex = 0;
			this.button1.Text = "Get";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click_2);
			// 
			// ctrQualifications1
			// 
			this.ctrQualifications1.BackColor = System.Drawing.Color.White;
			this.ctrQualifications1.Location = new System.Drawing.Point(305, 97);
			this.ctrQualifications1.Name = "ctrQualifications1";
			this.ctrQualifications1.Size = new System.Drawing.Size(538, 323);
			this.ctrQualifications1.TabIndex = 1;
			// 
			// button2
			// 
			this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.button2.Location = new System.Drawing.Point(334, 596);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(185, 60);
			this.button2.TabIndex = 2;
			this.button2.Text = "Select";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// Test
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1425, 683);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.ctrQualifications1);
			this.Controls.Add(this.button1);
			this.Name = "Test";
			this.Text = "Test";
			this.Load += new System.EventHandler(this.Test_Load);
			this.ResumeLayout(false);

        }

		#endregion

		private System.Windows.Forms.Button button1;
		private Instructors.Controls.ctrQualifications ctrQualifications1;
		private System.Windows.Forms.Button button2;
	}
}