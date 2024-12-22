using Karate_Club.Members;
using Karate_Club.People;
using System;
using System.Windows.Forms;

namespace Karate_Club
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Test());
            //Application.Run(new frmMain());
            //Application.Run(new frmEditPersonalInfo(1));
            //Application.Run(new frmAddMember());
            //Application.Run(new frmAddEditPeron());
            //Application.Run(new Test());
        }
    }
}
