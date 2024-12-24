namespace Karate_Club.Instructors.Controls
{
	partial class ctrQualifications
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.clbQualifications = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// clbQualifications
			// 
			this.clbQualifications.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clbQualifications.FormattingEnabled = true;
			this.clbQualifications.Location = new System.Drawing.Point(3, 3);
			this.clbQualifications.Name = "clbQualifications";
			this.clbQualifications.Size = new System.Drawing.Size(450, 298);
			this.clbQualifications.TabIndex = 5;
			// 
			// ctrQualifications
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.clbQualifications);
			this.Name = "ctrQualifications";
			this.Size = new System.Drawing.Size(455, 303);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox clbQualifications;
	}
}
