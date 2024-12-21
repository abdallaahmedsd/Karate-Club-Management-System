using Karate_Club.Instructors;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Karate_Club
{
    public partial class frmMain : Form
    {
        private Button _PreviousButton;
        private Panel _PreviousPanel;
        public frmMain()
        {
            InitializeComponent();

            // Let the Dashboard Button to be the active button 
            _PreviousButton = btnDashboard;
            _PreviousPanel = pnlChildForm;
        }

        private void Karate_Club_Load(object sender, EventArgs e)
        {
            _ActiveScreen(_PreviousButton, new frmListMembers());
        }

        private void _ActiveButton(Button button)
        {
            _PreviousButton.BackColor = button.BackColor;
            pnlActive.Height = button.Height;
            pnlActive.Top = button.Top;
            button.BackColor = Color.FromArgb(255, 65, 74, 96);
            _PreviousButton = button;
        }

        // I need to know what is this code about!
        private void _ActivePanel(Panel panel)
        {
            _PreviousPanel.Visible = false;
            panel.Visible = true;
            _PreviousPanel = panel;
        }

        private void _ActiveScreen(Button button, Form form = null)
        {
            _ActiveButton(button);

            Form childForm = form;
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            pnlChildForm.Controls.Clear();
            pnlChildForm.Controls.Add(childForm);
            childForm.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender, new frmListMembers());
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender, new frmListMembers());
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender, new frmListInstructors());
        }

        private void btnSubscriptions_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender);
        }

        private void btnBeltTest_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender);
        }

        private void btnManageBelts_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            _ActiveScreen((Button)sender);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
