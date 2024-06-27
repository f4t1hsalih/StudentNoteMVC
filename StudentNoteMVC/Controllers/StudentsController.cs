using StudentNoteMVC.Models.EntityFramework;
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

    }
}