using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.motionrider.com.MotionRiderDB;

namespace www.motionrider.com
{
    public partial class IceGolaClosings : System.Web.UI.Page
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
                this.Title = "IceGola Closings";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadGrid()
        {
            //var closings = (from sc in _db.sales_closings
            //               from s in _db.slush_items_sales
            //               where s.sales_id >= sc.closing_start_sales_id && s.sales_id <= sc.closing_end_sales_id
            //               select s).Distinct();

            //List<sales_closing> sale_closings = new List<sales_closing>();
            //foreach (sale s in closings)
            //{
            //    slush_items_sale slush = (from ss in _db.slush_items_sales
            //                              where s.sales_id == s.sales_id
            //                              select ss).First();
            //    if (slush != null)
            //    {
            //        foreach (sales_closing sc in closings)
            //        {
            //            sales_closing sscc = (from slg in _db.sales_closings
            //                                  where slush.sales_id >= slg.closing_end_sales_id && slush.sales_id <= slg.closing_start_sales_id
            //                                  select slg).First();
            //            if (sscc != null)
            //            {

            //            }
            //        }
            //    }
            //            }


            //var sales = from ss in _db.slush_items_sales
            //            where closings.First(e => e.sales_id == ss.sales_id).sales_id == ss.sales_id
            //            select ss;

            IceGolaClosingGridView.DataSource = from sc in _db.View_Slush_DailySales
                                                select sc;
                //from sc in _db.sales_closings
            //                                    //from sis in _db.slush_items_sales
            //                                    //where sis.sales_id >= sc.closing_start_sales_id && sis.sales_id <= sc.closing_end_sales_id
            //                                    select new
            //                                    {
            //                                        sc.closing_id,
            //                                        sc.closing_start_sales_id,
            //                                        sc.closing_end_sales_id,
            //                                        IceGolaSale = (_db.slush_items_sales.Where(sis => sis.sales_id >= sc.closing_start_sales_id && sis.sales_id <= sc.closing_end_sales_id)).Sum(e =>e.ss_total_amount),
            //                                        // IceGolaSale = _db.slush_items_sales.Sum(e => e.ss_total_amount),
            //                                        //IceGolaSale = _db.slush_items_sales.Where(s => s.sales_id >= mr.closing_start_sales_id && s.sales_id <= mr.closing_end_sales_id && s.ss_total_amount != null).Select(e => e.ss_total_amount).Sum(),
            //                                        sc.closing_login_time,
            //                                        sc.closing_login_date,
            //                                        sc.closing_logout_time,
            //                                        sc.closing_logout_date,
            //                                    };
            IceGolaClosingGridView.DataBind();
        }

        protected void IceGolaClosingGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string val = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "TotalAmount"));
                if (val == null)
                    e.Row.Cells[3].Text = "No Sale of IceGola";
            }
        }
    }
}