using DAL;
using Repository.Implementations;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //public IContactRepository ContactRepo => throw new NotImplementedException();
        DataBaseContext _db;
        public UnitOfWork(DataBaseContext db)
        {
            _db = db;
        }
        private IContactRepository _ContactRepo;       

        public IContactRepository ContactyRepo
        {
            get
            {
                if (_ContactRepo == null)
                    _ContactRepo = new ContactRepository(_db);
                return _ContactRepo;
            }
        }

        //public IRepository<Contact> ContactyRepo => throw new NotImplementedException();

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }
    }
}
