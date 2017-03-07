using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingBook.Models;

namespace AccountingBook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<AccountingBookDataListModels> dataList = new List<AccountingBookDataListModels>()
            {
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,01),money = 300 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,02),money = 1600 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,03),money = 8 }
            };

            return View(dataList);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult ChildAction()
        {
            List<AccountingBookDataListModels> dataList = new List<AccountingBookDataListModels>()
            {
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,01),money = 300 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,02),money = 1600 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,03),money = 8 }
            };

            return View(dataList);
        }

        //Ajax帳本輸入
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        /// <summary>
        /// Ajax 帳本明細
        /// </summary>
        /// <returns></returns>
        public ActionResult AccountBookForAjax()
        {
            List<AccountingBookDataListModels> dataList = new List<AccountingBookDataListModels>()
            {
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,01),money = 300 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,02),money = 1600 },
                new AccountingBookDataListModels() { type = "支出",Date = new DateTime(2016,01,03),money = 8 }
            };

            IEnumerable<AccountingBookDataListModels> data = dataList.AsEnumerable();

            ViewData.Model = data;

            return View();
        }
    }
}