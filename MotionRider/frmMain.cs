using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using MotionRider.Printing.Invoice_Printing;
using System.Windows.Forms;
using System.Xml;
using MotionRider.ServerDB;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;

namespace MotionRider
{
    public partial class frmMain : Form
    {
        #region Class Variables

        private MotionRiderDBDataContext _dbLocal = new MotionRiderDBDataContext();
        //private MotionRiderDBDataContext _dbServer = new MotionRiderDBDataContext(Settings.GetServerConnectionString());

        private AutoCompleteStringCollection _autoCompleteItems = new AutoCompleteStringCollection();

        private bool _isUploading = false;
        private bool _isUploadingFromInvoice = false;

        private TextBox _tb = new TextBox();

        //private TextBox _tbReceipt = new TextBox();
        private static int _check, _slushInvoiceRow, _motionInvoiceRow, _itemType;

        private const string _msgWarning = "App Warning!";
        private const string _msgInformation = "App Information!";

        //int _discount = 0;
        double _invoiceTotal = 0, _motionTotal = 0, _slushTotal = 0;

        private IEnumerable<motion_ride> _motionRides;
        private IEnumerable<slush> _slush;
        private IEnumerable<sales_closing> _salesClosings;

        //private IEnumerable<item> _items;

        //customer _customer = null;
        //private int _customerId = 0;
        //private bool _hasNewCustomer = false, _hasSomeCustomerCash = false;
        //private decimal _customerCash = 0;

        #region Class variables for invoice

        private List<slush_items_sale> _slushItems = new List<slush_items_sale>();
        private List<ticket_items_sale> _ticketItems = new List<ticket_items_sale>();

        private slush_items_sale _slushItem = null;
        private ticket_items_sale _ticketitem = null;
        //private List<InventoryBufferForInvoice> _buffer = new List<InventoryBufferForInvoice>();

        BackgroundWorker bw = null;

        #endregion

        #endregion


        public frmMain()
        {
            InitializeComponent();
        }

        public frmMain(frmLogin frm_)
        {

            InitializeComponent();
            frm_.Close();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            lblMainDate.Text = DateTime.Now.Date.ToString("dddd, MMMM d, yyyy");
            lblMainTime.Text = DateTime.Now.ToString("t");
            tmrUploadData.Enabled = true;
            //tbcMain.TabPages[3].

            RefreshAll();

        }

        internal void Load_Motion_Ride_Data()
        {
            _motionRides = from mr in _dbLocal.motion_rides
                           select mr;
        }

        internal void Load_Slush_Data()
        {
            _slush = from sl in _dbLocal.slushes
                     select sl;

        }

        private void Load_Sales_Closings()
        {
            _salesClosings = from sc in _dbLocal.sales_closings
                             select sc;
        }

        private void RefreshAll()
        {
            Load_Motion_Ride_Data();
            Load_Slush_Data();
            Load_Sales_Closings();

            LoadMotionDataGrid();
            LoadSlushDataGrid();
            LoadSalesDataGrid();
            LoadMotionSalesDataGrid();
            LoadSlushSalesDataGrid();

            ShowTotal();

            lblSlushNo.Text = "Current No: " + Settings1.GetSlushNo().ToString();
            lblMotionRiderNo.Text = "Current No: " + Settings1.GetTicketNo().ToString();
            btnRefreshAll.Enabled = true;


            #region Reset invoice form

            btnSubmitInvoice.Enabled = false;
            dgvMainTicket.Rows.Clear();
            dgvMainSlush.Rows.Clear();
            txtSalesCash.Text = string.Empty;
            txtSalesChange.Text = string.Empty;
            txtInvoiceTotalAmount.Text = string.Empty;

            _invoiceTotal = 0;
            _motionTotal = 0;
            _slushTotal = 0;

            _ticketItems.Clear();
            _slushItems.Clear();
            _slushInvoiceRow = 0;
            _motionInvoiceRow = 0;

            #endregion

        }

        private void On_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void On_about_Click(object sender, EventArgs e)
        {
            frmAbout frm = new frmAbout();
            frm.ShowDialog();

        }

        private void On_txtSalesCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void On_StrahlenStudiosSite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo("http://strahlenstudios.com/");
            Process.Start(sInfo);
        }

        #region Load data in grids

        internal void LoadMotionDataGrid()
        {
            try
            {
                dgvMotion.DataSource = from i in _dbLocal.motion_rides


                                       select new
                                       {
                                           i.motion_id,
                                           i.motion_name,
                                           i.motion_charges,



                                       };

                dgvMotion.Columns[0].HeaderText = "Motion Ride #";
                dgvMotion.Columns[0].Width = 200;

                dgvMotion.Columns[1].HeaderText = "Motion Name";
                dgvMotion.Columns[1].Width = 200;

                dgvMotion.Columns[2].HeaderText = "Charges";
                dgvMotion.Columns[2].Width = 200;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occured in Loading Motion Grid!");
            }
        }

        internal void LoadSlushDataGrid()
        {
            try
            {
                dgvSlush.DataSource = from i in _dbLocal.slushes


                                      select new
                                      {
                                          i.slush_id,
                                          i.slush_name,
                                          i.slush_price,

                                      };

                dgvSlush.Columns[0].HeaderText = "Ice Gola #";
                dgvSlush.Columns[0].Width = 200;

                dgvSlush.Columns[1].HeaderText = "Ice Gola Name";
                dgvSlush.Columns[1].Width = 200;

                dgvSlush.Columns[2].HeaderText = "Charges";
                dgvSlush.Columns[2].Width = 200;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occured in Loading Slush Grid!");
            }
        }

        private void LoadSalesDataGrid()
        {
            try
            {
                if (_salesClosings.Count() > 0)
                {

                    int id = _dbLocal.sales_closings.Max(e => e.closing_id);
                    sales_closing closing = _dbLocal.sales_closings.First(e => e.closing_id == id);


                    dgvSales.DataSource = from i in _dbLocal.sales
                                          where i.sales_id > closing.closing_end_sales_id
                                          select new
                                          {
                                              i.sales_id,
                                              i.sales_total_amount,
                                              i.sales_date,
                                              i.sales_time,
                                          };

                    dgvSales.Columns[0].HeaderText = "Sales #";
                    dgvSales.Columns[0].Width = 150;

                    dgvSales.Columns[1].HeaderText = "Total Amount";
                    dgvSales.Columns[1].Width = 300;

                    dgvSales.Columns[2].HeaderText = "Date";
                    dgvSales.Columns[2].Width = 170;

                    dgvSales.Columns[3].HeaderText = "Time";
                    dgvSales.Columns[3].Width = 200;

                }
                else
                {
                    dgvSales.DataSource = from i in _dbLocal.sales
                                          select new
                                          {
                                              i.sales_id,
                                              i.sales_total_amount,
                                              i.sales_date,
                                              i.sales_time,
                                          };

                    dgvSales.Columns[0].HeaderText = "Sales #";
                    dgvSales.Columns[0].Width = 150;

                    dgvSales.Columns[1].HeaderText = "Total Amount";
                    dgvSales.Columns[1].Width = 300;

                    dgvSales.Columns[2].HeaderText = "Date";
                    dgvSales.Columns[2].Width = 170;

                    dgvSales.Columns[3].HeaderText = "Time";
                    dgvSales.Columns[3].Width = 200;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Occured in Loading Sales Grid!");
            }
        }

        private void LoadMotionSalesDataGrid()
        {
            if (_salesClosings.Count() > 0)
            {
                int id = (int)_dbLocal.sales_closings.Max(e => e.closing_id);
                sales_closing closing = _dbLocal.sales_closings.First(e => e.closing_id == id);
                //dgvTicketSales.DataSource = from ts in _dbLocal.ticket_items_sales
                //                            where ts.sales_id > closing.closing_end_sales_id
                //                            select new
                //                            {
                //                                ts.sales_id,
                //                                MotionRideName = _dbLocal.motion_rides.First(r => r.motion_id == ts.motion_id).motion_name,
                //                                ts.ts_quantity,
                //                                ts.ts_unit_price,
                //                                ts.ts_total_amount,
                //                                Time = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_time,
                //                                Date = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_date,

                //                            };

                //dgvTicketSales.Columns[0].HeaderText = "Sales #";
                //dgvTicketSales.Columns[0].Width = 80;

                //dgvTicketSales.Columns[1].HeaderText = "Motion Ride Name";
                //dgvTicketSales.Columns[1].Width = 200;

                //dgvTicketSales.Columns[2].HeaderText = "Ticket Count";
                //dgvTicketSales.Columns[2].Width = 100;

                //dgvTicketSales.Columns[3].HeaderText = "Charges (Per Unit)";
                //dgvTicketSales.Columns[3].Width = 140;

                //dgvTicketSales.Columns[4].HeaderText = "Total Amount";
                //dgvTicketSales.Columns[4].Width = 120;

                //dgvTicketSales.Columns[5].HeaderText = "Time";
                //dgvTicketSales.Columns[5].Width = 110;

                //dgvTicketSales.Columns[6].HeaderText = "Date";
                //dgvTicketSales.Columns[6].Width = 110;



                // Separate ticket sales grid
                dgvSeparateTicketSales.DataSource = from ts in _dbLocal.ticket_items_sales
                                                    where ts.sales_id > closing.closing_end_sales_id
                                                    select new
                                                    {
                                                        ts.sales_id,
                                                        MotionRideName = _dbLocal.motion_rides.First(r => r.motion_id == ts.motion_id).motion_name,
                                                        ts.ts_quantity,
                                                        ts.ts_unit_price,
                                                        ts.ts_total_amount,
                                                        Time = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_time,
                                                        Date = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_date,

                                                    };

                dgvSeparateTicketSales.Columns[0].HeaderText = "Sales #";
                dgvSeparateTicketSales.Columns[0].Width = 80;

                dgvSeparateTicketSales.Columns[1].HeaderText = "Motion Ride Name";
                dgvSeparateTicketSales.Columns[1].Width = 200;

                dgvSeparateTicketSales.Columns[2].HeaderText = "Ticket Count";
                dgvSeparateTicketSales.Columns[2].Width = 100;

                dgvSeparateTicketSales.Columns[3].HeaderText = "Charges (Per Unit)";
                dgvSeparateTicketSales.Columns[3].Width = 140;

                dgvSeparateTicketSales.Columns[4].HeaderText = "Total Amount";
                dgvSeparateTicketSales.Columns[4].Width = 120;

                dgvSeparateTicketSales.Columns[5].HeaderText = "Time";
                dgvSeparateTicketSales.Columns[5].Width = 110;

                dgvSeparateTicketSales.Columns[6].HeaderText = "Date";
                dgvSeparateTicketSales.Columns[6].Width = 110;
            }
            else
            {
                //dgvTicketSales.DataSource = from ts in _dbLocal.ticket_items_sales
                //                            select new
                //                            {
                //                                ts.sales_id,
                //                                MotionRideName = _dbLocal.motion_rides.First(r => r.motion_id == ts.motion_id).motion_name,
                //                                ts.ts_quantity,
                //                                ts.ts_unit_price,
                //                                ts.ts_total_amount,
                //                                Time = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_time,
                //                                Date = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_date,

                //                            };

                //dgvTicketSales.Columns[0].HeaderText = "Sales #";
                //dgvTicketSales.Columns[0].Width = 80;

                //dgvTicketSales.Columns[1].HeaderText = "Motion Ride Name";
                //dgvTicketSales.Columns[1].Width = 200;

                //dgvTicketSales.Columns[2].HeaderText = "Ticket Count";
                //dgvTicketSales.Columns[2].Width = 100;

                //dgvTicketSales.Columns[3].HeaderText = "Charges (Per Unit)";
                //dgvTicketSales.Columns[3].Width = 140;

                //dgvTicketSales.Columns[4].HeaderText = "Total Amount";
                //dgvTicketSales.Columns[4].Width = 120;

                //dgvTicketSales.Columns[5].HeaderText = "Time";
                //dgvTicketSales.Columns[5].Width = 110;

                //dgvTicketSales.Columns[6].HeaderText = "Date";
                //dgvTicketSales.Columns[6].Width = 110;


                // Separate ticket sales grid
                dgvSeparateTicketSales.DataSource = from ts in _dbLocal.ticket_items_sales
                                                    select new
                                                    {
                                                        ts.sales_id,
                                                        MotionRideName = _dbLocal.motion_rides.First(r => r.motion_id == ts.motion_id).motion_name,
                                                        ts.ts_quantity,
                                                        ts.ts_unit_price,
                                                        ts.ts_total_amount,
                                                        Time = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_time,
                                                        Date = _dbLocal.sales.First(r => r.sales_id == ts.sales_id).sales_date,

                                                    };

                dgvSeparateTicketSales.Columns[0].HeaderText = "Sales #";
                dgvSeparateTicketSales.Columns[0].Width = 80;

                dgvSeparateTicketSales.Columns[1].HeaderText = "Motion Ride Name";
                dgvSeparateTicketSales.Columns[1].Width = 200;

                dgvSeparateTicketSales.Columns[2].HeaderText = "Ticket Count";
                dgvSeparateTicketSales.Columns[2].Width = 100;

                dgvSeparateTicketSales.Columns[3].HeaderText = "Charges (Per Unit)";
                dgvSeparateTicketSales.Columns[3].Width = 140;

                dgvSeparateTicketSales.Columns[4].HeaderText = "Total Amount";
                dgvSeparateTicketSales.Columns[4].Width = 120;

                dgvSeparateTicketSales.Columns[5].HeaderText = "Time";
                dgvSeparateTicketSales.Columns[5].Width = 110;

                dgvSeparateTicketSales.Columns[6].HeaderText = "Date";
                dgvSeparateTicketSales.Columns[6].Width = 110;
            }
        }

        private void LoadSlushSalesDataGrid()
        {
            if (_salesClosings.Count() > 0)
            {
                int id = _dbLocal.sales_closings.Max(e => e.closing_id);
                sales_closing closing = _dbLocal.sales_closings.First(e => e.closing_id == id);
                //dgvSlushSales.DataSource = from ss in _dbLocal.slush_items_sales
                //                           where ss.sales_id > closing.closing_end_sales_id
                //                           select new
                //                           {
                //                               ss.sales_id,
                //                               MotionRideName = _dbLocal.slushes.First(r => r.slush_id == ss.slush_id).slush_name,
                //                               ss.ss_quantity,
                //                               ss.ss_unit_price,
                //                               ss.ss_total_amount,
                //                               Time = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_time,
                //                               Date = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_date,

                //                           };

                //dgvSlushSales.Columns[0].HeaderText = "Sales #";
                //dgvSlushSales.Columns[0].Width = 80;

                //dgvSlushSales.Columns[1].HeaderText = "Ice Gola Name";
                //dgvSlushSales.Columns[1].Width = 200;

                //dgvSlushSales.Columns[2].HeaderText = "Ice Gola Quantity";
                //dgvSlushSales.Columns[2].Width = 125;

                //dgvSlushSales.Columns[3].HeaderText = "Price (Per Unit)";
                //dgvSlushSales.Columns[3].Width = 130;

                //dgvSlushSales.Columns[4].HeaderText = "Total Amount";
                //dgvSlushSales.Columns[4].Width = 120;

                //dgvSlushSales.Columns[5].HeaderText = "Time";
                //dgvSlushSales.Columns[5].Width = 105;

                //dgvSlushSales.Columns[6].HeaderText = "Date";
                //dgvSlushSales.Columns[6].Width = 105;



                // Separate ticket sales grid
                dgvSeparateIceGolaSales.DataSource = from ss in _dbLocal.slush_items_sales
                                                     where ss.sales_id > closing.closing_end_sales_id
                                                     select new
                                                     {
                                                         ss.sales_id,
                                                         MotionRideName = _dbLocal.slushes.First(r => r.slush_id == ss.slush_id).slush_name,
                                                         ss.ss_quantity,
                                                         ss.ss_unit_price,
                                                         ss.ss_total_amount,
                                                         Time = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_time,
                                                         Date = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_date,

                                                     };

                dgvSeparateIceGolaSales.Columns[0].HeaderText = "Sales #";
                dgvSeparateIceGolaSales.Columns[0].Width = 80;

                dgvSeparateIceGolaSales.Columns[1].HeaderText = "Ice Gola Name";
                dgvSeparateIceGolaSales.Columns[1].Width = 200;

                dgvSeparateIceGolaSales.Columns[2].HeaderText = "Ice Gola Quantity";
                dgvSeparateIceGolaSales.Columns[2].Width = 130;

                dgvSeparateIceGolaSales.Columns[3].HeaderText = "Price (Per Unit)";
                dgvSeparateIceGolaSales.Columns[3].Width = 125;

                dgvSeparateIceGolaSales.Columns[4].HeaderText = "Total Amount";
                dgvSeparateIceGolaSales.Columns[4].Width = 120;

                dgvSeparateIceGolaSales.Columns[5].HeaderText = "Time";
                dgvSeparateIceGolaSales.Columns[5].Width = 105;

                dgvSeparateIceGolaSales.Columns[6].HeaderText = "Date";
                dgvSeparateIceGolaSales.Columns[6].Width = 105;
            }
            else
            {
                //dgvSlushSales.DataSource = from ss in _dbLocal.slush_items_sales
                //                           select new
                //                           {
                //                               ss.sales_id,
                //                               MotionRideName = _dbLocal.slushes.First(r => r.slush_id == ss.slush_id).slush_name,
                //                               ss.ss_quantity,
                //                               ss.ss_unit_price,
                //                               ss.ss_total_amount,
                //                               Time = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_time,
                //                               Date = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_date,

                //                           };

                //dgvSlushSales.Columns[0].HeaderText = "Sales #";
                //dgvSlushSales.Columns[0].Width = 80;

                //dgvSlushSales.Columns[1].HeaderText = "Ice Gola Name";
                //dgvSlushSales.Columns[1].Width = 200;

                //dgvSlushSales.Columns[2].HeaderText = "Ice Gola Quantity";
                //dgvSlushSales.Columns[2].Width = 130;

                //dgvSlushSales.Columns[3].HeaderText = "Price (Per Unit)";
                //dgvSlushSales.Columns[3].Width = 125;

                //dgvSlushSales.Columns[4].HeaderText = "Total Amount";
                //dgvSlushSales.Columns[4].Width = 120;

                //dgvSlushSales.Columns[5].HeaderText = "Time";
                //dgvSlushSales.Columns[5].Width = 105;

                //dgvSlushSales.Columns[6].HeaderText = "Date";
                //dgvSlushSales.Columns[6].Width = 105;



                // Separate ice gola sales grid
                dgvSeparateIceGolaSales.DataSource = from ss in _dbLocal.slush_items_sales
                                                     select new
                                                     {
                                                         ss.sales_id,
                                                         MotionRideName = _dbLocal.slushes.First(r => r.slush_id == ss.slush_id).slush_name,
                                                         ss.ss_quantity,
                                                         ss.ss_unit_price,
                                                         ss.ss_total_amount,
                                                         Time = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_time,
                                                         Date = _dbLocal.sales.First(r => r.sales_id == ss.sales_id).sales_date,

                                                     };

                dgvSeparateIceGolaSales.Columns[0].HeaderText = "Sales #";
                dgvSeparateIceGolaSales.Columns[0].Width = 80;

                dgvSeparateIceGolaSales.Columns[1].HeaderText = "Ice Gola Name";
                dgvSeparateIceGolaSales.Columns[1].Width = 200;

                dgvSeparateIceGolaSales.Columns[2].HeaderText = "Ice Gola Quantity";
                dgvSeparateIceGolaSales.Columns[2].Width = 130;

                dgvSeparateIceGolaSales.Columns[3].HeaderText = "Price (Per Unit)";
                dgvSeparateIceGolaSales.Columns[3].Width = 125;

                dgvSeparateIceGolaSales.Columns[4].HeaderText = "Total Amount";
                dgvSeparateIceGolaSales.Columns[4].Width = 120;

                dgvSeparateIceGolaSales.Columns[5].HeaderText = "Time";
                dgvSeparateIceGolaSales.Columns[5].Width = 105;

                dgvSeparateIceGolaSales.Columns[6].HeaderText = "Date";
                dgvSeparateIceGolaSales.Columns[6].Width = 105;
            }
        }

        #endregion

        private void ShowTotal()
        {
            if (_salesClosings.Count() > 0)
            {
                decimal total = 0;
                int id = _dbLocal.sales_closings.Max(e => e.closing_id);
                sales_closing closing = _dbLocal.sales_closings.First(e => e.closing_id == id);

                // slush sales
                var slush_sales = from ss in _dbLocal.slush_items_sales
                                  where ss.sales_id > closing.closing_end_sales_id
                                  select ss;
                IEnumerator<slush_items_sale> slushItems = slush_sales.GetEnumerator();
                while (slushItems.MoveNext())
                {
                    total += slushItems.Current.ss_total_amount;
                }
                lblSeprateIceGolaTotal.Text = "Total: Rs. " + total.ToString();
                total = 0;

                // ticket sales
                var ticket_sales = from ts in _dbLocal.ticket_items_sales
                                   where ts.sales_id > closing.closing_end_sales_id
                                   select ts;
                IEnumerator<ticket_items_sale> ticketItems = ticket_sales.GetEnumerator();
                while (ticketItems.MoveNext())
                {
                    total += ticketItems.Current.ts_total_amount;
                }
                lblSeprateTicketTotal.Text = "Total: Rs. " + total.ToString();
                total = 0;

                // all sales
                var sales = from s in _dbLocal.sales
                            where s.sales_id > closing.closing_end_sales_id
                            select s;
                IEnumerator<sale> sale = sales.GetEnumerator();
                while (sale.MoveNext())
                {
                    total += sale.Current.sales_total_amount;
                }
                lblSalesTotal.Text = "Total: Rs. " + total.ToString();
                total = 0;
            }
            else
            {
            }
        }

        #region Invoice tab code starts

        #region Ticket grid events and user-defined functions starts

        #region Ticket grid events

        private void On_dgvMainTicket_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // code written to only take digits as input in item name and quantity fields.
            ValidateNameAndQualityFieldForNumbersInTicketGrid(e);
        }

        private void On_dgvMain_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Invoice Item Serial Numbers.
            if (e.RowIndex == _motionInvoiceRow && e.ColumnIndex == 1)
            {
                _motionInvoiceRow += 1;
            }
            for (int i = 0; i < dgvMainTicket.CurrentRow.Index + 1; i++)
            {
                dgvMainTicket.Rows[i].Cells[0].Value = (i + 1);
            }

            // Add and show the grand total when unit price column is in focus.
            if (e.ColumnIndex == 2)
            {
                AddnShowMotionRideGridTotalAmount();
                AddnShowInvoiceTotalAmount();
            }

            // Name Cell Validation.
            if (e.ColumnIndex == 3)
            {
                if (dgvMainTicket.CurrentRow.Cells[1].Value != null)
                {
                    var quant = dgvMainTicket.CurrentRow.Cells[2].Value;
                    if (quant == string.Empty)
                    {
                        MessageBox.Show(this, "Quantity Cannot be Empty.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int q = Convert.ToInt32(quant);
                        if (q == 0)
                            MessageBox.Show(this, "Quantity Cannot be 0.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void On_dgvMain_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Invoice Column 1 for ticket name.
            if (dgvMainTicket.CurrentCell.ColumnIndex == 1)
            {
                GetInvoiceItemName(e);
            }

            // Invoice Column 2 for ticket quantity.
            if (dgvMainTicket.CurrentCell.ColumnIndex == 2)
            {
                GetInvoiceItemQuantity(e);
            }
        }

        private void On_TicketGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvMainTicket.CurrentCell.ColumnIndex == 1 || dgvMainTicket.CurrentCell.ColumnIndex == 2)
            {
                _tb.AutoCompleteMode = AutoCompleteMode.None;
                if ((!(e.KeyChar >= '0') || !(e.KeyChar <= '9')) && !(e.KeyChar == '\b'))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Ticket grid user defined functions

        private void GetInvoiceItemName(DataGridViewCellEventArgs e)
        {
            var input = dgvMainTicket.CurrentRow.Cells[1].Value;
            if (input != null)
            {
                IEnumerator<motion_ride> motionRides = null;
                bool IsExist = false;
                string itemno = Convert.ToString(dgvMainTicket.CurrentRow.Cells[1].Value);

                if (e.ColumnIndex == 1 && (e.RowIndex == _motionInvoiceRow - 1 && e.RowIndex != _ticketItems.Count - 1))
                {
                    // Check if item is already exist.
                    foreach (ticket_items_sale item in _ticketItems)
                    {
                        if (itemno == item.motion_id.ToString())
                        {
                            MessageBox.Show(this, "This item is already exist in the invoice.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgvMainTicket.CurrentRow.Cells[2].Value = string.Empty;
                            return;
                        }
                    }

                    _ticketitem = new ticket_items_sale();
                    motionRides = _motionRides.GetEnumerator();
                    while (motionRides.MoveNext())
                    {
                        if (itemno == motionRides.Current.motion_id.ToString())
                        {
                            IsExist = true;
                            dgvMainTicket.CurrentRow.Cells[1].Value = motionRides.Current.motion_name;
                            dgvMainTicket.CurrentRow.Cells[2].Value = 0;
                            dgvMainTicket.CurrentRow.Cells[3].Value = motionRides.Current.motion_charges;
                            dgvMainTicket.CurrentRow.Cells[4].Value = 0;

                            _ticketitem.motion_id = motionRides.Current.motion_id;
                            _ticketitem.ts_quantity = 0;
                            _ticketitem.ts_unit_price = motionRides.Current.motion_charges;
                            _ticketitem.ts_total_amount = 0;
                            _ticketitem.motion_ride = motionRides.Current;

                            _ticketItems.Add(_ticketitem);
                            break;
                        }
                    }
                }
                else if (e.ColumnIndex == 1 && _ticketItems.Count > 0 && e.RowIndex != _motionInvoiceRow - 1 && _ticketItems.Count != e.RowIndex - 1)
                {
                    // Check if item is already exist.
                    foreach (ticket_items_sale item in _ticketItems)
                    {
                        if (itemno == item.motion_id.ToString())
                        {
                            MessageBox.Show(this, "This item is already exist in the invoice.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //motion_ride record = _motionRides.First(mr => mr.motion_id == _ticketItems[e.RowIndex].motion_id);
                            //_ticketItems[e.RowIndex].motion_ride = record;

                            dgvMainTicket.CurrentRow.Cells[1].Value = _ticketItems[e.RowIndex].motion_ride.motion_name;
                            dgvMainTicket.CurrentRow.Cells[2].Value = 0;
                            dgvMainTicket.CurrentRow.Cells[3].Value = _ticketItems[e.RowIndex].ts_unit_price;
                            dgvMainTicket.CurrentRow.Cells[4].Value = 0;
                            return;
                        }
                    }

                    motionRides = _motionRides.GetEnumerator();
                    while (motionRides.MoveNext())
                    {
                        if (itemno == motionRides.Current.motion_id.ToString())
                        {
                            IsExist = true;
                            dgvMainTicket.CurrentRow.Cells[1].Value = motionRides.Current.motion_name;
                            //dgvMainTicket.CurrentRow.Cells[2].Value = 0;
                            dgvMainTicket.CurrentRow.Cells[3].Value = motionRides.Current.motion_charges;

                            _ticketItems[e.RowIndex].motion_id = motionRides.Current.motion_id;

                            var quantity = dgvMainTicket.CurrentRow.Cells[2].Value;
                            if (quantity != null)
                                _ticketItems[e.RowIndex].ts_quantity = Convert.ToInt32(dgvMainTicket.CurrentRow.Cells[2].Value);
                            else
                                _ticketItems[e.RowIndex].ts_quantity = 0;

                            var unitprice = dgvMainTicket.CurrentRow.Cells[3].Value;
                            if (unitprice != null)
                                _ticketItems[e.RowIndex].ts_unit_price = Convert.ToInt32(dgvMainTicket.CurrentRow.Cells[3].Value);
                            else
                                _ticketItems[e.RowIndex].ts_unit_price = 0;

                            _ticketItems[e.RowIndex].ts_total_amount = Convert.ToDecimal(dgvMainTicket.CurrentRow.Cells[2].Value) * Convert.ToDecimal(dgvMainTicket.CurrentRow.Cells[3].Value);
                            dgvMainTicket.CurrentRow.Cells[4].Value = _ticketItems[e.RowIndex].ts_total_amount;
                        }
                    }
                }

                if (!IsExist)
                {
                    MessageBox.Show(this, "This item does not exist.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dgvMainTicket.CurrentRow.Cells[1].Value = string.Empty;
                }
            }
            else
            {
                MessageBox.Show(this, "Field cannot be empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void GetInvoiceItemQuantity(DataGridViewCellEventArgs e)
        {
            var input = dgvMainTicket.CurrentRow.Cells[2].Value;
            if (input != null)
            {
                int quantity = Convert.ToInt32(input);

                if (e.ColumnIndex == 2 && _ticketItems.Count > 0 && e.RowIndex == _motionInvoiceRow - 1)
                {
                    if (quantity > 0)
                    {
                        decimal priceperunit = Convert.ToDecimal(dgvMainTicket.CurrentRow.Cells[3].Value);
                        decimal totalamount = quantity * priceperunit;
                        dgvMainTicket.CurrentRow.Cells[4].Value = totalamount;

                        _ticketItems[e.RowIndex].ts_quantity = quantity;
                        _ticketItems[e.RowIndex].ts_total_amount = totalamount;

                        _motionInvoiceRow += 1;
                    }
                    else
                    {
                        MessageBox.Show(this, "Quantity Cannot be Empty or 0.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (e.ColumnIndex == 2 && _ticketItems.Count > 0 && e.RowIndex != _motionInvoiceRow - 1)
                {
                    if (quantity > 0)
                    {
                        decimal priceperunit = Convert.ToDecimal(dgvMainTicket.CurrentRow.Cells[3].Value);
                        decimal totalamount = quantity * priceperunit;
                        dgvMainTicket.CurrentRow.Cells[4].Value = totalamount;

                        _ticketItems[e.RowIndex].ts_quantity = quantity;
                        _ticketItems[e.RowIndex].ts_total_amount = totalamount;
                    }
                    else
                    {
                        MessageBox.Show(this, "Quantity Cannot be Empty or 0.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Field cannot be empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            AddnShowMotionRideGridTotalAmount();
            AddnShowInvoiceTotalAmount();
        }

        private void AddnShowMotionRideGridTotalAmount()
        {
            Double cash = 0.0;

            // Total for ticket.
            for (int i = 0; i < dgvMainTicket.Rows.Count; i++)
            {
                cash += Convert.ToDouble(dgvMainTicket.Rows[i].Cells[4].Value);
            }

            _motionTotal = cash;
        }

        private void ValidateNameAndQualityFieldForNumbersInTicketGrid(DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvMainTicket.CurrentRow.Index == 0)
            {
                if (dgvMainTicket.CurrentCell.ColumnIndex == 1 && (e.Control != null))
                {
                    //if (_check == 0)
                    {
                        _tb = (TextBox)e.Control;
                        _tb.KeyPress += On_TicketGrid_KeyPress;
                        //_check++;
                    }
                }
            }
        }

        #endregion

        // Ticket grid events and user-defined functions end. 
        #endregion

        #region Slush grid events and user defined functions starts

        #region slush grid events

        private void On_dgvMainSlush_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // code written to only take digits as input in item name and quantity fields.
            ValidateNameAndQualityFieldForNumbersInIceGolaGrid(e);
        }

        private void On_dgvMainSlush_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Invoice Column 1 for ticket name.
            if (dgvMainSlush.CurrentCell.ColumnIndex == 1)
            {
                GetSlushItemName(e);
            }

            // Invoice Column 2 for ticket quantity.
            if (dgvMainSlush.CurrentCell.ColumnIndex == 2)
            {
                GetSlushItemQuantity(e);
            }
        }

        private void On_dgvMainSlush_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            // Invoice Item Serial Numbers.
            if (e.RowIndex == _slushInvoiceRow && e.ColumnIndex == 1)
            {
                _slushInvoiceRow += 1;
            }
            for (int i = 0; i < dgvMainSlush.CurrentRow.Index + 1; i++)
            {
                dgvMainSlush.Rows[i].Cells[0].Value = (i + 1);
            }

            // Add and show the grand total when unit price column is in focus.
            if (e.ColumnIndex == 2)
            {
                AddnShowdgvMainSlushGridTotalAmount();
                AddnShowInvoiceTotalAmount();
            }

            // Name Cell Validation.
            if (e.ColumnIndex == 3)
            {
                if (dgvMainSlush.CurrentRow.Cells[1].Value != null)
                {
                    var quant = dgvMainSlush.CurrentRow.Cells[2].Value;
                    if (quant == string.Empty)
                    {
                        MessageBox.Show(this, "Quantity Cannot be Empty.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        int q = Convert.ToInt32(quant);
                        if (q == 0)
                            MessageBox.Show(this, "Quantity Cannot be 0.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void On_IceGolaGrid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvMainSlush.CurrentCell.ColumnIndex == 1 || dgvMainSlush.CurrentCell.ColumnIndex == 2)
            {
                _tb.AutoCompleteMode = AutoCompleteMode.None;
                if ((!(e.KeyChar >= '0') || !(e.KeyChar <= '9')) && !(e.KeyChar == '\b'))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion

        #region Slush userdefined functions

        private void GetSlushItemName(DataGridViewCellEventArgs e)
        {
            var input = dgvMainSlush.CurrentRow.Cells[1].Value;
            if (input != null)
            {
                IEnumerator<slush> slush = null;
                bool IsExist = false;
                string itemno = Convert.ToString(dgvMainSlush.CurrentRow.Cells[1].Value);

                if (e.ColumnIndex == 1 && (e.RowIndex == _slushInvoiceRow - 1 && e.RowIndex != _slushItems.Count - 1))
                {
                    // Check if item is already exist.
                    foreach (slush_items_sale item in _slushItems)
                    {
                        if (itemno == item.slush_id.ToString())
                        {
                            MessageBox.Show(this, "This item is already exist in the invoice.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgvMainSlush.CurrentRow.Cells[2].Value = string.Empty;
                            return;
                        }
                    }

                    _slushItem = new slush_items_sale();
                    slush = _slush.GetEnumerator();
                    while (slush.MoveNext())
                    {
                        if (itemno == slush.Current.slush_id.ToString())
                        {
                            IsExist = true;
                            dgvMainSlush.CurrentRow.Cells[1].Value = slush.Current.slush_name;
                            dgvMainSlush.CurrentRow.Cells[2].Value = 0;
                            dgvMainSlush.CurrentRow.Cells[3].Value = slush.Current.slush_price;
                            dgvMainSlush.CurrentRow.Cells[4].Value = 0;

                            _slushItem.slush_id = slush.Current.slush_id;
                            _slushItem.ss_quantity = 0;
                            _slushItem.ss_unit_price = slush.Current.slush_price;
                            _slushItem.ss_total_amount = 0;
                            _slushItem.slush = slush.Current;

                            _slushItems.Add(_slushItem);
                            break;
                        }
                    }
                }
                else if (e.ColumnIndex == 1 && _slushItems.Count > 0 && e.RowIndex != _slushInvoiceRow - 1 && _slushItems.Count != e.RowIndex - 1)
                {
                    // Check if item is already exist.
                    foreach (slush_items_sale item in _slushItems)
                    {
                        if (itemno == item.slush_id.ToString())
                        {
                            MessageBox.Show(this, "This item is already exist in the invoice.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dgvMainSlush.CurrentRow.Cells[1].Value = _slushItems[e.RowIndex].slush.slush_name;
                            dgvMainSlush.CurrentRow.Cells[2].Value = 0;
                            dgvMainSlush.CurrentRow.Cells[3].Value = _slushItems[e.RowIndex].ss_unit_price;
                            dgvMainSlush.CurrentRow.Cells[4].Value = 0;
                            return;
                        }
                    }

                    slush = _slush.GetEnumerator();
                    while (slush.MoveNext())
                    {
                        if (itemno == slush.Current.slush_id.ToString())
                        {
                            IsExist = true;
                            dgvMainSlush.CurrentRow.Cells[1].Value = slush.Current.slush_name;
                            //dgvMainSlush.CurrentRow.Cells[2].Value = 0;
                            dgvMainSlush.CurrentRow.Cells[3].Value = slush.Current.slush_price;

                            _slushItems[e.RowIndex].sales_id = slush.Current.slush_id;

                            var quantity = dgvMainSlush.CurrentRow.Cells[2].Value;
                            if (quantity != null)
                                _slushItems[e.RowIndex].ss_quantity = Convert.ToInt32(dgvMainSlush.CurrentRow.Cells[2].Value);
                            else
                                _slushItems[e.RowIndex].ss_quantity = 0;

                            var unitprice = dgvMainSlush.CurrentRow.Cells[3].Value;
                            if (unitprice != null)
                                _slushItems[e.RowIndex].ss_unit_price = Convert.ToInt32(dgvMainSlush.CurrentRow.Cells[3].Value);
                            else
                                _slushItems[e.RowIndex].ss_unit_price = 0;

                            _slushItems[e.RowIndex].ss_total_amount = Convert.ToDecimal(dgvMainSlush.CurrentRow.Cells[2].Value) * Convert.ToDecimal(dgvMainSlush.CurrentRow.Cells[3].Value);
                            dgvMainSlush.CurrentRow.Cells[4].Value = _slushItems[e.RowIndex].ss_total_amount;
                        }
                    }
                }

                if (!IsExist)
                {
                    MessageBox.Show(this, "This item does not exist.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    dgvMainSlush.CurrentRow.Cells[1].Value = string.Empty;
                }
            }
            else
            {
                MessageBox.Show(this, "Field cannot be empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void GetSlushItemQuantity(DataGridViewCellEventArgs e)
        {
            var input = dgvMainSlush.CurrentRow.Cells[2].Value;
            if (input != null)
            {
                int quantity = Convert.ToInt32(input);

                if (e.ColumnIndex == 2 && _slushItems.Count > 0 && e.RowIndex == _slushInvoiceRow - 1)
                {
                    if (quantity > 0)
                    {
                        decimal priceperunit = Convert.ToDecimal(dgvMainSlush.CurrentRow.Cells[3].Value);
                        decimal totalamount = quantity * priceperunit;
                        dgvMainSlush.CurrentRow.Cells[4].Value = totalamount;

                        _slushItems[e.RowIndex].ss_quantity = quantity;
                        _slushItems[e.RowIndex].ss_total_amount = totalamount;

                        _slushInvoiceRow += 1;
                    }
                    else
                    {
                        MessageBox.Show(this, "Quantity Cannot be Empty or 0.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (e.ColumnIndex == 2 && _slushItems.Count > 0 && e.RowIndex != _slushInvoiceRow - 1)
                {
                    if (quantity > 0)
                    {
                        decimal priceperunit = Convert.ToDecimal(dgvMainSlush.CurrentRow.Cells[3].Value);
                        decimal totalamount = quantity * priceperunit;
                        dgvMainSlush.CurrentRow.Cells[4].Value = totalamount;

                        _slushItems[e.RowIndex].ss_quantity = quantity;
                        _slushItems[e.RowIndex].ss_total_amount = totalamount;
                    }
                    else
                    {
                        MessageBox.Show(this, "Quantity Cannot be Empty or 0.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show(this, "Field cannot be empty.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            AddnShowdgvMainSlushGridTotalAmount();
            AddnShowInvoiceTotalAmount();
        }

        private void AddnShowdgvMainSlushGridTotalAmount()
        {
            Double cash = 0.0;
            for (int i = 0; i < dgvMainSlush.Rows.Count; i++)
            {
                cash += Convert.ToDouble(dgvMainSlush.Rows[i].Cells[4].Value);
            }
            _slushTotal = cash;
        }

        private void ValidateNameAndQualityFieldForNumbersInIceGolaGrid(DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvMainSlush.CurrentRow.Index == 0)
            {
                if (dgvMainSlush.CurrentCell.ColumnIndex == 1 && (e.Control != null))
                {
                    //if (_check == 0)
                    {
                        _tb = (TextBox)e.Control;
                        _tb.KeyPress += On_IceGolaGrid_KeyPress;
                        //_check++;
                    }
                }
            }
        }

        #endregion

        // Slush grid events and user defined functions ends
        #endregion

        private void AddnShowInvoiceTotalAmount()
        {
            _invoiceTotal = _motionTotal + _slushTotal;
            txtInvoiceTotalAmount.Text = Convert.ToString(_invoiceTotal);
        }

        // Invoice tab code ends.
        #endregion

        private void On_mstAddMotionRide_Click(object sender, EventArgs e)
        {
            frmMotionRide frm = new frmMotionRide("Add", this);
            frm.ShowDialog();
        }

        private void On_mstAddSlush_Click(object sender, EventArgs e)
        {

            frmSlush frm = new frmSlush("Add", this);
            frm.ShowDialog();


        }

        private void On_mstViewSlush_Click(object sender, EventArgs e)
        {
            //frmMotionRide frm = new frmMotionRide(0, "Edit Slush");
            //frm.ShowDialog();
            tbcMain.SelectedIndex = 5;
        }

        private void On_mstViewMotionRide_Click(object sender, EventArgs e)
        {
            //frmMotionRide frm = new frmMotionRide(0, "Edit Motion");
            //frm.ShowDialog();
            tbcMain.SelectedIndex = 4;
        }

        private void On_btnEdit_Click(object sender, EventArgs e)
        {
            var item = dgvMotion.SelectedRows[0].Cells[0].Value;
            if (item != null)
            {
                int id = Convert.ToInt32(dgvMotion.SelectedRows[0].Cells[0].Value);
                frmMotionRide frm = new frmMotionRide(id, "Edit", this);
                frm.ShowDialog();
            }
        }

        private void On_btnSlush_Click(object sender, EventArgs e)
        {
            var item = dgvSlush.SelectedRows[0].Cells[0].Value;
            if (item != null)
            {
                int id = Convert.ToInt32(dgvSlush.SelectedRows[0].Cells[0].Value);
                frmSlush frm = new frmSlush(id, "Edit", this);
                frm.ShowDialog();
            }
        }

        private void On_dgvSales_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = dgvSales.CurrentRow.Cells[0].Value;
            if (id != null)
            {
                frmSalesDetails frm = new frmSalesDetails(Convert.ToInt32(id));
                frm.ShowDialog();
            }
        }

        private void On_btnRefreshAll_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void On_btnSubmitInvoice_Click(object sender, EventArgs e)
        {
            btnSubmitInvoice.Enabled = false;
            btnRefreshAll.Enabled = false;

            if (_slushItems.Count > 0 || _ticketItems.Count > 0)
            {
                sale sale = new sale();
                if (_slushItems.Count > 0)
                {
                    sale.slush_items_sales.AddRange(_slushItems);
                    //Settings1.IncrementSlushNo();
                }

                if (_ticketItems.Count > 0)
                {
                    sale.ticket_items_sales.AddRange(_ticketItems);
                    //Settings1.IncrementTicketNo();
                }

                sale.sales_total_amount = Convert.ToDecimal(_invoiceTotal);
                sale.sales_date = DateTime.Now;
                sale.sales_time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                sale.outlet_id = 1;

                _dbLocal.sales.InsertOnSubmit(sale);
                try
                {
                    _dbLocal.SubmitChanges();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Resatart your application! \n\n" + ex.Message + "\n\nClick OK to Restart Application.", "Invoice Form Submit Button");
                    Application.Restart();
                }
                #region Print receipts starts

                if (Settings1.IsDoublePrintEnabled())
                {
                    if (_slushItems.Count > 0)
                    {
                        bw = new BackgroundWorker();
                        bw.DoWork += On_bwSlushCustomerCopy_DoWork;
                        bw.RunWorkerAsync(sale);
                    }

                    if (_ticketItems.Count > 0)
                    {
                        bw = new BackgroundWorker();
                        bw.DoWork += On_bwTicketCustomerCopy_DoWork;
                        bw.RunWorkerAsync(sale);
                    }
                    //System.Threading.Thread.Sleep(400);
                }

                if (_slushItems.Count > 0)
                {
                    bw = new BackgroundWorker();
                    bw.DoWork += On_bwSlushShopCopy_DoWork;
                    bw.RunWorkerAsync(sale);
                }

                if (_ticketItems.Count > 0)
                {
                    bw = new BackgroundWorker();
                    bw.DoWork += On_bwTicketShopCopy_DoWork;
                    bw.RunWorkerAsync(sale);
                }

                // double printing ends.
                #endregion

                //BackgroundWorker bworker = new BackgroundWorker();
                //bworker.DoWork += bworker_DoWork_UploadSales;
                //bworker.RunWorkerAsync();

                if (_slushItems.Count > 0)
                {
                    Settings1.IncrementSlushNo();
                }

                if (_ticketItems.Count > 0)
                {
                    Settings1.IncrementTicketNo();
                }

                RefreshAll();
            }
        }

        //void bworker_DoWork_UploadSales(object sender, DoWorkEventArgs e)
        //{
        //    bool uploaded = true;
        //    while (uploaded)
        //    {
        //        if (!_isUploading)
        //        {
        //            uploaded = false;
        //            _isUploadingFromInvoice = true;
        //            UploadData.UploadSalesOnServer();
        //            _isUploadingFromInvoice = false;
        //        }
        //        else
        //            continue;
        //    }
        //}

        //void bw_DoWork_Upload(object sender, DoWorkEventArgs e)
        //{
        //    try
        //    {
        //        sale sale = (sale)e.Argument;
        //        ServerDBDataContext _dbServer = new ServerDBDataContext(Settings.GetServerConnectionString());

        //        MotionRider.ServerDB.sale s = new ServerDB.sale();

        //        // assigning sales
        //        s.outlet_id = sale.outlet_id;
        //        s.sales_date = sale.sales_date;
        //        s.sales_time = sale.sales_time;
        //        s.sales_total_amount = sale.sales_total_amount;

        //        // assiging ticket item sales
        //        IEnumerator<ticket_items_sale> ticket_sale = sale.ticket_items_sales.GetEnumerator();
        //        while (ticket_sale.MoveNext())
        //        {
        //            MotionRider.ServerDB.ticket_items_sale ts = new ServerDB.ticket_items_sale();

        //            ts.motion_id = ticket_sale.Current.motion_id;
        //            ts.sales_id = sale.sales_id;
        //            ts.ts_quantity = ticket_sale.Current.ts_quantity;
        //            ts.ts_unit_price = ticket_sale.Current.ts_unit_price;
        //            ts.ts_total_amount = ticket_sale.Current.ts_total_amount;

        //            _dbServer.ticket_items_sales.InsertOnSubmit(ts);
        //            _dbServer.SubmitChanges();
        //        }

        //        // assiging slush item sales
        //        IEnumerator<slush_items_sale> slush_sale = sale.slush_items_sales.GetEnumerator();
        //        while (slush_sale.MoveNext())
        //        {
        //            MotionRider.ServerDB.slush_items_sale ss = new ServerDB.slush_items_sale();

        //            ss.slush_id = slush_sale.Current.sales_id;
        //            ss.sales_id = sale.sales_id;
        //            ss.ss_quantity = slush_sale.Current.ss_quantity;
        //            ss.ss_unit_price = slush_sale.Current.ss_unit_price;
        //            ss.ss_total_amount = slush_sale.Current.ss_total_amount;

        //            _dbServer.slush_items_sales.InsertOnSubmit(ss);
        //            _dbServer.SubmitChanges();
        //        }

        //        _dbServer.sales.InsertOnSubmit(s);
        //        _dbServer.SubmitChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(this, "Your application is not connected to internet. Please connect it so that it can upload data on server.", "Internet Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        void On_bwTicketCustomerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            sale sale = (sale)e.Argument;
            WriteReceipts wr = new WriteReceipts();
            wr.MakeTicketReceiptCustomerCopy(sale, Settings1.GetTicketNo());
        }

        void On_bwSlushCustomerCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            sale sale = (sale)e.Argument;
            WriteReceipts wr = new WriteReceipts();
            wr.MakeSlushReceiptCustomerCopy(sale);
        }

        void On_bwTicketShopCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            sale sale = (sale)e.Argument;
            WriteReceipts wr = new WriteReceipts();
            wr.MakeTicketReceiptShopCopy(sale, Settings1.GetTicketNo());
        }

        void On_bwSlushShopCopy_DoWork(object sender, DoWorkEventArgs e)
        {
            sale sale = (sale)e.Argument;
            WriteReceipts wr = new WriteReceipts();
            wr.MakeSlushReceiptShopCopy(sale);
        }

        private void On_txtSalesCash_Leave(object sender, EventArgs e)
        {
            if (txtInvoiceTotalAmount.Text != string.Empty)
            {
                if (txtInvoiceTotalAmount.Text != "0")
                {
                    if (txtSalesCash.Text != string.Empty)
                    {
                        double cash = Convert.ToDouble(txtSalesCash.Text);
                        if (cash >= _invoiceTotal)
                        {
                            txtSalesChange.Text = Convert.ToString(cash - _invoiceTotal);
                            btnSubmitInvoice.Enabled = true;
                            btnSubmitInvoice.Focus();
                        }
                        else
                        {
                            MessageBox.Show(this, "Cash cannot be less than total amount.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtSalesCash.Focus();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Cash cannot be empty.", _msgWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSalesCash.Focus();
                        return;
                    }
                }
            }
        }

        private void On_btnCloseSession_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(this, "Do you want to close the daily sales session?", "Motion Rider Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                bool isDone = false;
                IEnumerable<sale> sales = null;
                IEnumerable<sales_closing> closings = null;
                closings = from closing in _dbLocal.sales_closings
                           select closing;

                if (closings.Count() > 0)
                {
                    int maxId = (from min in closings
                                 select min.closing_id).Max();

                    sales_closing sc = _dbLocal.sales_closings.First(c => c.closing_id == maxId);

                    sales = from s in _dbLocal.sales
                            select s;

                    int smaxId = (from max in sales
                                  select max.sales_id).Max();

                    if (sc.closing_end_sales_id < smaxId)
                    {
                        //print ticket sale and icegola sale here.
                        WriteReports wr = new WriteReports();

                        var IceGolaSales = from i in _dbLocal.slush_items_sales
                                           where i.sales_id > sc.closing_end_sales_id && i.sales_id <= smaxId
                                           select i;
                        wr.MakeSlushReport(IceGolaSales);

                        var TickeySales = from t in _dbLocal.ticket_items_sales
                                          where t.sales_id > sc.closing_end_sales_id && t.sales_id <= smaxId
                                          select t;
                        wr.MakeTicketReport(TickeySales);

                        try
                        {
                            sales_closing scNew = new sales_closing();
                            scNew.closing_start_sales_id = sc.closing_end_sales_id + 1;
                            // check if the new start id exist in the sales table.
                            bool NotPresent = true;
                            while (NotPresent)
                            {
                                sale temp = (from t in _dbLocal.sales
                                             where t.sales_id == scNew.closing_start_sales_id
                                             select t).FirstOrDefault();

                                if (temp != null)
                                    NotPresent = false;
                                else
                                    scNew.closing_start_sales_id = scNew.closing_start_sales_id + 1;
                            }


                            scNew.closing_end_sales_id = smaxId;

                            decimal amount = (from amnt in sales
                                              where amnt.sales_id >= scNew.closing_start_sales_id && amnt.sales_id <= smaxId
                                              select amnt.sales_total_amount).Sum();

                            scNew.closing_total_amount = amount;

                            //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                            //XmlDocument xmlDoc = new XmlDocument();
                            //xmlDoc.Load(filename);
                            //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Login");
                            //string time = Convert.ToString(node.Attributes["Time"].Value);
                            //string date = Convert.ToString(node.Attributes["Date"].Value);

                            scNew.closing_login_date = Settings.App.Default.LoginDate;
                            scNew.closing_login_time = Settings.App.Default.LoginTime;

                            scNew.closing_logout_time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                            scNew.closing_logout_date = DateTime.Now.Date;

                            _dbLocal.sales_closings.InsertOnSubmit(scNew);
                            _dbLocal.SubmitChanges();
                            isDone = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!");
                        }
                    }
                }
                else
                {
                    sales = from s in _dbLocal.sales
                            select s;

                    int minId = (from min in sales
                                 select min.sales_id).Min();

                    int maxId = (from max in sales
                                 select max.sales_id).Max();

                    if (minId <= maxId)
                    {
                        sales_closing sc = new sales_closing();
                        sc.closing_start_sales_id = minId;
                        sc.closing_end_sales_id = maxId;

                        decimal amount = (from amnt in sales
                                          where amnt.sales_id >= minId && amnt.sales_id <= maxId
                                          select amnt.sales_total_amount).Sum();

                        sc.closing_total_amount = amount;

                        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                        //XmlDocument xmlDoc = new XmlDocument();
                        //xmlDoc.Load(filename);
                        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Login");
                        //string time = Convert.ToString(node.Attributes["Time"].Value);
                        //string date = Convert.ToString(node.Attributes["Date"].Value);

                        sc.closing_login_date = Settings.App.Default.LoginDate;
                        sc.closing_login_time = Settings.App.Default.LoginTime;

                        sc.closing_logout_time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                        sc.closing_logout_date = DateTime.Now.Date;

                        _dbLocal.sales_closings.InsertOnSubmit(sc);
                        _dbLocal.SubmitChanges();
                        isDone = true;
                    }
                }

                if (isDone)
                {
                    tmrUploadData.Enabled = false;
                    frmUploading frm = new frmUploading();
                    frm.ShowDialog();
                    tmrUploadData.Enabled = true;
                    tmrUploadData.Start();

                    //Settings1.ToggleApplicationStatus(false);
                    Settings1.ResetSlushNo();
                    Settings1.ResetTicketNo();

                    //Settings1.DoExit();
                    frmViewClosings frm1 = new frmViewClosings();
                    frm1.ShowDialog();

                    //Settings1.LogOutUser();
                    //Settings1.DoRestart();
                    //Settings.App.Default.IsFirstLogin = true;
                    //Settings.App.Default.Save();
                    Settings1.ResetToDefault();
                    
                    Application.Exit();
                }
            }
        }

        private void On_tsmReportsClosings_Click(object sender, EventArgs e)
        {
            frmViewClosings frm = new frmViewClosings();
            frm.ShowDialog();
        }

        #region Upload Data on Server

        private void On_tmrUploadData_Tick(object sender, EventArgs e)
        {
            // also refresh time and date.
            lblMainDate.Text = DateTime.Now.Date.ToString("dddd, MMMM d, yyyy");
            lblMainTime.Text = DateTime.Now.ToString("t");

            tmrUploadData.Enabled = false;
            BackgroundWorker bwUploader = new BackgroundWorker();
            bwUploader.DoWork += bw_DoWork_OnUpload;
            bwUploader.RunWorkerAsync();
            //bool uploaded = true;
            //while (uploaded)
            //{
            //    if (!_isUploadingFromInvoice)
            //    {
            //        uploaded = false;
            //        _isUploading = true;
            //        bwUploader.RunWorkerAsync();
            //    }
            //    else
            //        continue;
            //}
            bwUploader.RunWorkerCompleted += bw_RunWorkerCompleted;
        }

        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // show last upload time on the invoice form.
            lblShowLastUploadTime.Text = "Last Uploaded On: " + DateTime.Now.ToString("t");
            _isUploading = false;

            tmrUploadData.Enabled = true;
            tmrUploadData.Start();
        }

        void bw_DoWork_OnUpload(object sender, DoWorkEventArgs e)
        {
            Uploader();
        }

        private static void Uploader()
        {
           // Ping p = new Ping();
            try
            {
                //PingReply pr = p.Send("www.google.com");

                //if (pr.Status == IPStatus.Success)
                {
                    UploadData.UploadMotionRideOnServer();
                    UploadData.UploadSlushOnServer();
                    UploadData.UploadSalesOnServer();
                    UploadData.UploadSalesClosingsOnServer();
                }
                //else
                //{
                //    MessageBox.Show("Your application is not connected to internet. Please connect it so that it can upload data on server.", "Internet Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message + "\n\nYour application is not connected to internet. Please connect it so that it can upload data on server.", "Internet Connection Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // End uploading the data on server
        #endregion

        private void On_tsmSettings_Click(object sender, EventArgs e)
        {
            frmSettings frm = new frmSettings();
            frm.ShowDialog();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Settings1.ToggleApplicationStatus(false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Uploader();
        }

        private void On_btnPrintSale_Click(object sender, EventArgs e)
        {
            int smaxId = (from max in _dbLocal.sales
                          select max.sales_id).Max();

            int closingmaxId = (from max in _dbLocal.sales_closings
                                select max.closing_id).Max();
            sales_closing sc = _dbLocal.sales_closings.First(s => s.closing_id == closingmaxId);

            if (sc.closing_end_sales_id < smaxId)
            {
                //print ticket sale and icegola sale here.
                WriteReports wr = new WriteReports();

                var IceGolaSales = from i in _dbLocal.slush_items_sales
                                   where i.sales_id > sc.closing_end_sales_id && i.sales_id <= smaxId
                                   select i;
                wr.MakeSlushReport(IceGolaSales);

                var TickeySales = from t in _dbLocal.ticket_items_sales
                                  where t.sales_id > sc.closing_end_sales_id && t.sales_id <= smaxId
                                  select t;
                wr.MakeTicketReport(TickeySales);
            }
        }
    }
}