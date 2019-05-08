using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bliss_POS.AppCode;

namespace Bliss_POS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.AddMessageFilter(new BarcodeCatcher());
            Application.Run(new POSContext());
        }
    }
}
