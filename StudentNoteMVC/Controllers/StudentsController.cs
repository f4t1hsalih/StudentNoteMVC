using StudentNoteMVC.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentNoteMVC.Controllers
{
    public class StudentsController : Controller
    {
        // GET: Students
        public ActionResult Index()
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var students = db.tbl_students.Include("tbl_clubs").ToList();
                return View(students);
            }
        }

        // GET: AddStudent
        [HttpGet]
        public ActionResult AddStudent()
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                ViewBag.Clubs = new SelectList(db.tbl_clubs.ToList(), "clb_id", "clb_name");
            }
            return View();
        }

        // POST: AddStudent
        [HttpPost]
        public ActionResult AddStudent(tbl_students student)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                db.tbl_students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // Delete Student
        public ActionResult DeleteStudent(int id)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var student = db.tbl_students.Find(id);
                db.tbl_students.Remove(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // Edit Student
        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var student = db.tbl_students.Find(id);

                // Cinsiyet seçeneklerini ViewBag'e ekleyin
                ViewBag.Genders = new SelectList(new List<SelectListItem>{new SelectListItem { Text = "Erkek", Value = "true" },new SelectListItem { Text = "Kadın", Value = "false" }}, "Value", "Text", student.std_gender);

                ViewBag.Clubs = new SelectList(db.tbl_clubs.ToList(), "clb_id", "clb_name");

                return View("EditStudent", student);
            }
        }

    }
}