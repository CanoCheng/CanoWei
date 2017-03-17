using AccountingBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccountingBook.Service.IRepositories;


namespace AccountingBook.Service
{
    public class AccountBookService
    {
        #region 沒有使用介面 + Repostory作法
        //private readonly SkillTreeHomeworkEntities db ;

        //public AccountBookService()
        //{
        //    db = new SkillTreeHomeworkEntities();
        //}

        //public IEnumerable<AccountingBookDataListModels> GetAll()
        //{
        //    var accountList = db.AccountBook.Select(x =>
        //    new AccountingBookDataListModels
        //    {
        //        type = (x.Categoryyy.ToString() == "0" ? "收入":"支出"),
        //        Date = x.Dateee,
        //        money = x.Amounttt,
        //        Remark = x.Remarkkk
        //    });

        //    return accountList;
        //}

        #endregion

        #region 使用介面 + Repository 作法
        //使用介面 + Repository 作法
        private readonly IRepository<AccountBook> _accountBook;
        private readonly IUnitOfWork _unitOfWork;

        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _accountBook = new Repository<AccountBook>(unitOfWork);
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AccountingBookDataListModels> GetAll()
        {
            var accountList = _accountBook.GetAll().Select(x =>
            new AccountingBookDataListModels
            {
                type = (x.Categoryyy.ToString() == "0" ? "收入" : "支出"),
                Date = x.Dateee,
                money = x.Amounttt,
                Remark = x.Remarkkk
            });

            return accountList;
        }


        public AccountingBookDataListModels Single(Guid Id)
        {
            var singledata = _accountBook.GetSingle(x => x.Id == Id);//.Select(x =>
            //new AccountingBookDataListModels
            //{
            //    type = (x.Categoryyy.ToString() == "0" ? "收入" : "支出"),
            //    Date = x.Dateee,
            //    money = x.Amounttt,
            //    Remark = x.Remarkkk
            //});
            AccountingBookDataListModels single = new AccountingBookDataListModels
            {
                type = singledata.Categoryyy.ToString(),
                Date = singledata.Dateee,
                money = singledata.Amounttt,
                Remark = singledata.Remarkkk
            };

            return single;
        }


        public void Add(AccountingBookDataListModels addData)
        {
            var accountbook = new AccountBook
            {
                Id = Guid.NewGuid(),
                Categoryyy = int.Parse(addData.type),
                Dateee = addData.Date,
                Amounttt = addData.money,
                Remarkkk = addData.Remark
            };

            _accountBook.Create(accountbook);
        }
        #endregion
    }
}