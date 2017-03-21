using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace coursework.Models
{
    public class StudentModel
    {
        [Key]
        public int StudentID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public String CourdeworkMimeType { get; set; }

        public byte[] CourseworkData { get; set; }

    }
 
    public static class MyExtensionMethods {
        public static StudentModel FindByStudentID (this IEnumerable<StudentModel> students, int sid) {
           return (from s in students where s.StudentID == sid select s).First();
        }
    }

    public class Assessment
    {
        [Key]
        public int AssessmentID { get; set; }

        public int StudentID { get; set; }

        public int Grade { get; set; }

        public String Comments { get; set; }
    }

    public static class MoreExtensionMethods {
        public static Assessment FindAssessmentByStudentID(this IEnumerable<Assessment> assessment, int sid) {
            return (from a in assessment where a.StudentID == sid select a).Last();
        }
    }
}