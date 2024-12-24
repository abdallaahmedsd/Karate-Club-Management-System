namespace Karate_Club.Instructors.Controls
{
	partial class ctrSpecializations
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
			this.clbSpecializations = new System.Windows.Forms.CheckedListBox();
			this.SuspendLayout();
			// 
			// clbSpecializations
			// 
			this.clbSpecializations.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.clbSpecializations.FormattingEnabled = true;
			this.clbSpecializations.Location = new System.Drawing.Point(3, 3);
			this.clbSpecializations.Name = "clbSpecializations";
			this.clbSpecializations.Size = new System.Drawing.Size(450, 298);
			this.clbSpecializations.TabIndex = 5;
			// 
			// ctrSpecializations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.Controls.Add(this.clbSpecializations);
			this.Name = "ctrSpecializations";
			this.Size = new System.Drawing.Size(455, 303);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckedListBox clbSpecializations;
	}
}
