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
    public class HomeController : Controller
    {
        //AccountBookService accountbookservice = new AccountBookService();
        private readonly AccountBookService _accountBookSvc;

        public HomeController()
        {
            var unitOfWork = new EFUnitOfWork();
            _accountBookSvc = new AccountBookService(unitOfWork);
        }

        public ActionResult Index()
        {            
            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Text="收入",Value="0",Selected = true},
                new SelectListItem(){Text = "支出",Value="1"}
            };

            ViewData["dr1"] = items;
            ViewData["partailView"] = _accountBookSvc.GetAll().ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Index(AccountingBookDataListModels request)
        {
            if (ModelState.IsValid)
            {
                _accountBookSvc.Add(request);
                _accountBookSvc.Save();
            }
            //List<AccountingBookDataListModels> dataList = accountbookservice.GetAll().ToList();

            //return View(_accountBookSvc.GetAll().ToList());
            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Text="收入",Value="0",Selected = true},
                new SelectListItem(){Text = "支出",Value="1"}
            };

            ViewData["dr1"] = items;
            ViewData["partailView"] = _accountBookSvc.GetAll().ToList();
            return View();
        }

        


        public ActionResult About()
        {
            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Text="收入",Value="0",Selected = true},
                new SelectListItem(){Text = "支出",Value="1"}
            };

            ViewData["dr1"] = items;


            return View();
        }

        [HttpPost]
        public ActionResult About(AccountingBookDataListModels request)
        {
            if (ModelState.IsValid)
            {
                _accountBookSvc.Add(request);
                _accountBookSvc.Save();
            }

            var items = new List<SelectListItem>()
            {
                new SelectListItem() { Text="收入",Value="0",Selected = true},
                new SelectListItem(){Text = "支出",Value="1"}
            };

            ViewData["dr1"] = items;

            return View();
        }

        [ChildActionOnly]
        //public ActionResult ChildAction()
        public PartialViewResult ChildAction()
        {
            //List<AccountingBookDataListModels> dataList = accountbookservice.GetAll().ToList();

            //return PartialView(dataList);
            ////return PartialView("ChildAction",dataList);->如果partialViewName不是跟Action同名的話，就要加上ViewName在Model前面
            ////return View(dataList);

            return PartialView(_accountBookSvc.GetAll().ToList());
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
            //List<AccountingBookDataListModels> dataList = accountbookservice.GetAll().ToList();
            var dataList = _accountBookSvc.GetAll().ToList();

            ViewData.Model = dataList;

            return View();
        }
    }
}