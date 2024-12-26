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
    public class BrandLogoMasterRepos : IBrandLogoMasterRepos
    {
        private AplicationDBContext _context;
        public BrandLogoMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(BrandLogoMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertBrandLogo @Name,@ImagePath,@CreatedBy",
                    new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@ImagePath", viewModel.ImagePath),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Update(BrandLogoMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateBrandLogo @Id,@Name,@ImagePath,@ModifiedBy,@ModifiedOn",
                    new SqlParameter("@Id", viewModel.Id),
                    new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@ImagePath", viewModel.ImagePath),
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteBrandLogo @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBBrandLogoMaster> GetAll()
        {
            IEnumerable<DBBrandLogoMaster> response = _context.BrandLogoMasters.FromSqlRaw("GetAllBrandLogo");
            return response;
        }

        public DBBrandLogoMaster GetById(long Id)
        {
            DBBrandLogoMaster response = _context.BrandLogoMasters.FromSqlRaw("GetBrandLogobyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }


    }
}