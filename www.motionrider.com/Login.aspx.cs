using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using www.motionrider.com.MotionRiderDB;

namespace www.motionrider.com
{
    public partial class Login : System.Web.UI.Page
    {
        MotionRiderDBDataContext _db = new MotionRiderDBDataContext();

        /// <summary>
        /// Trigger when the page loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected void Page_Load(object sender, System.EventArgs e)
        {
            lblMsgError.Visible = false;
            lblMsgSuccess.Visible = false;
        }

        /// <summary>
        /// Authenticate the User to Enter in the Admin Portal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        protected void On_btnSubmit_Click(object sender, EventArgs e)
        {
            if ((string.IsNullOrEmpty(userEmail.Text) == false) && (string.IsNullOrEmpty(userPassword.Text) == false))
            {
                //admin admin = _db.admins.First(a => a.admin_email == userEmail.Text && a.admin_password == userPassword.Text);

                try
                {
                    admin admin = (from a in _db.admins
                                   where a.admin_email == userEmail.Text && a.admin_password == userPassword.Text
                                   select a).FirstOrDefault();

                    if (admin != null)
                    {
                        Session["admin"] = admin;
                        Session["user_name"] = admin.admin_name;
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        userEmail.Text = string.Empty;
                        userPassword.Text = string.Empty;

                        lblMsgError.Visible = true;
                        lblMsgError.Text = "Email or Password is incorrect.";
                    }
                }
                catch(Exception ex)
                {
                    lblMsgError.Visible = true;
                    lblMsgError.Text = "Some error occured. Please try again.";
                }
            }
        }
    }
}
