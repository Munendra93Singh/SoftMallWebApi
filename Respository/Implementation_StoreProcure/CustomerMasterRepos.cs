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
    public class CustomerMasterRepos : ICustomerMasterRepos
    {
        private AplicationDBContext _context;
        public CustomerMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(CustomerMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertCustomerMaster @FirstName,@LastName,@Email,@Password",
                    new SqlParameter("@FirstName", viewModel.FirstName),
                    new SqlParameter("@LastName", viewModel.LastName),
                    new SqlParameter("@Email", viewModel.Email),
                    new SqlParameter("@Password", viewModel.Password)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Update(CustomerMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateCustomerMaster @Id,@FirstName,@LastName,@Email,@Password,@ModifiedBy,@ModifiedOn",
                    new SqlParameter("@Id", viewModel.Id),
                   new SqlParameter("@FirstName", viewModel.FirstName),
                    new SqlParameter("@LastName", viewModel.LastName),
                    new SqlParameter("@Email", viewModel.Email),
                    new SqlParameter("@Password", viewModel.Password),
                    new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
                    new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteCustomerMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBCustomerMaster> GetAll()
        {
            IEnumerable<DBCustomerMaster> response = _context.CustomerMasters.FromSqlRaw("GetAllCustomer");
            return response;
        }

        public DBCustomerMaster GetById(long Id)
        {
            DBCustomerMaster response = _context.CustomerMasters.FromSqlRaw("GetCustomerbyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }

        public DBCustomerMasterLogin Login(LoginRequest model)
        {
            DBCustomerMasterLogin response = _context.CustomerMasterLogins.FromSqlRaw("GetCustomerLogin @UserName,@Password",
                new SqlParameter("@UserName", model.UserName),
                new SqlParameter("@Password", model.Password)
               ).AsEnumerable().FirstOrDefault();

            return response;
        }
    }
}
