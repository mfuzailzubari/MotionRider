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
    public partial class frmClosingDetails : Form
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();
        int _id = 0;

        public frmClosingDetails(int id_)
        {
            InitializeComponent();
            _id = id_;
        }

        private void On_frmClosingDetails_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void On_frmClosingDetails_Load(object sender, EventArgs e)
        {
            sales_closing closing = _db.sales_closings.First(a => a.closing_id == _id);

            try
            {
                var sales = from i in _db.sales
                            where i.sales_id >= closing.closing_start_sales_id && i.sales_id <= closing.closing_end_sales_id
                            select new
                            {
                                i.sales_id,
                                i.sales_total_amount,
                                i.sales_date,
                                i.sales_time,


                            };

                if (sales.Count() > 0)
                {
                    dgvAllSales.DataSource = sales;

                    dgvAllSales.Columns[0].HeaderText = "Sales #";
                    dgvAllSales.Columns[0].Width = 120;

                    dgvAllSales.Columns[1].HeaderText = "Total Amount Sold";
                    dgvAllSales.Columns[1].Width = 220;

                    dgvAllSales.Columns[2].HeaderText = "Date";
                    dgvAllSales.Columns[2].Width = 150;

                    dgvAllSales.Columns[3].HeaderText = "Time";
                    dgvAllSales.Columns[3].Width = 150;


                    lblSalesTotal.Text = "Total Amount: Rs. " + sales.Sum(s => s.sales_total_amount).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occured in Loading Slush Grid!");
            }



            var ticketsales = from ts in _db.ticket_items_sales
                              where ts.sales_id >= closing.closing_start_sales_id && ts.sales_id <= closing.closing_end_sales_id
                              select new
                              {
                                  ts.sales_id,
                                  MotionRideName = _db.motion_rides.First(r => r.motion_id == ts.motion_id).motion_name,
                                  ts.ts_quantity,
                                  ts.ts_unit_price,
                                  ts.ts_total_amount,
                                  Time = _db.sales.First(r => r.sales_id == ts.sales_id).sales_time,
                                  Date = _db.sales.First(r => r.sales_id == ts.sales_id).sales_date,

                              };

            if (ticketsales.Count() > 0)
            {
                dgvTicketSales.DataSource = ticketsales;

                dgvTicketSales.Columns[0].HeaderText = "Sales #";
                dgvTicketSales.Columns[0].Width = 90;

                dgvTicketSales.Columns[1].HeaderText = "Motion Ride Name";
                dgvTicketSales.Columns[1].Width = 180;

                dgvTicketSales.Columns[2].HeaderText = "Ticket Count";
                dgvTicketSales.Columns[2].Width = 100;

                dgvTicketSales.Columns[3].HeaderText = "Charges (Per Unit)";
                dgvTicketSales.Columns[3].Width = 130;

                dgvTicketSales.Columns[4].HeaderText = "Total Amount";
                dgvTicketSales.Columns[4].Width = 115;

                dgvTicketSales.Columns[5].HeaderText = "Time";
                dgvTicketSales.Columns[5].Width = 100;

                dgvTicketSales.Columns[6].HeaderText = "Date";
                dgvTicketSales.Columns[6].Width = 100;

                lblTicketTotal.Text = "Total Amount: Rs. " + ticketsales.Sum(s => s.ts_total_amount).ToString();
            }


            var slushsales = from ss in _db.slush_items_sales
                             where ss.sales_id >= closing.closing_start_sales_id && ss.sales_id <= closing.closing_end_sales_id
                             select new
                             {
                                 ss.sales_id,
                                 MotionRideName = _db.slushes.First(r => r.slush_id == ss.slush_id).slush_name,
                                 ss.ss_quantity,
                                 ss.ss_unit_price,
                                 ss.ss_total_amount,
                                 Time = _db.sales.First(r => r.sales_id == ss.sales_id).sales_time,
                                 Date = _db.sales.First(r => r.sales_id == ss.sales_id).sales_date,

                             };

            if (slushsales.Count() > 0)
            {
                dgvIceGolaSales.DataSource = slushsales;
                dgvIceGolaSales.Columns[0].HeaderText = "Sales #";
                dgvIceGolaSales.Columns[0].Width = 80;

                dgvIceGolaSales.Columns[1].HeaderText = "Ice Gola Name";
                dgvIceGolaSales.Columns[1].Width = 180;

                dgvIceGolaSales.Columns[2].HeaderText = "Ice Gola Quantity";
                dgvIceGolaSales.Columns[2].Width = 125;

                dgvIceGolaSales.Columns[3].HeaderText = "Price (Per Unit)";
                dgvIceGolaSales.Columns[3].Width = 120;

                dgvIceGolaSales.Columns[4].HeaderText = "Total Amount";
                dgvIceGolaSales.Columns[4].Width = 110;

                dgvIceGolaSales.Columns[5].HeaderText = "Time";
                dgvIceGolaSales.Columns[5].Width = 100;

                dgvIceGolaSales.Columns[6].HeaderText = "Date";
                dgvIceGolaSales.Columns[6].Width = 100;

                lblSlustTotal.Text = "Total Amount: Rs. " + slushsales.Sum(s => s.ss_total_amount).ToString();
            }
        }


    }
}
