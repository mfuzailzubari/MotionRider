using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MotionRider
{
    class Settings1
    {
        /// <summary>
        /// Get the server connection string from the settings file.
        /// </summary>
        /// <returns>string, connection string.</returns>
        //public static string GetServerConnectionString()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/ConnectionString");
        //        string value = node.Attributes["Server"].Value;
        //        if (value != string.Empty)
        //        {
        //            return value;
        //        }
        //        else
        //        {
        //            return null;
        //            //return "Data Source=204.93.178.45;Initial Catalog=motionrider;Integrated Security=True;User Id=strahlen_motionrider;Password=vivvtek@2;";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return null;
        //    }
        //}

        /// <summary>
        /// Get the local connection string from the settings file.
        /// </summary>
        /// <returns>string, connection string.</returns>
        //public static string GetLocalConnectionString()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/ConnectionString");
        //        string value = node.Attributes["Local"].Value;
        //        if (value != string.Empty)
        //        {
        //            return value;
        //        }
        //        else
        //        {
        //            return null;
        //            //return "Data Source=204.93.178.45;Initial Catalog=motionrider;Integrated Security=True;User Id=strahlen_motionrider;Password=vivvtek@2;";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return null;
        //    }
        //}

        /// <summary>
        /// Get current slush number of the session.
        /// </summary>
        /// <returns>int, slush no</returns>
        public static int GetSlushNo()
        {
            try
            {
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Slush");
                //int id = Convert.ToInt32(node.Attributes["SlushNo"].Value);
                //if (value != string.Empty)
                //{
                //    if (value == DateTime.Now.Date.ToString())
                //    {
                //        id = Convert.ToInt32(node.Attributes["CustomerNo"].Value);
                //    }
                //    else if (value != DateTime.Now.Date.ToString())
                //    {
                //        node.Attributes["Date"].Value = DateTime.Now.Date.ToString();
                //        node.Attributes["CustomerNo"].Value = "1";
                //        id = 1;
                //    }
                //}
                //else
                //{
                //    node.Attributes["Date"].Value = DateTime.Now.Date.ToString();
                //    node.Attributes["CustomerNo"].Value = "1";
                //    id = 1;
                //}
                //xmlDoc.Save(filename);
                return Settings.App.Default.IceGolaCounter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: GetSlushNo() \n" + ex.Message, "Settings File Error!");
                Application.Exit();
                return 0;
            }
        }

        /// <summary>
        /// Increment the current slush number of the session.
        /// </summary>
        public static void IncrementSlushNo()
        {
            try
            {
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Slush");
                //int id = Convert.ToInt32(node.Attributes["SlushNo"].Value);
                //id += 1;
                //node.Attributes["SlushNo"].Value = id.ToString();
                //if (value != string.Empty)
                //{
                //    if (value == DateTime.Now.Date.ToString())
                //    {
                //        id = Convert.ToInt32(node.Attributes["CustomerNo"].Value);
                //        id += 1;
                //        node.Attributes["CustomerNo"].Value = id.ToString();
                //    }
                //    else if (value != DateTime.Now.Date.ToString())
                //    {
                //        node.Attributes["Date"].Value = DateTime.Now.Date.ToString();
                //        node.Attributes["CustomerNo"].Value = "1";
                //        id = 1;
                //    }
                //}
                //else
                //{
                //    node.Attributes["Date"].Value = DateTime.Now.Date.ToString();
                //    node.Attributes["CustomerNo"].Value = "1";
                //    id = 1;
                //}
                //xmlDoc.Save(filename);
                //return id;
                Settings.App.Default.IceGolaCounter += 1;
                Settings.App.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: IncrementSlushNo() \n" + ex.Message, "Settings File Error!");
                Application.Exit();
            }
        }


        /// <summary>
        /// Get current motion ride number of the session.
        /// </summary>
        /// <returns>int, motion no</returns>
        public static int GetTicketNo()
        {
            try
            {
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/MotionRide");
                //int id = Convert.ToInt32(node.Attributes["MotionRideNo"].Value);
                ////xmlDoc.Save(filename);
                return Settings.App.Default.MotionRideCounter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: GetTicketNo() \n" + ex.Message, "Settings File Error!");
                return 1000;
            }
        }

        /// <summary>
        /// Increment the current motion ride number of the session.
        /// </summary>
        public static void IncrementTicketNo()
        {
            try
            {
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/MotionRide");
                //int id = Convert.ToInt32(node.Attributes["MotionRideNo"].Value);
                //id += 1;
                //node.Attributes["MotionRideNo"].Value = id.ToString();
                //xmlDoc.Save(filename);
                ////return id;

                Settings.App.Default.MotionRideCounter += 1;
                Settings.App.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fucntion: IncrementTicketNo() \n" + ex.Message, "Settings File Error!");
                Application.Exit();
            }
        }

        /// <summary>
        /// Reset the motion ride ticket no.
        /// </summary>
        public static void ResetTicketNo()
        {
            try
            {
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/MotionRide");
                ////int id = Convert.ToInt32(node.Attributes["MotionRideNo"].Value);
                //int id = 0;
                //node.Attributes["MotionRideNo"].Value = id.ToString(); ;
                //xmlDoc.Save(filename);
                ////return id;

                Settings.App.Default.MotionRideCounter = 0;
                Settings.App.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: ResetTicketNo() \n" + ex.Message, "Settings File Error!");
                Application.Exit();
            }
        }

        /// <summary>
        /// Reset the slush no.
        /// </summary>
        public static void ResetSlushNo()
        {
            try
            {
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Slush");
                ////int id = Convert.ToInt32(node.Attributes["MotionRideNo"].Value);
                //int id = 0;
                //node.Attributes["SlushNo"].Value = id.ToString(); ;
                //xmlDoc.Save(filename);

                Settings.App.Default.IceGolaCounter = 0;
                Settings.App.Default.Save();
                //return id;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: ResetSlushNo() \n" + ex.Message, "Settings File Error!");
                Application.Exit();
            }
        }

        /// <summary>
        /// Check whether the user is login.
        /// </summary>
        //public static bool IsLogin()
        //{
        //    try
        //    {
        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Login");
        //        //string IsLogin = Convert.ToString(node.Attributes["IsLogin"].Value);
        //        //if (IsLogin == string.Empty)
        //        //{
        //        //    node.Attributes["IsLogin"].Value = "False";
        //        //    xmlDoc.Save(filename);
        //        //    return false;
        //        //}
        //        //else if (IsLogin == "True")
        //        //{
        //        //    return true;
        //        //}
        //        //return false;
        //        return Settings.App.Default.IsLogin;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: IsLogin() \n" + ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Login the user into the system.
        /// </summary>
        //public static bool LoginUser()
        //{
        //    try
        //    {
        //        Settings.App.Default.IsLogin = true;
        //        Settings.App.Default.Save();
        //        return true;

        //        //MotionRiderDBDataContext _db = new MotionRiderDBDataContext();

        //        //IEnumerable<sale> sales = from s in _db.sales
        //        //                          select s;

        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Login");
        //        //node.Attributes["IsLogin"].Value = "True";
        //        //node.Attributes["Date"].Value = DateTime.Now.Date.ToString();
        //        //string time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToString();
        //        //node.Attributes["Time"].Value = time;

        //        //if (sales.Count() > 0)
        //        //{
        //        //    int maxId = (from max in sales
        //        //                 select max.sales_id).Max();
        //        //    maxId = maxId + 1;
        //        //    node.Attributes["StartInvoiceNo"].Value = maxId.ToString();
        //        //}
        //        //else
        //        //{
        //        //    node.Attributes["StartInvoiceNo"].Value = "0";
        //        //}

        //        //xmlDoc.Save(filename);
        //        //return true;
        //        //string IsLogin = Convert.ToString(node.Attributes["IsLogin"].Value);
        //        //if (IsLogin == string.Empty)
        //        //{
        //        //    node.Attributes["IsLogin"].Value = "False";
        //        //    return false;
        //        //}
        //        //else if (IsLogin == "True")
        //        //{
        //        //    xmlDoc.Save(filename);
        //        //    return true;
        //        //}
        //        //return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: LoginUser() \n" + ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return false;
        //    }
        //}

        /// <summary>
        /// Logout the user from the system.
        /// </summary>
        //public static void LogOutUser()
        //{
        //    try
        //    {
        //        Settings.App.Default.IsLogin = false;
        //        Settings.App.Default.IsFirstLogin = true;

        //        Settings.App.Default.Save();

        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Login");
        //        //node.Attributes["IsLogin"].Value = "False";
        //        //node.Attributes["Date"].Value = DateTime.Now.Date.ToString();
        //        //string time = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second).ToString();
        //        //node.Attributes["Time"].Value = time;
        //        //xmlDoc.Save(filename);
        //        //return true;
        //        //string IsLogin = Convert.ToString(node.Attributes["IsLogin"].Value);
        //        //if (IsLogin == string.Empty)
        //        //{
        //        //    node.Attributes["IsLogin"].Value = "False";
        //        //    return false;
        //        //}
        //        //else if (IsLogin == "True")
        //        //{
        //        //    xmlDoc.Save(filename);
        //        //    return true;
        //        //}
        //        //return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: LogOutUser() \n" + ex.Message, "Settings File Error!");
        //        Application.Exit();
        //    }
        //}

        /// <summary>
        /// Make the app to change the status of restart.
        /// Do IsRestart = false;
        /// </summary>
        //public static void RevertRestart()
        //{
        //    try
        //    {
        //        Settings.App.Default.IsRestart = false;
        //        Settings.App.Default.Save();
        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Restart");
        //        //node.Attributes["IsRestart"].Value = "False";
        //        //xmlDoc.Save(filename);
        //        //return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: RevertRestart() \n" + ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        //return false;
        //    }
        //}

        /// <summary>
        /// Make the app to restart.
        /// </summary>
        //public static void DoRestart()
        //{
        //    try
        //    {
        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Restart");
        //        //node.Attributes["IsRestart"].Value = "True";
        //        //xmlDoc.Save(filename);
        //        //return false;

        //        Settings.App.Default.IsRestart = true;
        //        Settings.App.Default.Save();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: DoRestart() \n" + ex.Message, "Settings File Error!");
        //        Application.Exit();
        //    }
        //}

        /// <summary>
        /// Check for the restart.
        /// </summary>
        //public static bool IsRestart()
        //{
        //    try
        //    {
        //        return Settings.App.Default.IsRestart;
        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/Restart");
        //        //string IsRestart = Convert.ToString(node.Attributes["IsRestart"].Value);
        //        //if (IsRestart == string.Empty)
        //        //{
        //        //    node.Attributes["IsRestart"].Value = "False";
        //        //    xmlDoc.Save(filename);
        //        //    return false;
        //        //}
        //        //else if (IsRestart == "True")
        //        //{
        //        //    return true;
        //        //}
        //        //return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: IsRestart() \n" + ex.Message, "Settings File Error!");
        //        //Application.Exit();
        //        return false;
        //    }
        //}

        public static void ToggleDoublePrinting(bool toggle)
        {
            try
            {
                Settings.Printing.Default.IsDoublePrintEnabled = toggle;
                Settings.Printing.Default.Save();
                //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.Load(filename);
                //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/PrintingOptions");
                //if (toggle)
                //{
                //    node.Attributes["DoublePrintEnabled"].Value = "True";
                //}
                //else
                //{
                //    node.Attributes["DoublePrintEnabled"].Value = "False";
                //}
                //xmlDoc.Save(filename);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: ToggleDoublePrinting() \n" + ex.Message, "Settings File Error!");
            }
        }

        public static bool IsDoublePrintEnabled()
        {
            try
            {
                return Settings.Printing.Default.IsDoublePrintEnabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Function: IsDoublePrintEnabled() \n" + ex.Message, "Settings File Error!");
                return false;
            }
        }

        #region Settings to upload data on the server.

        /// <summary>
        /// This function returns the sales table id to which server upload will start.
        /// </summary>
        /// <returns>int, Id to which start upload.</returns>
        //public static int GetSalesId()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        string sales = Convert.ToString(node.Attributes["sales"].Value);
        //        if (sales == string.Empty || sales == "0")
        //        {
        //            node.Attributes["sales"].Value = "0";
        //            xmlDoc.Save(filename);
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(sales);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return 0;
        //    }
        //}

        /// <summary>
        /// This function sets the new sales id to which the server upload will start next time.
        /// </summary>
        /// <param name="id_">The sales Id which have to save in settings file.</param>
        //public static void SetSalesId(int id_)
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        node.Attributes["sales"].Value = id_.ToString();
        //        xmlDoc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //    }
        //}

        /// <summary>
        /// This function returns the ticket_items_sales table id to which server upload will start.
        /// </summary>
        /// <returns>int, Id to which start upload.</returns>
        //public static int GetTicketSalesItemId()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        string sales = Convert.ToString(node.Attributes["ticket_items_sales"].Value);
        //        if (sales == string.Empty || sales == "0")
        //        {
        //            node.Attributes["ticket_items_sales"].Value = "0";
        //            xmlDoc.Save(filename);
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(sales);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return 0;
        //    }
        //}

        /// <summary>
        /// This function sets the new ticket_items_sales table id to which the server upload will start next time.
        /// </summary>
        /// <param name="id_">The ticket_items_sales Id which have to save in settings file.</param>
        //public static void SetTicketSalesItemId(int id_)
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        node.Attributes["ticket_items_sales"].Value = id_.ToString();
        //        xmlDoc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //    }
        //}

        /// <summary>
        /// This function returns the slush_items_sales table id to which server upload will start.
        /// </summary>
        /// <returns>int, Id to which start upload.</returns>
        //public static int GetSlushSalesItemId()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        string sales = Convert.ToString(node.Attributes["slush_items_sales"].Value);
        //        if (sales == string.Empty || sales == "0")
        //        {
        //            node.Attributes["slush_items_sales"].Value = "0";
        //            xmlDoc.Save(filename);
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(sales);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return 0;
        //    }
        //}

        /// <summary>
        /// This function sets the new slush_items_sales table id to which the server upload will start next time.
        /// </summary>
        /// <param name="id_">The slush_items_sales Id which have to save in settings file.</param>
        //public static void SetSlushSalesItemId(int id_)
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        node.Attributes["slush_items_sales"].Value = id_.ToString();
        //        xmlDoc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //    }
        //}

        /// <summary>
        /// This function returns the sales_closing table id to which server upload will start.
        /// </summary>
        /// <returns>int, Id to which start upload.</returns>
        //public static int GetSalesClosingId()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        string id = Convert.ToString(node.Attributes["sales_closing"].Value);
        //        if (id == string.Empty || id == "0")
        //        {
        //            node.Attributes["sales_closing"].Value = "0";
        //            xmlDoc.Save(filename);
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(id);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return 0;
        //    }
        //}

        /// <summary>
        /// This function sets the new sales_closing table id to which the server upload will start next time.
        /// </summary>
        /// <param name="id_">The sales_closing Id which have to save in settings file.</param>
        //public static void SetSalesClosingId(int id_)
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        node.Attributes["sales_closing"].Value = id_.ToString();
        //        xmlDoc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //    }
        //}

        /// <summary>
        /// This function returns the motion_ride table id to which server upload will start.
        /// </summary>
        /// <returns>int, Id to which start upload.</returns>
        //public static int GetMotionRideId()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        string id = Convert.ToString(node.Attributes["motion_ride"].Value);
        //        if (id == string.Empty || id == "0")
        //        {
        //            node.Attributes["motion_ride"].Value = "0";
        //            xmlDoc.Save(filename);
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(id);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return 0;
        //    }
        //}

        /// <summary>
        /// This function sets the new motion_ride table id to which the server upload will start next time.
        /// </summary>
        /// <param name="id_">The motion_ride Id which have to save in settings file.</param>
        //public static void SetMotionRideId(int id_)
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        node.Attributes["motion_ride"].Value = id_.ToString();
        //        xmlDoc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //    }
        //}

        /// <summary>
        /// This function returns the slush table id to which server upload will start.
        /// </summary>
        /// <returns>int, Id to which start upload.</returns>
        //public static int GetSlushId()
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        string id = Convert.ToString(node.Attributes["slush"].Value);
        //        if (id == string.Empty || id == "0")
        //        {
        //            node.Attributes["slush"].Value = "0";
        //            xmlDoc.Save(filename);
        //            return 0;
        //        }
        //        else
        //        {
        //            return Convert.ToInt32(id);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //        Application.Exit();
        //        return 0;
        //    }
        //}

        /// <summary>
        /// This function sets the new slush table id to which the server upload will start next time.
        /// </summary>
        /// <param name="id_">The slush Id which have to save in settings file.</param>
        //public static void SetSlushId(int id_)
        //{
        //    try
        //    {
        //        string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        XmlDocument xmlDoc = new XmlDocument();
        //        xmlDoc.Load(filename);
        //        XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/UploadIDS");
        //        node.Attributes["slush"].Value = id_.ToString();
        //        xmlDoc.Save(filename);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Settings File Error!");
        //    }
        //}

        // Settings to upload data on the server ends here.
        #endregion

        /// <summary>
        /// This function is used to check whether the application is running or not.
        /// </summary>
        /// <returns>bool, return application status.</returns>
        //public static bool IsApplicationRunning()
        //{
        //    try
        //    {
        //        return Settings.App.Default.IsApplicationRunning;
        //        //string filename = Environment.CurrentDirectory + @"\MotionRiderSettings.123";
        //        //XmlDocument xmlDoc = new XmlDocument();
        //        //xmlDoc.Load(filename);
        //        //XmlNode node = xmlDoc.SelectSingleNode("/ApplicationSettings/ApplicationStatus");
        //        //return Convert.ToBoolean(node.Attributes["IsRunning"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: IsApplicationRunning() \n" + ex.Message, "Settings File Error!");
        //        return false;
        //    }
        //}

        /// <summary>
        /// This function is used to change the running status of the application.
        /// </summary>
        /// <param name="id_">bool, get the new status.</param>
        //public static void ToggleApplicationStatus(bool toggle_)
        //{
        //    try
        //    {
        //        Settings.App.Default.IsRestart = toggle_;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: ToggleApplicationStatus() \n" + ex.Message, "Settings File Error!");
        //    }
        //}

        //public static bool IsOnExit()
        //{
        //    try
        //    {
        //        return Settings.App.Default.IsExit;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: ToggleApplicationStatus() \n" + ex.Message, "Settings File Error!");
        //        return false;
        //    }
        //}


        //public static void RevertExit()
        //{
        //    try
        //    {
        //        Settings.App.Default.IsExit = false;
        //        Settings.App.Default.Save();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: ToggleApplicationStatus() \n" + ex.Message, "Settings File Error!");
        //    }
        //}

        //public static void DoExit()
        //{
        //    try
        //    {
        //        Settings.App.Default.IsExit = true;
        //        Settings.App.Default.Save();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Function: ToggleApplicationStatus() \n" + ex.Message, "Settings File Error!");
        //    }
        //}

        public static void RevertFirstLogin()
        {
            Settings.App.Default.IsFirstLogin = false;
            Settings.App.Default.Save();
        }

        public static void ResetToDefault()
        {
            Settings.App.Default.IsFirstLogin = true;
            Settings.App.Default.IceGolaCounter = 0;
            Settings.App.Default.MotionRideCounter = 0;
            //Settings.App.Default.LoginDate = DateTime.Parse("01-Feb-15");
            //Settings.App.Default.LoginTime = new TimeSpan(0, 0, 0);

            Settings.App.Default.Save();
        }
    }
}
