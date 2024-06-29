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

        [HttpGet]
        public ActionResult CreateClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClass(tbl_classes classes)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                db.tbl_classes.Add(classes);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Delete Class
        public ActionResult DeleteClass(int id)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var classes = db.tbl_classes.Find(id);
                db.tbl_classes.Remove(classes);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        // Edit Class
        [HttpGet]
        public ActionResult EditClass(byte id)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var lesson = db.tbl_classes.Find(id);
                return View(lesson);
            }
        }
        [HttpPost]
        public ActionResult EditClass(tbl_classes classes)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                db.Entry(classes).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}
