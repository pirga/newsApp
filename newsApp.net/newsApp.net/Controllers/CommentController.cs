using newsApp.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class CommentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var comments = GetAllComments();
            return View(comments);
        }
        public IEnumerable<Comment> GetAllComments()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Comment.ToList();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findComment = db.Comment.Find(id);
                if (findComment == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"comment with id={id}, not found" });
                }
                return View(findComment);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Comment comment)
        {
            using (DBEntities db = new DBEntities())
            {
                comment.Date_add = DateTime.Now;
                db.Comment.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"comment create" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findComment = db.Comment.Find(id);
                if (findComment == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"comment with id={id}, not found" });
                }
                return View(findComment);
            }
        }
        [HttpPost]
        public ActionResult Edit(Comment comment)
        {
            using (DBEntities db = new DBEntities())
            {
                var findComment = db.Comment.Find(comment.Id);
                if (findComment == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"comment with id={comment.Id}, not found" });
                }
                comment.Date_add = findComment.Date_add;
                db.Comment.AddOrUpdate(comment);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"edit complete" });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findComment = db.Comment.Find(id);
                if (findComment == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"comment with id={id}, not found" });
                }
                return View(findComment);
            }
        }
        [HttpPost]
        public ActionResult Delete(Comment comment)
        {
            using (DBEntities db = new DBEntities())
            {
                var findComment = db.Comment.Find(comment.Id);
                if (findComment == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"comment with id={comment.Id}, not found" });
                }
                db.Comment.Remove(findComment);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"comment with id={comment.Id}, delete" });
            }
        }
    }
}