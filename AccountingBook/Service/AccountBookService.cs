using AccountingBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace AccountingBook.Service
{
    public class AccountBookService
    {
        private readonly SkillTreeHomeworkEntities db ;

        public AccountBookService()
        {
            db = new SkillTreeHomeworkEntities();
        }

        public IEnumerable<AccountingBookDataListModels> GetAll()
        {
            var accountList = db.AccountBook.Select(x =>
            new AccountingBookDataListModels
            {
                type = (x.Categoryyy.ToString() == "0" ? "收入":"支出"),
                Date = x.Dateee,
                money = x.Amounttt,
                Remark = x.Remarkkk
            });

            return accountList;
        }
    }
}