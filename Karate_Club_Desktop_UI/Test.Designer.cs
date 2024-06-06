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
            this.ctrAddEditSubscription1 = new Karate_Club.Subscriptions.ctrAddEditSubscription();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrAddEditSubscription1
            // 
            this.ctrAddEditSubscription1.BackColor = System.Drawing.Color.White;
            this.ctrAddEditSubscription1.Location = new System.Drawing.Point(270, 135);
            this.ctrAddEditSubscription1.Name = "ctrAddEditSubscription1";
            this.ctrAddEditSubscription1.Size = new System.Drawing.Size(582, 196);
            this.ctrAddEditSubscription1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(449, 402);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 85);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1425, 683);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrAddEditSubscription1);
            this.Name = "Test";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.Test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Subscriptions.ctrAddEditSubscription ctrAddEditSubscription1;
        private System.Windows.Forms.Button button1;
    }
}