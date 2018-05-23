using newsApp.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace newsApp.net.Controllers
{
    public class RoleController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var roles = GetAllRoles();
            return View(roles);
        }
        public IEnumerable<Role> GetAllRoles()
        {
            using (DBEntities db = new DBEntities())
            {
                return db.Role.ToList();
            }
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findRole = db.Role.Find(id);
                if (findRole == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"role with id={id}, not found" });
                }
                return View(findRole);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Role role)
        {
            using (DBEntities db = new DBEntities())
            {
                db.Role.Add(role);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"role create" });
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findRole = db.Role.Find(id);
                if (findRole == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"role with id={id}, not found" });
                }
                return View(findRole);
            }
        }
        [HttpPost]
        public ActionResult Edit(Role role)
        {
            using (DBEntities db = new DBEntities())
            {
                var findRole = db.Role.Find(role.Id);
                if (findRole == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"role with id={role.Id}, not found" });
                }
                db.Role.AddOrUpdate(role);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"edit complete" });
            }
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (DBEntities db = new DBEntities())
            {
                var findRole = db.Role.Find(id);
                if (findRole == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"role with id={id}, not found" });
                }
                return View(findRole);
            }
        }
        [HttpPost]
        public ActionResult Delete(Role role)
        {
            using (DBEntities db = new DBEntities())
            {
                var findRole = db.Role.Find(role.Id);
                if (findRole == null)
                {
                    return RedirectToAction("Show", "Info", new { message = $"role with id={role.Id}, not found" });
                }
                db.Role.Remove(findRole);
                db.SaveChanges();
                return RedirectToAction("Show", "Info", new { message = $"role with id={role.Id}, delete" });
            }
        }
    }
}