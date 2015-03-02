using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www.motionrider.com
{
    public partial class Closings : System.Web.UI.Page
    {
        MotionRiderDB.MotionRiderDBDataContext _db = new MotionRiderDB.MotionRiderDBDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                if (!IsPostBack)
                {
                    // perform function which will not call on POSTBACK
                    //if (Request.QueryString.Get("show") != null)
                    {
                        LoadClosingsGrid();
                    }
                }
                // perform function which have to call in every situation.
                this.Title = "All Closings";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadClosingsGrid()
        {
            ClosingsGridView.DataSource = from closings in _db.sales_closings
                                          select new
                                          {
                                              closings.closing_id,
                                              closings.closing_start_sales_id,
                                              closings.closing_end_sales_id,
                                              closings.closing_total_amount,
                                              closings.closing_login_time,
                                              closings.closing_login_date,
                                              closings.closing_logout_time,
                                              closings.closing_logout_date,
                                          };
            ClosingsGridView.DataBind();
        }

        protected void On_ClosingsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[0].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[1].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[1].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[2].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[2].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[3].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[3].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[4].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[4].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[5].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[5].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[6].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[6].Attributes["style"] = "cursor:pointer;";
                e.Row.Cells[7].Attributes["onClick"] = "location.href='ClosingDetails.aspx?id=" + Convert.ToString(DataBinder.Eval(e.Row.DataItem, "closing_id")) + "'";
                e.Row.Cells[7].Attributes["style"] = "cursor:pointer;";
            }
        }

    }
}