using StudentNoteMVC.Models.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace StudentNoteMVC.Controllers
{
    public class ClubsController : Controller
    {
        // GET: Clubs
        public ActionResult Index()
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var clubs = db.tbl_clubs.ToList();
                return View(clubs);
            }
        }


        // Create Club
        [HttpGet]
        public ActionResult CreateClub()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateClub(tbl_clubs club)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                db.tbl_clubs.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // Delete Club
        public ActionResult DeleteClub(int id)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var club = db.tbl_clubs.Find(id);
                db.tbl_clubs.Remove(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

    }
}