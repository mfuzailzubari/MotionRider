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
    public partial class frmSalesDetails : Form
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();
        int _id = 0;

        public frmSalesDetails(int id_)
        {
            InitializeComponent();
            _id = id_;
        }

        private void On_frmSalesDetails_Load(object sender, EventArgs e)
        {
            Fetch_Data_in_Fields();
        }

        private void Fetch_Data_in_Fields()
        {
            sale sale = _db.sales.First(e => e.sales_id == _id);
            lblMainDate.Text = sale.sales_date.Date.ToString("dddd, MMMM d, yyyy");
            lblMainTime.Text = sale.sales_time.ToString();
            txtInvoiceTotalAmount.Text = sale.sales_total_amount.ToString();

            // make ticket table.
            DataTable tickettable = new DataTable();
            tickettable.Columns.Add("Sr No");
            tickettable.Columns.Add("Product");
            tickettable.Columns.Add("Quantity");
            tickettable.Columns.Add("Unit Price");
            tickettable.Columns.Add("Total Price");

            IEnumerator<ticket_items_sale> ticketItems = sale.ticket_items_sales.GetEnumerator();
            int j = 1;
            while (ticketItems.MoveNext())
            {
                motion_ride item = _db.motion_rides.First(a => a.motion_id == ticketItems.Current.motion_id);
                tickettable.Rows.Add(j, item.motion_name, ticketItems.Current.ts_quantity, item.motion_charges, ticketItems.Current.ts_total_amount);
                j++;
            }
            dgvMainTicket.DataSource = tickettable;

            dgvMainTicket.Columns[0].Width = 150;
            dgvMainTicket.Columns[1].Width = 250;
            dgvMainTicket.Columns[2].Width = 150;
            dgvMainTicket.Columns[3].Width = 150;
            dgvMainTicket.Columns[4].Width = 150;

            // make slush table.
            DataTable slushtable = new DataTable();
            slushtable.Columns.Add("Sr No");
            slushtable.Columns.Add("Product");
            slushtable.Columns.Add("Quantity");
            slushtable.Columns.Add("Unit Price");
            slushtable.Columns.Add("Total Price");

            IEnumerator<slush_items_sale> slushItems = sale.slush_items_sales.GetEnumerator();
            j = 1;
            while (slushItems.MoveNext())
            {
                slush item = _db.slushes.First(a => a.slush_id == slushItems.Current.slush_id);
                slushtable.Rows.Add(j, item.slush_name, slushItems.Current.ss_quantity, item.slush_price, slushItems.Current.ss_total_amount);
                j++;
            }
            dgvMainSlush.DataSource = slushtable;

            dgvMainSlush.Columns[0].Width = 150;
            dgvMainSlush.Columns[1].Width = 250;
            dgvMainSlush.Columns[2].Width = 150;
            dgvMainSlush.Columns[3].Width = 150;
            dgvMainSlush.Columns[4].Width = 150;
        }

        private void On_btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
