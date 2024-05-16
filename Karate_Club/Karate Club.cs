using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate_Club
{
    public partial class Karate_Club : Form
    {
        private Button _PreviousButton;
        public Karate_Club()
        {
            InitializeComponent();

            // 
            btnDashboard.BackColor = _ChangeColorBrightness(btnDashboard.BackColor, 0.1f);
            _PreviousButton = btnDashboard;
        }

        private Color _ChangeColorBrightness(Color color, float correctionFactor)
        {
            float red = color.R;
            float green = color.G;
            float blue = color.B;

            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }

            return Color.FromArgb(color.A, (int)red, (int)green, (int)blue);
        }

        private void ActiveButton(Button button)
        {
            _PreviousButton.BackColor = button.BackColor;
            pnlActive.Height = button.Height;
            pnlActive.Top = button.Top;

            button.BackColor = _ChangeColorBrightness(button.BackColor, 0.1f);
            _PreviousButton = button;
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

        private void btnSubscriptions_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

        private void btnBeltTest_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

        private void btnManageBelts_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActiveButton((Button)sender);
        }

    }
}
