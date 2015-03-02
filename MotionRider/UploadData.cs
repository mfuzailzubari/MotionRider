using MotionRider.ServerDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotionRider
{
    class UploadData
    {
        public static void UploadMotionRideOnServer()
        {
            ServerDBDataContext _dbServer = new ServerDBDataContext();
            MotionRiderDBDataContext _dbLocal = new MotionRiderDBDataContext();

            if (Settings.Uploading.Default.motion_id != 0)
            {
                //var local = from l in _dbLocal.motion_rides
                //            select l;
                //var server = from s in _dbServer.motion_rides
                //             select s;

                //if (local.Count() > server.Count())
                //{
                    int newId = Settings.Uploading.Default.motion_id;
                    IEnumerable<motion_ride> LocalMotionRides = from s in _dbLocal.motion_rides
                                                                where s.motion_id > newId
                                                                select s;

                    if (LocalMotionRides.Count() > 0)
                    {
                        IEnumerator<motion_ride> motionrides = LocalMotionRides.GetEnumerator();
                        while (motionrides.MoveNext())
                        {
                            MotionRider.ServerDB.motion_ride s = new ServerDB.motion_ride();

                            // assigning motion ride
                            s.motion_id = motionrides.Current.motion_id;
                            s.motion_name = motionrides.Current.motion_name;
                            s.motion_charges = motionrides.Current.motion_charges;

                            _dbServer.motion_rides.InsertOnSubmit(s);
                            _dbServer.SubmitChanges();

                            Settings.Uploading.Default.motion_id = motionrides.Current.motion_id;
                            Settings.Uploading.Default.Save();
                            //Settings1.SetMotionRideId(motionrides.Current.motion_id);
                        }
                    }
            //    }
            }
            else
            {
                IEnumerable<motion_ride> LocalMotionRides = from s in _dbLocal.motion_rides
                                                            select s;

                if (LocalMotionRides.Count() > 0)
                {
                    IEnumerator<motion_ride> motionrides = LocalMotionRides.GetEnumerator();
                    while (motionrides.MoveNext())
                    {
                        MotionRider.ServerDB.motion_ride s = new ServerDB.motion_ride();

                        // assigning motion ride
                        int iid = motionrides.Current.motion_id;
                        s.motion_id = iid;
                        s.motion_name = motionrides.Current.motion_name;
                        s.motion_charges = motionrides.Current.motion_charges;

                        _dbServer.ExecuteCommand("SET IDENTITY_INSERT motion_ride ON");
                        _dbServer.motion_rides.InsertOnSubmit(s);
                        _dbServer.ExecuteCommand("SET IDENTITY_INSERT motion_ride OFF");

                        _dbServer.SubmitChanges();

                        Settings.Uploading.Default.motion_id = motionrides.Current.motion_id;
                        Settings.Uploading.Default.Save();
                        //Settings1.SetMotionRideId(motionrides.Current.motion_id);
                    }

                }
            }
        }

        public static void UploadSlushOnServer()
        {
            ServerDBDataContext _dbServer = new ServerDBDataContext();
            MotionRiderDBDataContext _dbLocal = new MotionRiderDBDataContext();

            if (Settings.Uploading.Default.slush_id != 0)
            {
                //var local = from s in _dbLocal.slushes
                //            select s;
                //var server = from s in _dbServer.slushes
                //             select s;

                //if (local.Count() > server.Count())
                //{
                    int newId = Settings.Uploading.Default.slush_id;
                    IEnumerable<slush> LocalSlush = from s in _dbLocal.slushes
                                                    where s.slush_id > newId
                                                    select s;

                    if (LocalSlush.Count() > 0)
                    {
                        IEnumerator<slush> slush = LocalSlush.GetEnumerator();
                        while (slush.MoveNext())
                        {
                            MotionRider.ServerDB.slush s = new ServerDB.slush();

                            // assigning slush
                            s.slush_id = slush.Current.slush_id;
                            s.slush_name = slush.Current.slush_name;
                            s.slush_price = slush.Current.slush_price;

                            _dbServer.slushes.InsertOnSubmit(s);
                            _dbServer.SubmitChanges();

                            Settings.Uploading.Default.slush_id = slush.Current.slush_id;
                            Settings.Uploading.Default.Save();
                            //Settings1.SetSlushId(slush.Current.slush_id);
                        }
                    }
                //}
            }
            else
            {
                IEnumerable<slush> LocalSlush = from s in _dbLocal.slushes
                                                select s;

                if (LocalSlush.Count() > 0)
                {
                    IEnumerator<slush> slush = LocalSlush.GetEnumerator();
                    while (slush.MoveNext())
                    {
                        MotionRider.ServerDB.slush s = new ServerDB.slush();

                        // assigning slush
                        s.slush_id = slush.Current.slush_id;
                        s.slush_name = slush.Current.slush_name;
                        s.slush_price = slush.Current.slush_price;

                        _dbServer.slushes.InsertOnSubmit(s);
                        _dbServer.SubmitChanges();

                        Settings.Uploading.Default.slush_id = slush.Current.slush_id;
                        Settings.Uploading.Default.Save();
                        //Settings1.SetSlushId(slush.Current.slush_id);
                    }
                }
            }
        }

        public static void UploadSalesOnServer()
        {
            ServerDBDataContext _dbServer = new ServerDBDataContext();
            MotionRiderDBDataContext _dbLocal = new MotionRiderDBDataContext();

            try
            {
                if (Settings.Uploading.Default.sales_id != 0)
                {
                    //var local = from s in _dbLocal.sales
                    //            select s;
                    //var server = from s in _dbServer.sales
                    //             select s;

                    //if (local.Count() > server.Count())
                    //{
                        int newId = Settings.Uploading.Default.sales_id;
                        IEnumerable<sale> LocalSale = from s in _dbLocal.sales
                                                      where s.sales_id > newId
                                                      select s;

                        if (LocalSale.Count() > 0)
                        {
                            IEnumerator<sale> sale = LocalSale.GetEnumerator();
                            while (sale.MoveNext())
                            {
                                MotionRider.ServerDB.sale s = new ServerDB.sale();

                                // assigning sales
                                s.sales_id = sale.Current.sales_id;
                                s.outlet_id = sale.Current.outlet_id;
                                s.sales_date = sale.Current.sales_date;
                                s.sales_time = sale.Current.sales_time;
                                s.sales_total_amount = sale.Current.sales_total_amount;

                                // assiging ticket item sales
                                IEnumerator<ticket_items_sale> ticket_sale = sale.Current.ticket_items_sales.GetEnumerator();
                                while (ticket_sale.MoveNext())
                                {
                                    MotionRider.ServerDB.ticket_items_sale ts = new ServerDB.ticket_items_sale();

                                    ts.ts_id = ticket_sale.Current.ts_id;
                                    ts.motion_id = ticket_sale.Current.motion_id;
                                    ts.sales_id = sale.Current.sales_id;
                                    ts.ts_quantity = ticket_sale.Current.ts_quantity;
                                    ts.ts_unit_price = ticket_sale.Current.ts_unit_price;
                                    ts.ts_total_amount = ticket_sale.Current.ts_total_amount;

                                    _dbServer.ticket_items_sales.InsertOnSubmit(ts);
                                    //_dbServer.SubmitChanges();
                                }

                                // assiging slush item sales
                                IEnumerator<slush_items_sale> slush_sale = sale.Current.slush_items_sales.GetEnumerator();
                                while (slush_sale.MoveNext())
                                {
                                    MotionRider.ServerDB.slush_items_sale ss = new ServerDB.slush_items_sale();

                                    ss.ss_id = slush_sale.Current.ss_id;
                                    ss.slush_id = slush_sale.Current.slush_id;
                                    ss.sales_id = sale.Current.sales_id;
                                    ss.ss_quantity = slush_sale.Current.ss_quantity;
                                    ss.ss_unit_price = slush_sale.Current.ss_unit_price;
                                    ss.ss_total_amount = slush_sale.Current.ss_total_amount;

                                    _dbServer.slush_items_sales.InsertOnSubmit(ss);
                                    //_dbServer.SubmitChanges();
                                }

                                _dbServer.sales.InsertOnSubmit(s);
                                _dbServer.SubmitChanges();

                                // here is a change.
                                Settings.Uploading.Default.sales_id = sale.Current.sales_id;
                                Settings.Uploading.Default.Save();
                                //Settings1.SetSalesId(sale.Current.sales_id);
                                //break;
                            }
                        }
                    //}
                }
                else
                {
                    IEnumerable<sale> LocalSale = from s in _dbLocal.sales
                                                  select s;

                    if (LocalSale.Count() > 0)
                    {
                        IEnumerator<sale> sale = LocalSale.GetEnumerator();
                        while (sale.MoveNext())
                        {
                            MotionRider.ServerDB.sale s = new ServerDB.sale();

                            // assigning sales
                            s.sales_id = sale.Current.sales_id;
                            s.outlet_id = sale.Current.outlet_id;
                            s.sales_date = sale.Current.sales_date;
                            s.sales_time = sale.Current.sales_time;
                            s.sales_total_amount = sale.Current.sales_total_amount;

                            // assiging ticket item sales
                            IEnumerator<ticket_items_sale> ticket_sale = sale.Current.ticket_items_sales.GetEnumerator();
                            while (ticket_sale.MoveNext())
                            {
                                MotionRider.ServerDB.ticket_items_sale ts = new ServerDB.ticket_items_sale();

                                ts.ts_id = ticket_sale.Current.ts_id;
                                ts.motion_id = ticket_sale.Current.motion_id;
                                ts.sales_id = sale.Current.sales_id;
                                ts.ts_quantity = ticket_sale.Current.ts_quantity;
                                ts.ts_unit_price = ticket_sale.Current.ts_unit_price;
                                ts.ts_total_amount = ticket_sale.Current.ts_total_amount;

                                _dbServer.ticket_items_sales.InsertOnSubmit(ts);
                                //_dbServer.SubmitChanges();
                            }

                            // assiging slush item sales
                            IEnumerator<slush_items_sale> slush_sale = sale.Current.slush_items_sales.GetEnumerator();
                            while (slush_sale.MoveNext())
                            {
                                MotionRider.ServerDB.slush_items_sale ss = new ServerDB.slush_items_sale();

                                ss.ss_id = slush_sale.Current.ss_id;
                                ss.slush_id = slush_sale.Current.slush_id;
                                ss.sales_id = sale.Current.sales_id;
                                ss.ss_quantity = slush_sale.Current.ss_quantity;
                                ss.ss_unit_price = slush_sale.Current.ss_unit_price;
                                ss.ss_total_amount = slush_sale.Current.ss_total_amount;

                                _dbServer.slush_items_sales.InsertOnSubmit(ss);
                                //_dbServer.SubmitChanges();
                            }

                            _dbServer.sales.InsertOnSubmit(s);
                            _dbServer.SubmitChanges();

                            Settings.Uploading.Default.sales_id = sale.Current.sales_id;
                            Settings.Uploading.Default.Save();
                            //Settings1.SetSalesId(sale.Current.sales_id);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception occured in sales uploading.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void UploadSalesClosingsOnServer()
        {
            ServerDBDataContext _dbServer = new ServerDBDataContext();
            MotionRiderDBDataContext _dbLocal = new MotionRiderDBDataContext();

            if (Settings.Uploading.Default.closing_id != 0)
            {
                //var local = from s in _dbLocal.sales_closings
                //            select s;
                //var server = from s in _dbServer.sales_closings
                //             select s;

                //if (local.Count() > server.Count())
                //{
                    int newId = Settings.Uploading.Default.closing_id;
                    IEnumerable<sales_closing> LocalSalesClosings = from s in _dbLocal.sales_closings
                                                                    where s.closing_id > newId
                                                                    select s;

                    if (LocalSalesClosings.Count() > 0)
                    {
                        IEnumerator<sales_closing> sales_closing = LocalSalesClosings.GetEnumerator();
                        while (sales_closing.MoveNext())
                        {
                            MotionRider.ServerDB.sales_closing s = new ServerDB.sales_closing();

                            // assigning sales closings
                            s.closing_id = sales_closing.Current.closing_id;
                            s.closing_login_date = sales_closing.Current.closing_login_date;
                            s.closing_login_time = sales_closing.Current.closing_login_time;
                            s.closing_logout_date = sales_closing.Current.closing_logout_date;
                            s.closing_logout_time = sales_closing.Current.closing_logout_time;
                            s.closing_start_sales_id = sales_closing.Current.closing_start_sales_id;
                            s.closing_end_sales_id = sales_closing.Current.closing_end_sales_id;
                            s.closing_total_amount = sales_closing.Current.closing_total_amount;

                            _dbServer.sales_closings.InsertOnSubmit(s);
                            _dbServer.SubmitChanges();

                            // here are more changes
                            Settings.Uploading.Default.closing_id = sales_closing.Current.closing_id;
                            Settings.Uploading.Default.Save();
                        }                        
                    }
                //}
            }
            else
            {
                IEnumerable<sales_closing> LocalSalesClosings = from s in _dbLocal.sales_closings
                                                                select s;

                if (LocalSalesClosings.Count() > 0)
                {
                    IEnumerator<sales_closing> sales_closing = LocalSalesClosings.GetEnumerator();
                    while (sales_closing.MoveNext())
                    {
                        MotionRider.ServerDB.sales_closing s = new ServerDB.sales_closing();

                        // assigning sales closings
                        s.closing_id = sales_closing.Current.closing_id;
                        s.closing_login_date = sales_closing.Current.closing_login_date;
                        s.closing_login_time = sales_closing.Current.closing_login_time;
                        s.closing_logout_date = sales_closing.Current.closing_logout_date;
                        s.closing_logout_time = sales_closing.Current.closing_logout_time;
                        s.closing_start_sales_id = sales_closing.Current.closing_start_sales_id;
                        s.closing_end_sales_id = sales_closing.Current.closing_end_sales_id;
                        s.closing_total_amount = sales_closing.Current.closing_total_amount;

                        _dbServer.sales_closings.InsertOnSubmit(s);
                        _dbServer.SubmitChanges();

                        Settings.Uploading.Default.closing_id = sales_closing.Current.closing_id;
                        Settings.Uploading.Default.Save();
                    }
                }
            }
        }
    }
}
