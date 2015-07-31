using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//add reference so we can use ef for database
using comp2084_lab4.Models;

namespace comp2084_lab4
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if loading for the first time (not posting back), check for url
            if (!IsPostBack)
            {
                //if we have an id in the url, look up record
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    GetStudent();
                    pnlCourses.Visible = true;
                }
                else
                {
                    pnlCourses.Visible = false;
                }
            }

        }

        protected void GetStudent()
        {
            try
            {
                //look up selected student and fill form
                using (DefaultConnection db = new DefaultConnection())
                {
                    //store id from the url in a variable
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //look up student
                    Student stud = (from s in db.Students
                                    where s.StudentID == StudentID
                                    select s).FirstOrDefault();
                    //populate form fields
                    txtLast.Text = stud.LastName;
                    txtFirst.Text = stud.FirstMidName;
                    txtEnroll.Text = stud.EnrollmentDate.ToString();

                    //populate all courses student is enrolled in
                    var objK = (from en in db.Enrollments
                                join c in db.Courses on en.CourseID equals c.CourseID
                                join d in db.Departments on c.DepartmentID equals d.DepartmentID
                                where en.StudentID == StudentID
                                select new { en.EnrollmentID, en.Grade, c.Title, d.Name });

                    grdCourses.DataSource = objK.ToList();
                    grdCourses.DataBind();
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
                using (DefaultConnection db = new DefaultConnection())
                {
                    //create a new student in memory
                    Student stud = new Student();

                    Int32 StudentID = 0;

                    //check for url
                    if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                    {
                        //get id from url
                        StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                        //look up the student
                        stud = (from s in db.Students
                                where s.StudentID == StudentID
                                select s).FirstOrDefault();
                    }

                    //fill the properties of the new student
                    stud.LastName = txtLast.Text;
                    stud.FirstMidName = txtFirst.Text;
                    stud.EnrollmentDate = Convert.ToDateTime(txtEnroll.Text);


                    //add if we have no id in the url
                    if (StudentID == 0)
                    {

                        db.Students.Add(stud);
                    }

                    //save the student
                    db.SaveChanges();

                    //redirect to student list page
                    Response.Redirect("students.aspx");

                }
            }
            catch (Exception ex)
            {
                Response.Redirect("error.aspx");
            }
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //get selected id

                Int32 EnrollmentID = Convert.ToInt32(grdCourses.DataKeys[e.RowIndex].Values["EnrollmentID"]);

                //connect
                using (DefaultConnection db = new DefaultConnection())
                {
                    //get record
                    Enrollment objK = (from en in db.Enrollments
                                       where en.EnrollmentID == EnrollmentID
                                       select en).FirstOrDefault();
                    //delete
                    db.Enrollments.Remove(objK);
                    db.SaveChanges();

                    //refresh
                    GetStudent();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("error.aspx");
            }
        }
    }
}