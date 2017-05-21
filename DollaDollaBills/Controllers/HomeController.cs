using DollaDollaBills.DAL;
using DollaDollaBills.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;
using System;
using System.Web;

namespace DollaDollaBills.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            TotalBillsModel totalModel = null;
            using (var context = new DollaDollaContext())
            {
                totalModel = context.TotalBills.Include(c => c.Receipts).FirstOrDefault(x => x.Id == 1);
            }
            return View(totalModel);
        }

        [HttpPost]
        public ActionResult AddReceipt(Receipt receipt)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpException(400, "Invalid Moel State");
            }
            using (var context = new DollaDollaContext())
            {
                var totalbills = context.TotalBills.First(x => x.Id == 1);
                totalbills.Total += receipt.Amount;
                totalbills.Receipts.Add(receipt);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult DeleteReceipt(int ReceiptId)
        {
            using (var context = new DollaDollaContext())
            {
                var receipt = context.Receipts.FirstOrDefault(r => r.Id == ReceiptId);
                if(receipt == null)
                {
                    throw new NullReferenceException("");
                }
                context.Receipts.Remove(receipt);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}