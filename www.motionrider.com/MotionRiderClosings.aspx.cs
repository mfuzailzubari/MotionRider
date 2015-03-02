using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.motionrider.com.MotionRiderDB;

namespace www.motionrider.com
{
    public partial class MotionRiderClosings : System.Web.UI.Page
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                if (!IsPostBack)
                {
                    // perform function which will not call on POSTBACK
                    //if (Request.QueryString.Get("show") != null)
                    {
                        LoadGrid();
                    }
                }
                // perform function which have to call in every situation.
                this.Title = "Motion Rider Closings";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadGrid()
        {
            MotionRiderClosingGridView.DataSource = from sc in _db.View_Ticket_DailySales
                                                    select sc;
            //MotionRiderClosingGridView.DataSource = from mr in _db.sales_closings
            //                                        //where s.sales_id >= mr.closing_start_sales_id && s.sales_id <= mr.closing_end_sales_id
            //                                        select new
            //                                        {
            //                                            mr.closing_id,
            //                                            mr.closing_start_sales_id,
            //                                            mr.closing_end_sales_id,
            //                                            MotionRiderSale = _db.ticket_items_sales.Where(s => s.sales_id >= mr.closing_start_sales_id && s.sales_id <= mr.closing_end_sales_id).Sum(e => e.ts_total_amount),
            //                                            mr.closing_login_time,
            //                                            mr.closing_login_date,
            //                                            mr.closing_logout_time,
            //                                            mr.closing_logout_date,
            //                                        };
            MotionRiderClosingGridView.DataBind();
        }
    }
}