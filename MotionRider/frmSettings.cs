using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace MotionRider
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void On_btnSubmit_Click(object sender, EventArgs e)
        {
            if (rbtnYes.Checked)
            {
                Settings1.ToggleDoublePrinting(true);
            }
            else if (rbtnNo.Checked)
            {
                Settings1.ToggleDoublePrinting(false);
            }
            MessageBox.Show("Settings Changed Successfully.", "Information!");
            this.Close();
        }

        private void On_btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_frmSettings_Load(object sender, EventArgs e)
        {
            if (Settings1.IsDoublePrintEnabled())
                rbtnYes.Checked = true;
            else
                rbtnNo.Checked = true;
        }

        
    }
}
