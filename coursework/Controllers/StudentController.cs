using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coursework.Models;
using System.Data.Entity;
using System.Transactions;

namespace coursework.Controllers
{
    [Authorize(Roles = "student")]
    public class StudentController : Controller
    {
        private Models.ApplicationDbContext SContext;
        private DbSet<StudentModel> StudentDB;

        public StudentController() {
            SContext = new Models.ApplicationDbContext();
            StudentDB = SContext.StudentDB;
        }

        public ActionResult StudentMain(int sid)
        {
            return View(StudentDB.FindByStudentID(sid));
        }

        [HttpGet]
        public ActionResult Submit(int sid)
        {
            return View(StudentDB.FindByStudentID(sid));
        }

        [HttpPost]
        public ActionResult Submit(int sid, HttpPostedFileBase SelectedHTMLFile)
        {
            using (var dbContextTransaction = SContext.Database.BeginTransaction())
            {
                try
                {
                    if (SelectedHTMLFile != null)
                    {
                        if (!SelectedHTMLFile.FileName.Contains(".html"))
                            return View(StudentDB.FindByStudentID(sid));
                        Byte[] data = new byte[SelectedHTMLFile.ContentLength];
                        SelectedHTMLFile.InputStream.Read(data, 0, data.Length);
                        StudentDB.FindByStudentID(sid).CourseworkData = data;
                        StudentDB.FindByStudentID(sid).CourdeworkMimeType = SelectedHTMLFile.ContentType;
                        SContext.SaveChanges();
                        dbContextTransaction.Commit();
                        return RedirectToAction("StudentUploadSuccess");
                    }      
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }               
            }
            return View(StudentDB.FindByStudentID(sid));
        }
                
        
        

        public ActionResult StudentUploadSuccess() {
            return View();
        }

        public ActionResult Review(int sid)
        {
            ApplicationDbContext AContext = new ApplicationDbContext();
            DbSet<Assessment> AssessmentDB = AContext.AssessmentDB;
            return View(AssessmentDB.FindAssessmentByStudentID(sid));
        }
    }
}