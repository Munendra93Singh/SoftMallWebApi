using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using Respository.Shop;


namespace Respository.Implementation_StoreProcure
{
    public class UserMasterRepos : IUserMasterRepos
    {
        private AplicationDBContext _context;
        public UserMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(UserMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertUserMaster @FirstName,@LastName,@Email,@Password,@UserTypeId,@CreatedBy",
                    new SqlParameter("@FirstName", viewModel.FirstName),
                    new SqlParameter("@LastName", viewModel.LastName),
                    new SqlParameter("@Email", viewModel.Email),
                    new SqlParameter("@Password", viewModel.Password),
                    new SqlParameter("@UserTypeId", viewModel.UserTypeId),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Update(UserMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateUserMaster @Id,@FirstName,@LastName,@Email,@Password,@UserTypeId,@ModifiedBy,@ModifiedOn",
                    new SqlParameter("@Id", viewModel.Id),
                   new SqlParameter("@FirstName", viewModel.FirstName),
                    new SqlParameter("@LastName", viewModel.LastName),
                    new SqlParameter("@Email", viewModel.Email),
                    new SqlParameter("@Password", viewModel.Password),
                    new SqlParameter("@UserTypeId", viewModel.UserTypeId),
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteUserMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBUserMaster> GetAll()
        {
            IEnumerable<DBUserMaster> response = _context.UserMasters.FromSqlRaw("GetAllUsers");
            return response;
        }

        public DBUserMaster GetById(long Id)
        {
            DBUserMaster response = _context.UserMasters.FromSqlRaw("GetUserbyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }

        public DBUserMasterLogin Login(LoginRequest model)
        {
            DBUserMasterLogin response = _context.UserMasterLogins.FromSqlRaw("GetLogin @UserName,@Password",
                 new SqlParameter("@UserName", model.UserName),
                 new SqlParameter("@Password", model.Password)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }
    }
}
