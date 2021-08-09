using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity Find(object Id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        void Delete(object Id);
        //IEnumerable<TEntity> GetAll();
        //TEntity Find(object Id);
        //void Add(TEntity entity);
        //void Update(TEntity entity);
        //void Remove(TEntity entity);
        //PagingModel<ContactModel> GetContacts(object page, object pageSize);
        //void Delete(object Id);
        //int SaveChanges();
    }
}
