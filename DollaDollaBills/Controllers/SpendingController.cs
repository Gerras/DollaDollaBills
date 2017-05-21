using DollaDollaBills.DAL;
using DollaDollaBills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DollaDollaBills.Controllers
{
    public class SpendingController : Controller
    {
        // GET: Spending
        public ActionResult Index()
        {
            SpendingModel spending;
            using (var context = new DollaDollaContext())
            {
                spending = context.Spendings.FirstOrDefault();
            }
            return View(spending);
        }

        public ActionResult CreateSpendingModel()
        { 
            return View();
        }

        [HttpPost]
        public ActionResult CreateSpendingModel(SpendingModel model)
        {
            if(!ModelState.IsValid)
            {
                throw new HttpException(400, "Invalid Submission");
            }
            using (var context = new DollaDollaContext())
            {
                context.Spendings.Add(model);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            SpendingModel spending;
            using (var context = new DollaDollaContext())
            {
                spending = context.Spendings.Single(x => x.Id == id);
            }
                return View(spending);
        }
    }
}