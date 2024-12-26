using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using Respository.Shop;

namespace Respository.Implementation_StoreProcure
{
    public class SizeMasterRepos : ISizeMasterRepos
    {
        private AplicationDBContext _context;
        public SizeMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }

        public long Add(SizeMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertSizeMaster @Name,@CreatedBy",
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

        public long Delete(long Id)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteSizeMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBSizeMaster> GetAll()
        {
            IEnumerable<DBSizeMaster> response = _context.SizeMasters.FromSqlRaw("GetAllSizeMaster");
            return response;
        }

        public DBSizeMaster GetById(long Id)
        {
            DBSizeMaster response = _context.SizeMasters.FromSqlRaw("GetSizeMasterbyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }

        public long Update(SizeMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateSizeMaster @Id,@Name,@ModifiedBy,@ModifiedOn",
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
    }
}
