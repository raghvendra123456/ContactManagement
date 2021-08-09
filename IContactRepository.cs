using DAL;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IContactRepository:IRepository<Contact>
    {
        PagingModel<ContactModel> GetContacts(int page, int pageSize);
    }
}
