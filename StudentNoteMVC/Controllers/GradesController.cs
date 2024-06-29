using StudentNoteMVC.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                List<tbl_classes> classes = db.tbl_classes.ToList();
                IEnumerable<SelectListItem> classListItems = classes.Select(c => new SelectListItem
                {
                    Value = c.cls_id.ToString(),
                    Text = c.cls_name
                });
                ViewData["Classes"] = new SelectList(classListItems, "Value", "Text");

                List<tbl_students> students = db.tbl_students.ToList();
                IEnumerable<SelectListItem> studentListItems = students.Select(s => new SelectListItem
                {
                    Value = s.std_id.ToString(),
                    Text = s.std_name + " " + s.std_surname
                });
                ViewData["Students"] = new SelectList(studentListItems, "Value", "Text");

                return View();
            }
        }
        [HttpPost]
        public ActionResult AddGrade(tbl_grades grade)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                // Öğrenci ve ders ID'lerini al
                int studentId = Convert.ToInt32(grade.grd_std_id);
                int classId = Convert.ToInt32(grade.grd_cls_id);

                // Öğrenciye ve derse ait varsa not kaydını al
                var existingGrade = db.tbl_grades.FirstOrDefault(g => g.grd_std_id == studentId && g.grd_cls_id == classId);

                if (existingGrade != null)
                {
                    // Var olan not kaydının değerlerini form alanlarına yerleştir
                    grade.grd_exam1 = existingGrade.grd_exam1;
                    grade.grd_exam2 = existingGrade.grd_exam2;
                    grade.grd_exam3 = existingGrade.grd_exam3;
                    grade.grd_project = existingGrade.grd_project;
                }

                // Not ortalama ve durumunu hesapla
                double total = 0;
                int count = 0;

                if (grade.grd_exam1 != null)
                {
                    total += (double)grade.grd_exam1;
                    count++;
                }
                if (grade.grd_exam2 != null)
                {
                    total += (double)grade.grd_exam2;
                    count++;
                }
                if (grade.grd_exam3 != null)
                {
                    total += (double)grade.grd_exam3;
                    count++;
                }
                if (grade.grd_project != null)
                {
                    total += (double)grade.grd_project;
                    count++;
                }

                double average = count > 0 ? total / count : 0;

                grade.grd_average = decimal.Parse(average.ToString("F2"));
                grade.grd_status = average >= 50 ? true : false;

                // Yeni not kaydını ekle veya mevcut olanı güncelle
                if (existingGrade == null)
                {
                    db.tbl_grades.Add(grade);
                }
                else
                {
                    existingGrade.grd_exam1 = grade.grd_exam1;
                    existingGrade.grd_exam2 = grade.grd_exam2;
                    existingGrade.grd_exam3 = grade.grd_exam3;
                    existingGrade.grd_project = grade.grd_project;
                    existingGrade.grd_average = grade.grd_average;
                    existingGrade.grd_status = grade.grd_status;

                    db.Entry(existingGrade).State = EntityState.Modified;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        // EditGrade
        [HttpGet]
        public ActionResult EditGrade(int id)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                var grade = db.tbl_grades.Find(id);

                List<tbl_classes> classes = db.tbl_classes.ToList();
                IEnumerable<SelectListItem> classListItems = classes.Select(c => new SelectListItem
                {
                    Value = c.cls_id.ToString(),
                    Text = c.cls_name
                });
                ViewData["Classes"] = new SelectList(classListItems, "Value", "Text");

                List<tbl_students> students = db.tbl_students.ToList();
                IEnumerable<SelectListItem> studentListItems = students.Select(s => new SelectListItem
                {
                    Value = s.std_id.ToString(),
                    Text = s.std_name + " " + s.std_surname
                });
                ViewData["Students"] = new SelectList(studentListItems, "Value", "Text");

                return View(grade);
            }
        }
        [HttpPost]
        public ActionResult EditGrade(tbl_grades grade)
        {
            using (DB_MVCSchoolEntities db = new DB_MVCSchoolEntities())
            {
                // Not ortalama ve durumunu hesapla
                double total = 0;
                int count = 0;

                if (grade.grd_exam1 != null)
                {
                    total += (double)grade.grd_exam1;
                    count++;
                }
                if (grade.grd_exam2 != null)
                {
                    total += (double)grade.grd_exam2;
                    count++;
                }
                if (grade.grd_exam3 != null)
                {
                    total += (double)grade.grd_exam3;
                    count++;
                }
                if (grade.grd_project != null)
                {
                    total += (double)grade.grd_project;
                    count++;
                }

                double average = count > 0 ? total / count : 0;

                grade.grd_average = decimal.Parse(average.ToString("F2"));
                grade.grd_status = average >= 50 ? true : false;

                db.Entry(grade).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

    }
}