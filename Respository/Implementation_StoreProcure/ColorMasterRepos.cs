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
    public class ColorMasterRepos : IColorMasterRepos
    {
        private AplicationDBContext _context;
        public ColorMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }

        public long Add(ColorMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertColorMaster @Name,@Code,@CreatedBy",
                   new SqlParameter("@Name", viewModel.Name),
                   new SqlParameter("@Code", viewModel.Code),
                   new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                   );


                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Update(ColorMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateColorMaster @Id,@Name,@Code,@ModifiedBy,@ModifiedOn",
                   new SqlParameter("@Id", viewModel.ID),
                   new SqlParameter("@Name", viewModel.Name),
                   new SqlParameter("@Code", viewModel.Code),
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteColorMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBColorMaster> GetAll()
        {
            IEnumerable<DBColorMaster> response = _context.ColorMasters.FromSqlRaw("GetAllColorMaster");
            return response;
        }
      
        public DBColorMaster GetById(long Id)
        {
            DBColorMaster response = _context.ColorMasters.FromSqlRaw("GetColorMasterbyId @Id",
                new SqlParameter ("@Id" , Id)).AsEnumerable().FirstOrDefault();
            return response;
        }

       
    }
}
