using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using Respository.Shop;


namespace Respository.Implementation_StoreProcure
{
    public class UserTypeMasterRepos : IUserTypeMasterRepos
    {
        private AplicationDBContext _context;
        public UserTypeMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(UserTypeMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw("execute InsertUserType @Name, @CreatedBy",
                    new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Update(UserTypeMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateUserType @Id,@Name,@ModifiedBy,@ModifiedOn",
                    new SqlParameter("@Id", viewModel.Id),
                    new SqlParameter("@Name", viewModel.Name),
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteUserType @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBUserTypeMaster> GetAll()
        {
            IEnumerable<DBUserTypeMaster> response = _context.UserTypeMasters.FromSqlRaw("GetAllUserType");
            return response;
        }

        public DBUserTypeMaster GetById(long Id)
        {
            DBUserTypeMaster response = _context.UserTypeMasters.FromSqlRaw("GetUserTypebyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }


    }
}