using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Karate_Club.Global_Classes
{
    internal static class clsUtilities
    {
        public static Color MainColor = Color.FromArgb(44, 54, 79);

        public static int RowsPerPage = 10;

        public static void CustomizeDataGridView(DataGridView dgv)
        {
            // Set Fill Mode to all cells
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Resize the row header column (the one used for selecting rows)
            dgv.RowHeadersWidth = 25;

            // Resize the column header heigth
            dgv.ColumnHeadersHeight = 40;

            // Disable visual styles for headers to allow custom styling
            dgv.EnableHeadersVisualStyles = false;


            // Customize the header style
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 9, FontStyle.Bold),
                BackColor = Color.FromArgb(44, 54, 79),
                ForeColor = Color.White,
                Alignment = DataGridViewContentAlignment.MiddleCenter // Center the text
            };
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;


            // customize the default cell styles as well
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Arial", 8, FontStyle.Regular),
                BackColor = Color.White,
                ForeColor = clsUtilities.MainColor,
            };
            dgv.DefaultCellStyle = cellStyle;

            // Customize row styles for alternating colors
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }

        public static Color ChangeColorBrightness(Color color, float correctionFactor)
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
    }
}
