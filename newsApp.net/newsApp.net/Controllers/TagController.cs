using newsApp.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class TagController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var tags = GetAllTags();
            return View(tags);
        }
        public IEnumerable<Tag> GetAllTags()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Tag.ToList();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findTag = db.Tag.Find(id);
                if (findTag == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"tag with id={id}, not found" });
                }
                return View(findTag);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Tag.Add(tag);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"tag create" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findTag = db.Tag.Find(id);
                if (findTag == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"tag with id={id}, not found" });
                }
                return View(findTag);
            }
        }
        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            using (DBEntities db = new DBEntities())
            {
                var findTag = db.Tag.Find(tag.Id);
                if (findTag == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"tag with id={tag.Id}, not found" });
                }
                db.Tag.AddOrUpdate(tag);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"edit complete" });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findTag = db.Tag.Find(id);
                if (findTag == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"tag with id={id}, not found" });
                }
                return View(findTag);
            }
        }
        [HttpPost]
        public ActionResult Delete(Tag tag)
        {
            using (DBEntities db = new DBEntities())
            {
                var findTag = db.Tag.Find(tag.Id);
                if (findTag == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"tag with id={tag.Id}, not found" });
                }
                db.Tag.Remove(findTag);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"tag with id={tag.Id}, delete" });
            }
        }
    }
}