using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference db model so we can connect to sql server
using comp2084_lab4.Models;

namespace comp2084_lab4
{
    public partial class courses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCourses();
            }
        }
        protected void GetCourses()
        {
            try { 
            using (DefaultConnection db = new DefaultConnection())
            {
                var Courses = from c in db.Courses
                              select c;

                grdCourses.DataSource = Courses.ToList();
                grdCourses.DataBind();
            }
            }
            catch (Exception e)
            {
                Response.Redirect("error.aspx");
            }
        }
    }
}