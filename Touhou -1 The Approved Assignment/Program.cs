using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Touhou__1_The_Approved_Assignment
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
