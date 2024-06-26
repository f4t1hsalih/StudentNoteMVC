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
    }
}