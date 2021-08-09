﻿using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Repository.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _dbContext;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        public void Delete(object Id)
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(Id);
            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
                _dbContext.SaveChanges();
            }
        }
        public TEntity Find(object Id)
        {
            return _dbContext.Set<TEntity>().Find(Id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        //public PagingModel<ContactModel> GetContacts(object page, object pageSize)
        //{
        //    throw new System.NotImplementedException();
        //}

        public void Remove(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        //public int SaveChanges()
        //{
        //    return _dbContext.SaveChanges();
        //}

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

    }
}