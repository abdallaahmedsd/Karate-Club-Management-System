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
            //Application.Run(new Test());
            Application.Run(new Karate_Club());
        }
    }
}
