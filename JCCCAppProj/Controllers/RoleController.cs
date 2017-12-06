using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JCCCAppProj.Models;
using Microsoft.AspNet.Identity.Owin;
using static JCCCAppProj.ApplicationSignInManager;

namespace JCCCAppProj.Controllers
{
    
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
            
        }

        public RoleController(ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
        }



        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            return View(db.RoleViewModels.ToList());
        }

        // GET: Role/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleViewModel = db.RoleViewModels.Find(id);
            if (roleViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.RoleViewModels.Add(roleViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roleViewModel);
        }

        // GET: Role/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleViewModel = db.RoleViewModels.Find(id);
            if (roleViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // POST: Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roleViewModel);
        }

        // GET: Role/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleViewModel roleViewModel = db.RoleViewModels.Find(id);
            if (roleViewModel == null)
            {
                return HttpNotFound();
            }
            return View(roleViewModel);
        }

        // POST: Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RoleViewModel roleViewModel = db.RoleViewModels.Find(id);
            db.RoleViewModels.Remove(roleViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
