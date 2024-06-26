using StudentNoteMVC.Models.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace StudentNoteMVC.Controllers
{
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var classes = db.tbl_classes.ToList();
                return View(classes);
            }
        }

        public ActionResult CreateClass(tbl_classes classes)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                db.tbl_classes.Add(classes);
                db.SaveChanges();
            }
            return View();
        }
    }
}
