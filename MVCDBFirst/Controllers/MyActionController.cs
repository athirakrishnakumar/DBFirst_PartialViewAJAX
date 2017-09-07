using MVCDBFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDBFirst.Controllers
{
    public class MyActionController : Controller
    {
        AthiraEntities dbContext = new AthiraEntities();
        // GET: MyAction
        public ActionResult Index()
        {
            List<Detail> person = dbContext.Details.ToList();
            return View(person);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Add(Detail person)
        {
            Detail det = dbContext.Details.Where(c => c.id == person.id).FirstOrDefault();
            dbContext.Details.Add(person);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            Detail det = dbContext.Details.Where(c => c.id == id).FirstOrDefault();
            return View(det);
        }

        [HttpPost]
        
        public ActionResult Edit(Detail person)
        {
            Detail det = dbContext.Details.Where(c => c.id == person.id).FirstOrDefault();
            dbContext.Entry(det).CurrentValues.SetValues(person);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            Detail det = dbContext.Details.Where(c => c.id == id).FirstOrDefault();
            return View(det);
        }

        [HttpPost]

        public ActionResult Delete(Detail person)
        {
            Detail der = dbContext.Details.Where(c => c.id == person.id).FirstOrDefault();
            dbContext.Details.Remove(der);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Details(int id)
        //{
        //    Detail det = dbContext.Details.Where(c => c.id == id).FirstOrDefault();
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]

        public ActionResult Search()
        {
            //Detail det = dbContext.Details.Where(c => c.id == person.id).FirstOrDefault();
            return View();
        }

        public ActionResult SearchPartialView(int id)
        {
            Detail det = dbContext.Details.Where(c => c.id == id).FirstOrDefault();
            return PartialView(det);
        }


        public ActionResult Details(int id)
        {
            AthiraEntities dbContext = new AthiraEntities();
            Detail person = dbContext.Details.Where(c => c.id == id).FirstOrDefault();
            return View(person);
        }

        public ActionResult PartialCreate()
        {
            return PartialView();
        }

        public ActionResult Create(Detail per)
        {
            return View(dbContext.Details);
        }

        public ActionResult Indexer()
        {
           
            return PartialView();
        }

    }
}