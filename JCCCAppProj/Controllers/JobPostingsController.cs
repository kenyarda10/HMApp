using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JCCCAppProj.Models;
using JCCCAppProj.ViewModel;

using System.Linq.Dynamic;




    namespace JCCCAppProj.Controllers
    {
        public class JobPostingsController : Controller
        {
            private ApplicationDbContext db = new ApplicationDbContext();

           
            // GET: JobPostings
            public ActionResult Index()
            {
                var jobPostings = db.JobPostings.Include(j => j.Employer).Include(j => j.Industry);
                return View(jobPostings.ToList());
            }
            
           
            // GET: JobPostings/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                JobPosting jobPosting = db.JobPostings.Find(id);
                if (jobPosting == null)
                {
                    return HttpNotFound();
                }
                return View(jobPosting);
            }

            [AllowAnonymous]
            // GET: JobPostings/Create
            public ActionResult Create()
            {
                ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Id");
                ViewBag.IndustryID = new SelectList(db.Industries, "IndustryID", "IndustryName");
                return View();
            }

            // POST: JobPostings/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "JobPostingID,createdDate,JobDescription,JobTitle,NumOpenings,HoursPerWeek,WageSalary,StartDate,EndDate,Qualifications,ApplicationInstructions,ApplicationWebsite,ExpirationDate,JobType,IndustryID,EmployerID")] JobPosting jobPosting)
            {
                if (ModelState.IsValid)
                {
                    db.JobPostings.Add(jobPosting);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Id", jobPosting.EmployerID);
                ViewBag.IndustryID = new SelectList(db.Industries, "IndustryID", "IndustryName", jobPosting.IndustryID);
                return View(jobPosting);
            }

            // GET: JobPostings/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                JobPosting jobPosting = db.JobPostings.Find(id);
                if (jobPosting == null)
                {
                    return HttpNotFound();
                }
                ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Id", jobPosting.EmployerID);
                ViewBag.IndustryID = new SelectList(db.Industries, "IndustryID", "IndustryName", jobPosting.IndustryID);
                return View(jobPosting);
            }

            // POST: JobPostings/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "JobPostingID,createdDate,JobDescription,JobTitle,NumOpenings,HoursPerWeek,WageSalary,StartDate,EndDate,Qualifications,ApplicationInstructions,ApplicationWebsite,ExpirationDate,JobType,IndustryID,EmployerID")] JobPosting jobPosting)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(jobPosting).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.EmployerID = new SelectList(db.Employers, "EmployerID", "Id", jobPosting.EmployerID);
                ViewBag.IndustryID = new SelectList(db.Industries, "IndustryID", "IndustryName", jobPosting.IndustryID);
                return View(jobPosting);
            }

            // GET: JobPostings/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                JobPosting jobPosting = db.JobPostings.Find(id);
                if (jobPosting == null)
                {
                    return HttpNotFound();
                }
                return View(jobPosting);
            }

            // POST: JobPostings/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                JobPosting jobPosting = db.JobPostings.Find(id);
                db.JobPostings.Remove(jobPosting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // GET: JobPostings/Search/5
            /* public ActionResult Search()
             {

                ViewBag.IndustriesIndustryName = new SelectList(db.Industries, "IndustryName", "IndustryName");
                 //ViewBag.IndustriesIndustryName = new SelectList(db.Industries, "IndustryID", "IndustryName");
                 var Industries = db.JobPostings.Include(j => j.Employer).Include(j => j.Industry);
                 return View(Industries.ToList());

             }


             // POST: JobPostings/Search/5
             [HttpPost]
             public ActionResult Search(string IndustriesIndustryName)
             {
                 ViewBag.IndustriesIndustryName = new SelectList(db.Industries, "IndustryName", "IndustryName");
                 //ViewBag.IndustriesIndustryName = new SelectList(db.Industries, "IndustryID", "IndustryName");

                 var Industries = db.JobPostings.Include(j => j.Employer).Include(j => j.Industry).Where(i => i.Industry.IndustryName == IndustriesIndustryName);



                 return View(Industries.ToList());

             }*/

            public ActionResult JobSearch(SearchViewModel model)
            {
                //Bind Industry drop down in search

                ViewBag.IndustriesIndustryName = new SelectList(db.Industries, "IndustryName", "IndustryName");


            //Get posting details
            //model.Companies = db.Companies
            model.JobPostings = db.JobPostings

                .Where(
                p =>
                (model.JobTitle == null || p.JobTitle.Contains(model.JobTitle))
                && (model.IndustryName == null || p.Industry.IndustryName == model.IndustryName)
              // && (model.CompanyName == null || p.Employer.Companies.Contains(model.CompanyName))
                && (model.JobType == null || p.JobType.Contains(model.JobType)))
               
                    .OrderBy(model.Sort + " " + model.SortDir)
                    .Skip((model.Page - 1) * model.PageSize)
                    .Take(model.PageSize)
                    .ToList();


                // total records for paging
                model.TotalRecords = db.JobPostings
                    .Count(x =>
                        (model.JobTitle == null || x.JobTitle.Contains(model.JobTitle))
                        && (model.JobType == null || x.JobType == model.JobType)
                        //&& (model.CompanyName == null || x.Employer.Companies.Equals(model.CompanyName))
                        && (model.IndustryName == null || x.Industry.IndustryName == model.IndustryName)
                        );

                return View(model);

            }

            public ActionResult SearchDetails(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                JobPosting jobPosting = db.JobPostings.Find(id);
                if (jobPosting == null)
                {
                    return HttpNotFound();
                }
                return View(jobPosting);
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

