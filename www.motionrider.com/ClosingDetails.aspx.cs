using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.motionrider.com.MotionRiderDB;

namespace www.motionrider.com
{
    public partial class ClosingDetails : System.Web.UI.Page
    {
        MotionRiderDB.MotionRiderDBDataContext _db = new MotionRiderDB.MotionRiderDBDataContext();
        int _id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                if (!IsPostBack)
                {
                    // perform function which will not call on POSTBACK
                    if (Request.QueryString.Get("id") != null)
                    {
                        _id = Convert.ToInt32(Request.QueryString.Get("id"));
                        this.Title = "Closing Details";
                        LoadClosingDetailsGrids();
                    }
                }
                // perform function which have to call in every situation.
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadClosingDetailsGrids()
        {
            sales_closing closings = _db.sales_closings.First(e => e.closing_id == _id);
            PageHeading.InnerText = "Closing Details for: " + closings.closing_logout_date.Value.Date;

            // sales grid.
            var sales = from i in _db.sales
                        where i.sales_id >= closings.closing_start_sales_id && i.sales_id <= closings.closing_end_sales_id
                        select new
                        {
                            i.sales_id,
                            i.sales_total_amount,
                            i.sales_date,
                            i.sales_time,
                        };

            if (sales.Count() > 0)
            {
                SalesGridView.DataSource = sales;
                SalesGridView.DataBind();

                lblSalesTotal.InnerText = "Sales Total: Rs. " + sales.Sum(e => e.sales_total_amount).ToString();
            }
            else
                lblSalesTotal.InnerText = "Sales Total: Rs. 0";

            // motion sales grid.
            var tis = from ts in _db.ticket_items_sales
                      where ts.sales_id >= closings.closing_start_sales_id && ts.sales_id <= closings.closing_end_sales_id
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

            if (tis.Count() > 0)
            {
                MotionGridView.DataSource = tis;
                MotionGridView.DataBind();

                lblMotionRiderTotal.InnerText = "Motion Rider Total: Rs. " + tis.Sum(e => e.ts_total_amount).ToString();
            }
            else
                lblMotionRiderTotal.InnerText = "Motion Rider Total: Rs. 0";


            // ice gola sales grid.
            var sis = from ss in _db.slush_items_sales
                      where ss.sales_id >= closings.closing_start_sales_id && ss.sales_id <= closings.closing_end_sales_id
                      select new
                      {
                          ss.sales_id,
                          IceGolaName = _db.slushes.First(r => r.slush_id == ss.slush_id).slush_name,
                          ss.ss_quantity,
                          ss.ss_unit_price,
                          ss.ss_total_amount,
                          Time = _db.sales.First(r => r.sales_id == ss.sales_id).sales_time,
                          Date = _db.sales.First(r => r.sales_id == ss.sales_id).sales_date,
                      };
            
            if (sis.Count() > 0)
            {
                IceGolaGridView.DataSource = sis;
                IceGolaGridView.DataBind();

                lblIceGolaTotal.InnerText = "Ice Gola Total: Rs. " + sis.Sum(e => e.ss_total_amount).ToString();
            }
            else
                lblIceGolaTotal.InnerText = "Ice Gola Total: Rs. 0";
        }
    }


}