using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataBaseContext:DbContext 
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<User> Users { get; set; }
        //public DbSet<UserModel> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //migration purpose
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=CSMBHUD297\\SQL2012;uid=sa;pwd=csmpl@123;database=ContactManagementTraining;Timeout=1000;Pooling=false;Connect Timeout=1000000");
            }
            base.OnConfiguring(optionsBuilder);
        }
        public Contact usp_getcontact(int ContactId)
        {
            Contact contact = new Contact();
            using (var command = Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "usp_getproduct";
                command.CommandType = CommandType.StoredProcedure;

                var parameter = new SqlParameter("ProductId", ContactId);
                command.Parameters.Add(parameter);
                Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        contact.ContactID = reader.GetInt32("ContactID");
                        contact.Name = reader.GetString("Name");
                        contact.MobileNo = reader.GetString("MobileNo");
                        contact.Designation = reader.GetString("Designation");
                        contact.Country= reader.GetString("Country");
                        contact.Gender= reader.GetString("Gender");
                        //contact.Image
                    }
                }
                Database.CloseConnection();
            }
            return contact;
        }
    }
}
