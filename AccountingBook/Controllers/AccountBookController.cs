using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AccountingBook.Models;
using AccountingBook.Service;
using AccountingBook.Service.IRepositories;

namespace AccountingBook.Controllers
{
    public class AccountBookController : Controller
    {
        // GET: AccountBook
        //public ActionResult Index()
        //{
        //    return View();
        //}

        private readonly AccountBookService _accountBookSvc;

        public AccountBookController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);
        }

        [HttpGet]
        public ActionResult DataInputForm()
        {
            //AccountBookService accountbookservice = new AccountBookService();
            //List<AccountingBookDataListModels> dataList = accountbookservice.GetAll().ToList();

            //return View(dataList);

            return View(_accountBookSvc.GetAll().ToList());
        }

        
    }
}