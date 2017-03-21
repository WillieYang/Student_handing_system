using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coursework.Models;
using System.Data.Entity;

namespace coursework.Controllers
{
    [Authorize(Roles = "teacher")]
    public class TeacherController : Controller
    {
        private Models.ApplicationDbContext SContext;
        private DbSet<StudentModel> StudentDB;

        public TeacherController()
        {
            SContext = new Models.ApplicationDbContext();
            StudentDB = SContext.StudentDB;
        }

        public ActionResult TeacherMain()
        {
            return View(StudentDB.ToArray());
        }
        
        public ActionResult TeacherReview(int sid)
        {
            return View(StudentDB.FindByStudentID(sid));
        }

        [HttpGet]
        public ActionResult TeacherMark(int sid)
        {
            return View(sid);
        }

       [HttpPost]
        public ActionResult TeacherMark(int sid, int grade, String comments)
        {
            ApplicationDbContext AContext = new ApplicationDbContext();
            using (var dbContextTransaction = AContext.Database.BeginTransaction())
            {
                try
                {
                    Assessment assess = new Assessment
                    {
                        StudentID = sid,
                        Grade = grade,
                        Comments = comments
                    };
                    AContext.AssessmentDB.Add(assess);
                    AContext.SaveChanges();
                    dbContextTransaction.Commit();
                    return RedirectToAction("TeacherSubmitSuccess");
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                }
            }
            return RedirectToAction("TeacherMark",sid);
        }



        public ActionResult TeacherSubmitSuccess()
        {
            return View();
        }

    }
}