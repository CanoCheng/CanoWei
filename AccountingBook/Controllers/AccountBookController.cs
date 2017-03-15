using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingBook.Models;
using AccountingBook.Service;

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
            AccountBookService accountbookservice = new AccountBookService();
            List<AccountingBookDataListModels> dataList = accountbookservice.GetAll().ToList();

            return View(dataList);
        }

        
    }
}