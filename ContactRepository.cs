using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using X.PagedList;
using System.Linq;
using DAL;
using Repository.Models;
namespace Repository.Implementations
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public DataBaseContext context
        {
            get
            {
                return _dbContext as DataBaseContext;
            }
        }

        public ContactRepository(DbContext _db) : base(_db)
        {

        }
        public PagingModel<ContactModel> GetContacts(int page, int pageSize)
        {
            var data = from cont in context.Contacts                       
                       select new ContactModel
                       {
                           ContactID = cont.ContactID,
                           Name = cont.Name,
                           MobileNo = cont.MobileNo,
                           Designation = cont.Designation,
                           Country= cont.Country,
                           Gender= cont.Gender,
                           Image= cont.Image
                       };

            int count = data.Count();
            var dataList = data.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PagingModel<ContactModel> model = new PagingModel<ContactModel>();
            if (dataList.Count > 0)
            {
                model.Data = new StaticPagedList<ContactModel>(dataList, page, pageSize, count);
                model.Page = page;
                model.PageSize = pageSize;
                model.TotalPages = count;
            }
            return model;
        }
        

        //public PagingModel<ContactModel> GetContacts(int page, int pageSize)
        //{
        //    throw new System.NotImplementedException();
        //}
        //public ContactModel GetProductBySp(int ContactID)
        //{
        //   // return context.usp_getcontact(ContactID);
        //}
    }
}
