using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Implementation_StoreProcure
{
    public class ContactUsRepository : IContactUsRepos
    {
        private AplicationDBContext _context;
        public ContactUsRepository(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(ContactUsRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertContactUs @FirstName,@LastName,@Email,@PhoneNumber,@Message,@CreatedBy",
                    new SqlParameter("@FirstName", viewModel.FirstName),
                    new SqlParameter("@LastName", viewModel.LastName),
                    new SqlParameter("@Email", viewModel.Email),
                    new SqlParameter("@PhoneNumber", viewModel.PhoneNumber),
                    new SqlParameter("@Message", viewModel.Message),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Delete(long Id)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteContactUs @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBContactUs> GetAll()
        {
            IEnumerable<DBContactUs> response = _context.ContactUss.FromSqlRaw("GetAllContactUs");
            return response;
        }
    }
}