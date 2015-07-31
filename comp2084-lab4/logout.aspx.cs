using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace comp2084_lab4
{
    public partial class logout1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //kill the session
            Session["InstructorID"] = null;
            Session.Abandon();

            //redirect
            Response.Redirect("login.aspx");

        }
    }
}