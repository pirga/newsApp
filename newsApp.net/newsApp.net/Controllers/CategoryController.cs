using newsApp.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class CategoryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var categories = GetAllCategories();
            return View(categories);
        }
        public IEnumerable<Category> GetAllCategories()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Category.ToList();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findCategory = db.Category.Find(id);
                if (findCategory == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"category with id={id}, not found" });
                }
                return View(findCategory);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Category.Add(category);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"category create" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findCategory = db.Category.Find(id);
                if (findCategory == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"category with id={id}, not found" });
                }
                return View(findCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            using (DBEntities db = new DBEntities())
            {
                var findCategory = db.Category.Find(category.Id);
                if (findCategory == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"category with id={category.Id}, not found" });
                }
                db.Category.AddOrUpdate(category);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"edit complete" });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findCategory = db.Category.Find(id);
                if (findCategory == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"category with id={id}, not found" });
                }
                return View(findCategory);
            }
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            using (DBEntities db = new DBEntities())
            {
                var fidnCategory = db.Category.Find(category.Id);
                if (fidnCategory == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"category with id={category.Id}, not found" });
                }
                db.Category.Remove(fidnCategory);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"category with id={category.Id}, delete" });
            }
        }
    }
}