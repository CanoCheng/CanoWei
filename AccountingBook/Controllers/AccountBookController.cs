using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingBook.Models;

namespace AccountingBook.Controllers
{
    public class AccountBookController : Controller
    {
        // GET: AccountBook
        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult DataInputForm()
        {
            List<AccountingBookDataListModels> dataList = new List<AccountingBookDataListModels>()
            {
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,01),money = 300 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,02),money = 1600 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,03),money = 800 }
            };

            return View(dataList);
        }

        
    }
}