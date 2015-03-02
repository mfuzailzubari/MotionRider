using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotionRider
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void On_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "qwerty")
            {
                //if (Settings1.LoginUser())
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;  
                    //Application.Exit();
                    //Application.Run(new frmMain());
                    //frmMain frm = new frmMain(this);
                    //frm.Show();
                }
            }
            else
            {
                MessageBox.Show(this, "Wrong Password", "You have entered a wrong password.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void On_frmLogin_Load(object sender, EventArgs e)
        {
            if (Settings.App.Default.IsFirstLogin)
            {
                Settings1.RevertFirstLogin();
                Settings.App.Default.LoginDate = DateTime.Now.Date;
                Settings.App.Default.LoginTime = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                Settings.App.Default.Save();
            }
            //if (Settings1.IsLogin())
            //{
            //    DialogResult = System.Windows.Forms.DialogResult.OK;                             
            //}
        }
    }
}
