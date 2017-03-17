using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AccountingBook.Models;

namespace AccountingBook.Service.IRepositories
{
    /// <summary>
    /// 實作介面IUnitOfWork，由這邊發出對DB資料庫做資料存取可避免非同一條連線
    /// </summary>
    public class EFUnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 將DbContext 類別宣告為EFUnitOfWork 的屬性Context(介面裡有定義好這個屬性)
        /// </summary>
        public DbContext Context { get; set; }
        
        /// <summary>
        /// 同名建構子，做初始化動作
        /// </summary>
        public EFUnitOfWork()
        {
            Context = new SkillTreeHomeworkEntities();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 由EFUnitOfWork 類別下的Save方法，統一對DB做SaveChange方法
        /// ※統一由一條連線對DB做資料存取
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }
    }
}