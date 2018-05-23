using newsApp.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var users = GetAllUsers();
            return View(users);
        }
        public IEnumerable<Users> GetAllUsers()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Users.ToList();
            }
        }
        public SelectList GetListIdRole()
        {
            using (DBEntities db = new DBEntities())
            {
                var selectList = new SelectList(db.Role.Select(x => x.Id).ToList());
                return selectList;
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findUser = db.Users.Find(id);
                if (findUser == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"user with id={id}, not found" });
                }
                return View(findUser);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ListIdRole = GetListIdRole();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Users user)
        {
            using (DBEntities db = new DBEntities())
            {
                user.Id_role = 1;
                user.Date_reg = DateTime.Now;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"user create" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findUser = db.Users.Find(id);
                if (findUser == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"user with id={id}, not found" });
                }
                ViewBag.ListIdRole = GetListIdRole();
                return View(findUser);
            }
        }
        [HttpPost]
        public ActionResult Edit(Users user)
        {
            using (DBEntities db = new DBEntities())
            {
                var findUser = db.Users.Find(user.Id);
                if (findUser == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"user with id={user.Id}, not found" });
                }
                user.Id_role = findUser.Id_role;
                user.Date_reg = findUser.Date_reg;
                db.Users.AddOrUpdate(user);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"edit complete" });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findUser = db.Users.Find(id);
                if (findUser == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"user with id={id}, not found" });
                }
                return View(findUser);
            }
        }
        [HttpPost]
        public ActionResult Delete(Users user)
        {
            using (DBEntities db = new DBEntities())
            {
                var findUser = db.Users.Find(user.Id);
                if (findUser == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"user with id={user.Id}, not found" });
                }
                db.Users.Remove(findUser);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"user with id={user.Id}, delete" });
            }
        }
    }
}