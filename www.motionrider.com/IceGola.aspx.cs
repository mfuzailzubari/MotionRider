using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace www.motionrider.com
{
    public partial class IceGola : System.Web.UI.Page
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
                        LoadIceGolaGrid();
                    }
                }
                // perform function which have to call in every situation.
                this.Title = "Ice Gola";
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        private void LoadIceGolaGrid()
        {
            IceGolaGridView.DataSource = from ig in _db.slushes
                                         select new 
                                         {
                                             ig.slush_id,
                                             ig.slush_name,
                                             ig.slush_price,
                                         };
            IceGolaGridView.DataBind();
        }

    }
}