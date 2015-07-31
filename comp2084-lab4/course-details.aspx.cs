using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference db model
using comp2084_lab4.Models;

namespace comp2084_lab4
{
    public partial class course_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if loading page for first time, fill the department dropdown

                GetDepartments();

                //check for course id, if found, populate course selected
                if (!String.IsNullOrEmpty(Request.QueryString["CourseID"]))
                {
                    GetCourse();
                    pnlEnrollments.Visible = true;
                }
                else
                {
                    pnlEnrollments.Visible = false;
                }
            }
        }

        protected void GetCourse()
        {
            try
            {

            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                //get the selected courseid from url
                Int32 CourseID = Convert.ToInt32(Request.QueryString["CourseID"]);

                //query the db
                Course objC = (from c in db.Courses
                               where c.CourseID == CourseID
                               select c).FirstOrDefault();

                // populate the form
                txtTitle.Text = objC.Title;
                txtCredits.Text = objC.Credits.ToString();
                ddlDepartment.SelectedValue = objC.DepartmentID.ToString();

                //populate student enrollments grid
                var Enrollments = from en in db.Enrollments
                                  where en.CourseID == CourseID
                                  orderby en.Student.LastName,
                                  en.Student.FirstMidName
                                  select en;

                //bind to the grid
                grdEnrollments.DataSource = Enrollments.ToList();
                grdEnrollments.DataBind();
            }
        } catch (Exception e) {
            //redirect
        Response.Redirect("error.aspx"); 
    }
}
        protected void GetDepartments()
        {
            try { 
            //connect
            using (DefaultConnection db = new DefaultConnection())
            {
                //get department list
                var Departments = from d in db.Departments
                                  orderby d.Name
                                  select d;

                //bind dropdown list
                ddlDepartment.DataSource = Departments.ToList();
                ddlDepartment.DataBind();

                //add default option for dropdown after it's filled
                ListItem DefaultItem = new ListItem("-Select-", "0");
                ddlDepartment.Items.Insert(0, DefaultItem);
            }
            }
            catch (Exception e)
            {
                Response.Redirect("error.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //connect
                using (DefaultConnection db = new DefaultConnection())
                {
                    //create new course and fill properties
                    Course objC = new Course();

                    objC.Title = txtTitle.Text;
                    objC.Credits = Convert.ToInt32(txtCredits.Text);
                    objC.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

                    //save
                    db.Courses.Add(objC);
                    db.SaveChanges();

                    //redirect
                    Response.Redirect("courses.aspx");
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("error.aspx");
            }
        }
    }
}