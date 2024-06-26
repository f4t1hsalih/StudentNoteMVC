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
    }
}