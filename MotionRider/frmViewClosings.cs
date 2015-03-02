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
    public partial class frmViewClosings : Form
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();

        public frmViewClosings()
        {
            InitializeComponent();
        }

        private void On_frmView_Load(object sender, EventArgs e)
        {
            dgvViewClosings.DataSource = from sc in _db.sales_closings
                                         select new 
                                         {
                                             sc.closing_id,
                                             sc.closing_start_sales_id,
                                             sc.closing_end_sales_id,
                                             sc.closing_total_amount,
                                             sc.closing_login_time,
                                             sc.closing_login_date,
                                             sc.closing_logout_time,
                                             sc.closing_logout_date,
                                         };
            

            dgvViewClosings.Columns[0].HeaderText = "Sr. #";
            dgvViewClosings.Columns[0].Width = 65;

            dgvViewClosings.Columns[1].HeaderText = "Start Invoice #";
            dgvViewClosings.Columns[1].Width = 95;

            dgvViewClosings.Columns[2].HeaderText = "End Invoice #";
            dgvViewClosings.Columns[2].Width = 95;

            dgvViewClosings.Columns[3].HeaderText = "Total Amount";
            dgvViewClosings.Columns[3].Width = 95;

            dgvViewClosings.Columns[4].HeaderText = "Login Time";
            dgvViewClosings.Columns[4].Width = 95;

            dgvViewClosings.Columns[5].HeaderText = "Login Date";
            dgvViewClosings.Columns[5].Width = 95;

            dgvViewClosings.Columns[6].HeaderText = "LogOut Time";
            dgvViewClosings.Columns[6].Width = 95;

            dgvViewClosings.Columns[7].HeaderText = "LogOut Date";
            dgvViewClosings.Columns[7].Width = 95;
        }

        private void On_frmViewClosings_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void dgvViewClosings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            frmClosingDetails frm = new frmClosingDetails(Convert.ToInt32(dgvViewClosings.CurrentRow.Cells[0].Value));
            frm.Show();
        }
    }
}
