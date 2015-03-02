using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;

namespace MotionRider
{
    public partial class frmUploading : Form
    {
        public frmUploading()
        {
            InitializeComponent();
        }

        private void frmUploading_Shown(object sender, EventArgs e)
        {
            Ping p = new Ping();
            try
            {
                System.Threading.Thread.Sleep(600);
                progbarUploading.Value = 10;
                PingReply pr = p.Send("www.google.com");

                if (pr.Status == IPStatus.Success)
                {
                    progbarUploading.Value = 10;
                    UploadData.UploadMotionRideOnServer();
                    System.Threading.Thread.Sleep(400);
                    progbarUploading.Value += 20;
                    UploadData.UploadSlushOnServer();
                    progbarUploading.Value += 20;
                    System.Threading.Thread.Sleep(400);
                    UploadData.UploadSalesOnServer();
                    progbarUploading.Value += 20;
                    UploadData.UploadSalesClosingsOnServer();
                    System.Threading.Thread.Sleep(400);
                    progbarUploading.Value += 20;
                }
                else
                {
                    MessageBox.Show("Your application is not connected to internet. Please connect it so that it can upload data on server.", "Internet Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your application is not connected to internet. Please connect it so that it can upload data on server.", "Internet Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            System.Threading.Thread.Sleep(400);
            this.Close();
        }


    }
}
