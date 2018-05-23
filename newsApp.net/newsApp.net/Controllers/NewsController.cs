using newsApp.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        [HttpGet]
        public ActionResult Index()
        {
            var news = GetAllNews();
            return View(news);
        }
        public IEnumerable<News> GetAllNews()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.News.ToList();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findNews = db.News.Find(id);
                if (findNews == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"news with id={id}, not found" });
                }
                return View(findNews);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(News news)
        {
            using (DBEntities db = new DBEntities())
            {
                news.Date_add = DateTime.Now;
                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"news create" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findNews = db.News.Find(id);
                if (findNews == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"news with id={id}, not found" });
                }
                return View(findNews);
            }
        }
        [HttpPost]
        public ActionResult Edit(News news)
        {
            using (DBEntities db = new DBEntities())
            {
                var findNews = db.News.Find(news.Id);
                if (findNews == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"news with id={news.Id}, not found" });
                }
                news.Date_add = findNews.Date_add;
                db.News.AddOrUpdate(news);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"edit complete" });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findNews = db.News.Find(id);
                if (findNews == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"news with id={id}, not found" });
                }
                return View(findNews);
            }
        }
        [HttpPost]
        public ActionResult Delete(News news)
        {
            using (DBEntities db = new DBEntities())
            {
                var findNews = db.News.Find(news.Id);
                if (findNews == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"news with id={news.Id}, not found" });
                }
                db.News.Remove(findNews);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"news with id={news.Id}, delete" });
            }
        }
    }
}