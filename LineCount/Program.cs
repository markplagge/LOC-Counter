using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LineCount
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Very basic (and verbose) error handling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>For a discussion of top-level error handling see my blog entry at 
        /// http://richnewman.wordpress.com/2007/04/08/top-level-exception-handling-in-windows-forms-applications-part-1/
        /// </remarks>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleError(e.Exception);
        }

        internal static void HandleError(Exception e)
        {
            string message = e.Message + "\n\n";
            if (e.InnerException != null)
                message += "Inner exception:\n" + e.InnerException.Message + "\n\n";
            message += e.StackTrace;
            MessageBox.Show(message, "An error has occurred:");
        }
    }
}