using System;
using System.Collections.Generic;
using System.Linq;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotionRider
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
            //if (!Settings.IsApplicationRunning())
            //{
                //Settings1.ToggleApplicationStatus(false);
                //if (!Settings1.IsRestart())
                {
                    frmLogin fLogin = new frmLogin();
                    if (fLogin.ShowDialog() == DialogResult.OK)
                    {
                        Application.Run(new frmMain());
                    }
                    else
                    {
                        Application.Exit();
                    }
                    //Settings1.RevertExit();
                }
                //else
                //{
                //    Settings1.RevertRestart();
                //    Application.Run(new frmViewClosings());
                //}
            //}
            //else
            //{
            //    MessageBox.Show("Application is already running.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
