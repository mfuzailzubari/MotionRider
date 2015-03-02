using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotionRider.Printing.Invoice_Printing
{
    class WriteReceipts
    {
        string _slushReceiptFileShopCopy = Environment.CurrentDirectory + @"\shop-slush-copy.dat";
        string _ticketReceiptFileShopCopy = Environment.CurrentDirectory + @"\shop-ticket-copy.dat";

        string _slushReceiptFileCustomerCopy = Environment.CurrentDirectory + @"\customer-slush-copy.dat";
        string _ticketReceiptFileCustomerCopy = Environment.CurrentDirectory + @"\customer-ticket-copy.dat";


        public void MakeSlushReceiptShopCopy(sale sale_)
        {
            MotionRiderDBDataContext _db_ = new MotionRiderDBDataContext();
            string receiptFile = string.Empty;

            // two receipts one for customer and second for kitchen
            //for (int loop = 0; loop < 2; loop++)
            //{

            # region Header
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                  Motion Rider                 \r\n";
            receiptFile += "               Mall Road, Murree               \r\n";
            receiptFile += "                   Shop Copy                   \r\n";
            receiptFile += "             Thanks for Visiting Us            \r\n";
            receiptFile += "   Date: " + sale_.sales_date.Date.ToString("dddd, d-MM-yyyy") + " Time: " + TimeSpan.FromTicks(sale_.sales_time.Ticks).ToString() + "   \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            receiptFile += " Sr.#  Product          Price   Qty  TotPrice  \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            #endregion


            int srsize = 6;
            int namesize = 17;
            int pricesize = 8;
            int qtysize = 6;
            int totsize = 11;

            int j = 1, templen = 0;
            string temp;
            decimal slushamount = 0;

            foreach (slush_items_sale item in sale_.slush_items_sales)
            {

                if (item != null)
                {
                    receiptFile += " ";
                    slush slush = _db_.slushes.First(e => e.slush_id == item.slush_id);

                    temp = j.ToString();
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
                    j++;

                    slushamount += item.ss_total_amount;
                }
            }

            receiptFile += "-----------------------------------------------\r\n";


            # region Show Total

            //receiptFile += "                      Total Amount: Rs." +  sale_.sales_total_amount.ToString() + "\r\n";
            receiptFile += "                     Total Amount: Rs." + slushamount.ToString() + "\r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                  Powered By                   \r\n";
            receiptFile += "        http://www.strahlenstudios.com         \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";

            #endregion

            //slushamount = 0;
            //}

            try
            {
                TextWriter tw = new StreamWriter(_slushReceiptFileShopCopy);
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
            RawPrinterHelper.SendFileToPrinter("Generic / Text Only", _slushReceiptFileShopCopy);
        }

        public void MakeTicketReceiptShopCopy(sale sale_, int ticketNo_)
        {
            MotionRiderDBDataContext _db_ = new MotionRiderDBDataContext();
            string receiptFile = string.Empty;

            foreach (ticket_items_sale item in sale_.ticket_items_sales)
            {
                //for (int i = 0; i < item.ts_quantity; i++)
                //{
                # region Header
                receiptFile += "                                               \r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                  Motion Rider                 \r\n";
                receiptFile += "               Mall Road, Murree               \r\n";
                receiptFile += "                   Shop Copy                   \r\n";
                receiptFile += "             Thanks for Visiting Us            \r\n";
                receiptFile += "                  Ticket #: " + ticketNo_ + "            \r\n";
                receiptFile += "   Date: " + sale_.sales_date.Date.ToString("dddd, d-MM-yyyy") + " Time: " + TimeSpan.FromTicks(sale_.sales_time.Ticks).ToString() + "   \r\n";
                receiptFile += "-----------------------------------------------\r\n";
                receiptFile += " Sr.#  Ticket           Price   Qty  TotPrice  \r\n";
                receiptFile += "-----------------------------------------------\r\n";
                #endregion


                int srsize = 6;
                int namesize = 17;
                int pricesize = 8;
                int qtysize = 6;
                int totsize = 11;

                int j = 1, templen = 0;
                string temp;

                //if (item != null)
                //{
                //    motion_ride motion_ride = _db_.motion_rides.First(e => e.motion_id == item.motion_id);
                //    receiptFile += "                " + motion_ride.motion_name + "          \r\n";
                //    receiptFile += "                    Ticket                      \r\n";
                //}

                if (item != null)
                {
                    receiptFile += " ";
                    motion_ride motion_ride = _db_.motion_rides.First(e => e.motion_id == item.motion_id);

                    temp = j.ToString();
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
                    j++;
                }


                receiptFile += "-----------------------------------------------\r\n";


                # region Show Total

                receiptFile += "                     Total Amount: Rs." + item.ts_total_amount.ToString() + "\r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                  Powered By                   \r\n";
                receiptFile += "        http://www.strahlenstudios.com         \r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                                               \r\n";

                #endregion
                //}
            }

            try
            {
                TextWriter tw = new StreamWriter(_ticketReceiptFileShopCopy);
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
            RawPrinterHelper.SendFileToPrinter("Generic / Text Only", _ticketReceiptFileShopCopy);
        }

        #region Customer Copy Invoice Print Design

        public void MakeTicketReceiptCustomerCopy(sale sale_, int ticketNo_)
        {
            MotionRiderDBDataContext _db_ = new MotionRiderDBDataContext();
            string receiptFile = string.Empty;

            foreach (ticket_items_sale item in sale_.ticket_items_sales)
            {
                //for (int i = 0; i < item.ts_quantity; i++)
                //{
                # region Header
                receiptFile += "                                               \r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                  Motion Rider                 \r\n";
                receiptFile += "               Mall Road, Murree               \r\n";
                receiptFile += "                 Customer Copy                 \r\n";
                receiptFile += "             Thanks for Visiting Us            \r\n";
                receiptFile += "                  Ticket #: " + ticketNo_ + "            \r\n";
                receiptFile += "   Date: " + sale_.sales_date.Date.ToString("dddd, d-MM-yyyy") + " Time: " + TimeSpan.FromTicks(sale_.sales_time.Ticks).ToString() + "   \r\n";
                receiptFile += "-----------------------------------------------\r\n";
                receiptFile += " Sr.#  Ticket           Price   Qty  TotPrice  \r\n";
                receiptFile += "-----------------------------------------------\r\n";
                #endregion


                int srsize = 6;
                int namesize = 17;
                int pricesize = 8;
                int qtysize = 6;
                int totsize = 11;

                int j = 1, templen = 0;
                string temp;

                //if (item != null)
                //{
                //    motion_ride motion_ride = _db_.motion_rides.First(e => e.motion_id == item.motion_id);
                //    receiptFile += "                " + motion_ride.motion_name + "          \r\n";
                //    receiptFile += "                    Ticket                      \r\n";
                //}

                if (item != null)
                {
                    receiptFile += " ";
                    motion_ride motion_ride = _db_.motion_rides.First(e => e.motion_id == item.motion_id);

                    temp = j.ToString();
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
                    j++;
                }


                receiptFile += "-----------------------------------------------\r\n";


                # region Show Total

                receiptFile += "                     Total Amount: Rs." + item.ts_total_amount.ToString() + "\r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                  Powered By                   \r\n";
                receiptFile += "        http://www.strahlenstudios.com         \r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                                               \r\n";
                receiptFile += "                                               \r\n";

                #endregion
                //}
            }

            try
            {
                TextWriter tw = new StreamWriter(_ticketReceiptFileCustomerCopy);
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
            RawPrinterHelper.SendFileToPrinter("Generic / Text Only", _ticketReceiptFileCustomerCopy);
        }
        
        public void MakeSlushReceiptCustomerCopy(sale sale_)
        {
            MotionRiderDBDataContext _db_ = new MotionRiderDBDataContext();
            string receiptFile = string.Empty;

            // two receipts one for customer and second for kitchen
            //for (int loop = 0; loop < 2; loop++)
            //{

            # region Header
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                  Motion Rider                 \r\n";
            receiptFile += "               Mall Road, Murree               \r\n";
            receiptFile += "                 Customer Copy                 \r\n";
            receiptFile += "             Thanks for Visiting Us            \r\n";
            receiptFile += "   Date: " + sale_.sales_date.Date.ToString("dddd, d-MM-yyyy") + " Time: " + TimeSpan.FromTicks(sale_.sales_time.Ticks).ToString() + "   \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            receiptFile += " Sr.#  Product          Price   Qty  TotPrice  \r\n";
            receiptFile += "-----------------------------------------------\r\n";
            #endregion


            int srsize = 6;
            int namesize = 17;
            int pricesize = 8;
            int qtysize = 6;
            int totsize = 11;

            int j = 1, templen = 0;
            string temp;
            decimal slushamount = 0;

            foreach (slush_items_sale item in sale_.slush_items_sales)
            {

                if (item != null)
                {
                    receiptFile += " ";
                    slush slush = _db_.slushes.First(e => e.slush_id == item.slush_id);

                    temp = j.ToString();
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
                    j++;

                    slushamount += item.ss_total_amount;
                }
            }

            receiptFile += "-----------------------------------------------\r\n";


            # region Show Total

            //receiptFile += "                      Total Amount: Rs." +  sale_.sales_total_amount.ToString() + "\r\n";
            receiptFile += "                     Total Amount: Rs." + slushamount.ToString() + "\r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                  Powered By                   \r\n";
            receiptFile += "        http://www.strahlenstudios.com         \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";
            receiptFile += "                                               \r\n";

            #endregion

            //slushamount = 0;
            //}

            try
            {
                TextWriter tw = new StreamWriter(_slushReceiptFileCustomerCopy);
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
            RawPrinterHelper.SendFileToPrinter("Generic / Text Only", _slushReceiptFileCustomerCopy);

        }

        #endregion

        //public void ClearReceiptFiles()
        //{
        //    // Clear slush receipt file
        //    TextWriter slushfile = new StreamWriter(_slushReceiptFile);
        //    // write a line of text to the file
        //    slushfile.WriteLine(string.Empty);
        //    // close the file stream
        //    slushfile.Close();

        //    // Clear ticket receipt file
        //    TextWriter ticketfile = new StreamWriter(_ticketReceiptFile);
        //    // write a line of text to the file
        //    ticketfile.WriteLine(string.Empty);
        //    // close the file stream
        //    ticketfile.Close();
        //}
    }
}
