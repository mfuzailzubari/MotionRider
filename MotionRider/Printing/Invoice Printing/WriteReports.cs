using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotionRider.Printing.Invoice_Printing
{
    class WriteReports
    {
        string _slushReportFile = Environment.CurrentDirectory + @"\icegola-report.dat";
        string _ticketReportFile = Environment.CurrentDirectory + @"\ticket-report.dat";

        public void MakeSlushReport(IEnumerable<slush_items_sale> sale_)
        {
            MotionRiderDBDataContext _db_ = new MotionRiderDBDataContext();
            string receiptFile = string.Empty;
            decimal totamount = 0;

            # region Header
            receiptFile += "                                               \r\n";
            receiptFile += "                  Motion Rider                 \r\n";
            receiptFile += "               Mall Road, Murree               \r\n";
            receiptFile += "           IceGola Daily Sale Report           \r\n";
            receiptFile += "          Date: " + DateTime.Now.Date.ToString("dddd, d-MM-yyyy") + "       \r\n"; 
            receiptFile += "-----------------------------------------------\r\n";
            receiptFile += " Sale#  Product          Price   Qty TotPrice  \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            #endregion


            int srsize = 6;
            int namesize = 17;
            int pricesize = 8;
            int qtysize = 6;
            int totsize = 11;

            int templen = 0;
            string temp;

            foreach (slush_items_sale item in sale_)
            {

                if (item != null)
                {
                    receiptFile += " ";
                    slush slush = _db_.slushes.First(e => e.slush_id == item.slush_id);

                    temp = item.sales_id.ToString();
                    templen = temp.Length;
                    if (templen < srsize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < srsize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }

                    temp = slush.slush_name;
                    templen = temp.Length;
                    if (templen < namesize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < namesize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        temp = temp.Substring(0, namesize);
                        receiptFile += temp;
                    }

                    temp = item.ss_unit_price.ToString();
                    templen = temp.Length;
                    if (templen < pricesize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < pricesize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }

                    temp = item.ss_quantity.ToString();
                    templen = temp.Length;
                    if (templen < qtysize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < qtysize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }


                    temp = item.ss_total_amount.ToString();
                    templen = temp.Length;
                    if (templen < totsize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < totsize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }

                    receiptFile += "\r\n";

                    totamount += item.ss_total_amount;
                }
            }

            receiptFile += "-----------------------------------------------\r\n";


            # region Show Total

            receiptFile += "                     Total Amount: Rs." + totamount.ToString() + "\r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                  Powered By                   \r\n";
            receiptFile += "        http://www.strahlenstudios.com         \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";

            #endregion

            try
            {
                TextWriter tw = new StreamWriter(_slushReportFile);
                // write a line of text to the file
                tw.WriteLine(receiptFile);
                // close the file stream
                tw.Close();
                receiptFile = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occured in printing Ice Gola Receipt.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Send to printer.
            RawPrinterHelper.SendFileToPrinter("Generic / Text Only", _slushReportFile);

        }

        public void MakeTicketReport(IEnumerable<ticket_items_sale> sale_)
        {
            MotionRiderDBDataContext _db_ = new MotionRiderDBDataContext();
            string receiptFile = string.Empty;
            decimal totamount = 0;


            //for (int i = 0; i < item.ts_quantity; i++)
            //{
            # region Header
            receiptFile += "                                               \r\n";
            receiptFile += "                  Motion Rider                 \r\n";
            receiptFile += "               Mall Road, Murree               \r\n";
            receiptFile += "            Ticket Daily Sale Report           \r\n";
            receiptFile += "           Date: " + DateTime.Now.Date.ToString("dddd, d-MM-yyyy") + "       \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            receiptFile += " Sale#  Ticket           Price   Qty TotPrice  \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            #endregion


            int srsize = 6;
            int namesize = 17;
            int pricesize = 8;
            int qtysize = 6;
            int totsize = 11;

            foreach (ticket_items_sale item in sale_)
            {

                int templen = 0;
                string temp;

                if (item != null)
                {
                    receiptFile += " ";
                    motion_ride motion_ride = _db_.motion_rides.First(e => e.motion_id == item.motion_id);

                    temp = item.sales_id.ToString();
                    templen = temp.Length;
                    if (templen < srsize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < srsize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }

                    temp = motion_ride.motion_name;
                    templen = temp.Length;
                    if (templen < namesize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < namesize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        temp = temp.Substring(0, namesize - 1);
                        receiptFile += temp;
                    }

                    temp = item.ts_unit_price.ToString();
                    templen = temp.Length;
                    if (templen < pricesize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < pricesize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }

                    temp = item.ts_quantity.ToString();
                    templen = temp.Length;
                    if (templen < qtysize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < qtysize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }


                    temp = item.ts_total_amount.ToString();
                    templen = temp.Length;
                    if (templen < totsize)
                    {
                        receiptFile += temp;
                        temp = null;
                        for (int k = 0; k < totsize - templen; k++)
                        {
                            temp += " ";
                        }
                        receiptFile += temp;
                    }
                    else
                    {
                        receiptFile += temp;
                    }

                    receiptFile += "\r\n";
                }
                totamount += item.ts_total_amount;
            }
            receiptFile += "-----------------------------------------------\r\n";


            # region Show Total

            receiptFile += "                     Total Amount: Rs." + totamount.ToString() + "\r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                  Powered By                   \r\n";
            receiptFile += "        http://www.strahlenstudios.com         \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";

            #endregion

            try
            {
                TextWriter tw = new StreamWriter(_ticketReportFile);
                // write a line of text to the file
                tw.WriteLine(receiptFile);
                // close the file stream
                tw.Close();
                receiptFile = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error in Reading \"Ticket Receipt File\"", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // Send to printer.
            RawPrinterHelper.SendFileToPrinter("Generic / Text Only", _ticketReportFile);
        }
    }
}
