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
    }
}