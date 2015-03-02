using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www.motionrider.com
{
    public partial class Motionrides : System.Web.UI.Page
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
                        LoadMotionRidesGrid();
                        
                    }
                }
                // perform function which have to call in every situation.
                this.Title = "Motion Rides";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadMotionRidesGrid()
        {
            MotionRiderGridView.DataSource = from mr in _db.motion_rides
                                             select new 
                                             {
                                                 mr.motion_id,
                                                 mr.motion_name,
                                                 mr.motion_charges,
                                             };
            MotionRiderGridView.DataBind();
        }
    }
}