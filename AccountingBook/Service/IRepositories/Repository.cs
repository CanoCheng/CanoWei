using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AccountingBook.Service.IRepositories;
using System.Data.Entity;

namespace AccountingBook.Service.IRepositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// 宣告IUnitOfWork介面為UnitOfWork屬性，目的為了同一條連線對DB資料庫做資料存取(介面裡有定義這個屬性)
        /// </summary>
        public IUnitOfWork UnitOfWork { get; set; }


        //宣告資料表存取物件屬性 objectset
        public DbSet<T> _objectset;
        public DbSet<T> objectset
        {
            get
            {
                if(_objectset == null)
                {
                    _objectset = UnitOfWork.Context.Set<T>();
                }
                return _objectset;
            }
        }
        
        //同名建構子做初始化，宣告的連線介面屬性等於傳進來的連線物件
        public Repository(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IQueryable<T> GetAll()
        {
            return objectset;
        }

        public IQueryable<T> Query(Expression<Func<T, bool>> filter)
        {
            return objectset.Where(filter);
        }

        public T GetSingle(Expression<Func<T, bool>> filter)
        {
            return objectset.SingleOrDefault(filter);
        }

        public void Create(T entity)
        {
             objectset.Add(entity);
        }

        public void Remove(T entity)
        {
            objectset.Remove(entity);
        }

        public void Commit()
        {
            UnitOfWork.Save();
        }
    }
}