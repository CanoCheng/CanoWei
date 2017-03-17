﻿using System;
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
            
            //List<AccountingBookDataListModels> dataList = accountbookservice.GetAll().ToList();

            return View(_accountBookSvc.GetAll().ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description about page.";


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

            return PartialView(_accountBookSvc.GetAll());
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
            var dataList = _accountBookSvc.GetAll();

            ViewData.Model = dataList;

            return View();
        }
    }
}