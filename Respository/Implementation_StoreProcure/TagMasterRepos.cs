using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Respository.Interface;
using Respository.Shop;
using Respository;

namespace Repositories.Implementation_StoreProcure
{
    public class TagMasterRepos : ITagMasterRepos
    {
        private AplicationDBContext _context;
        public TagMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(TagMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw("execute InsertTagMaster @Name,@CreatedBy",
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
        public long Update(TagMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateTagMaster @Id,@Name,@ModifiedBy,@ModifiedOn",
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteTagMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBTagMaster> GetAll()
        {
            IEnumerable<DBTagMaster> response = _context.TagMasters.FromSqlRaw("GetAllTagMaster");
            return response;
        }

        public DBTagMaster GetById(long Id)
        {
            DBTagMaster response = _context.TagMasters.FromSqlRaw("getUserTypemasterbyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }


    }
}
