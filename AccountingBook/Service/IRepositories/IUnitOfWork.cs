using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingBook.Service.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 資料庫物件
        /// </summary>
        DbContext Context { get; set; }

        /// <summary>
        /// SaveChange
        /// </summary>
        void Save();
    }
}
