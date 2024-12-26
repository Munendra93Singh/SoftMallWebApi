using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

using Respository.Shop;
using Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using Respository.Interface;

namespace Repositories.Implementation
{
    public class CategoryMasterRepos : ICategoryMasterRepos
    {
        private AplicationDBContext _context;
        public CategoryMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public long Add(CategoryMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertCategoryMaster @Name,@Title,@ImagePath,@IsSave,@Link,@CreatedBy",
                    new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@Title", viewModel.Title),
                    new SqlParameter("@ImagePath", viewModel.ImagePath),
                    new SqlParameter("@IsSave", viewModel.isSave),
                    new SqlParameter("@Link", viewModel.Link),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public long Update(CategoryMasterRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute UpdateCategoryMaster @Id,@Name,@Title,@ImagePath,@IsSave,@Link,@ModifiedBy,@ModifiedOn",
                    new SqlParameter("@Id", viewModel.Id),
                   new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@Title", viewModel.Title),
                    new SqlParameter("@ImagePath", viewModel.ImagePath),
                    new SqlParameter("@IsSave", viewModel.isSave),
                    new SqlParameter("@Link", viewModel.Link),
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
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteCategoryMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBCategoryMaster> GetAll()
        {
            IEnumerable<DBCategoryMaster> response = _context.CategoryMasters.FromSqlRaw("GetAllCategoryMaster");
            return response;
        }

        public DBCategoryMaster GetById(long Id)
        {
            DBCategoryMaster response = _context.CategoryMasters.FromSqlRaw("GetCategoryMasterbyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }
    }
}