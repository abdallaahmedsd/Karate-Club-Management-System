using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Karate_Club.Global_Classes
{
    internal static class clsUtilities
    {
        public static Color MainColor = Color.FromArgb(44, 54, 79);

        public static int RowsPerPage = 10;

        public static DateTime MinimumValidAge = DateTime.Today.AddYears(-102);
       
        public static DateTime MaximumValidAge = DateTime.Today.AddYears(-2);

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

        public static bool IsValidEmail(string email)
        {
            // Define a regular expression pattern for a simple email validation
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static string GenerateGUID()
        {
            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();
        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error creating folder: " + ex.Message);
                    return false;
                }
            }

            return true;
        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;
        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            /* 
                this function will copy the image to the
                project images folder after renaming it
                with GUID with the same extension, then it will update the sourceFileName with the new name.
            */

            string DestinationFolder = @"P:\Projects\Karate Club\Images and Icons\Images\People Images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);
            }
            catch (IOException iox)
            {
                MessageBox.Show(iox.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }
    }
}
