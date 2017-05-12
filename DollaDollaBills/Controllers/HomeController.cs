using DollaDollaBills.DAL;
using DollaDollaBills.Models;
using System.Linq;
using System.Web.Mvc;
using System.Data.Entity;

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
                return RedirectToAction("About");
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
    }
}