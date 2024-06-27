using StudentNoteMVC.Models.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace StudentNoteMVC.Controllers
{
    public class GradesController : Controller
    {
        // GET: Grades
        public ActionResult Index()
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var grades = db.tbl_grades
                               .Include("tbl_students")
                               .Include("tbl_classes")
                               .ToList();
                return View(grades);
            }
        }

        // AddGrade
        [HttpGet]
        public ActionResult AddGrade()
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                ViewBag.Students = db.tbl_students.ToList();
                ViewBag.Classes = db.tbl_classes.ToList();
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddGrade(tbl_grades grade)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                db.tbl_grades.Add(grade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}