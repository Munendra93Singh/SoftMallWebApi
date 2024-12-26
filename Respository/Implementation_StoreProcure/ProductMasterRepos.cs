using BusinessEntities.Shop.RequestDto;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Repositories.Shop;
using Respository.Shop;
using Respository;
using System;
using System.Collections.Generic;
using System.Linq;
using Respository.Interface;

namespace Repositories.Implementation
{
    public class ProductMasterRepos : IProductMasterRepos
    {
        private AplicationDBContext _context;
        public ProductMasterRepos(AplicationDBContext context)
        {
            _context = context;
        }
        public DBProductMaster Add(ProductMasterRequest viewModel)
        {
            try
            {
                DBProductMaster response = _context.ProductMasters.FromSqlRaw(" execute InsertProductMaster @Name,@Title,@Code,@Price,@SalePrice,@ShortDetails,@Description,@Quantity,@Discount,@IsNew,@IsSale,@CategoryId,@ColorId,@SizeId,@TagId,@CreatedBy",
                    new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@Title", viewModel.Title),
                    new SqlParameter("@Code", viewModel.Code),
                    new SqlParameter("@Price", viewModel.Price),
                    new SqlParameter("@SalePrice", viewModel.SalePrice),
                    new SqlParameter("@ShortDetails", viewModel.ShortDetails),
                    new SqlParameter("@Description", viewModel.Description),
                    new SqlParameter("@Quantity", viewModel.Quantity),
                    new SqlParameter("@Discount", viewModel.Discount),
                    new SqlParameter("@IsNew", viewModel.IsNew),
                    new SqlParameter("@IsSale", viewModel.IsSale),
                    new SqlParameter("@CategoryId", viewModel.CategoryId),
                    new SqlParameter("@ColorId", viewModel.ColorId),
                    new SqlParameter("@SizeId", viewModel.SizeId),
                    new SqlParameter("@TagId", viewModel.TagId),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    ).FirstOrDefault();

                return response;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public DBProductMaster Update(ProductMasterRequest viewModel)
        {
            try
            {
                DBProductMaster response = _context.ProductMasters.FromSqlRaw(" execute UpdateProductMaster @Id,@Name,@Title,@Code,@Price,@SalePrice,@ShortDetails,@Description,@Quantity,@Discount,@IsNew,@IsSale,@CategoryId,@ColorId,@SizeId,@TagId,@ModifiedBy,@ModifiedOn",
                    new SqlParameter("@Id", viewModel.Id),
                    new SqlParameter("@Name", viewModel.Name),
                    new SqlParameter("@Title", viewModel.Title),
                    new SqlParameter("@Code", viewModel.Code),
                    new SqlParameter("@Price", viewModel.Price),
                    new SqlParameter("@SalePrice", viewModel.SalePrice),
                    new SqlParameter("@ShortDetails", viewModel.ShortDetails),
                    new SqlParameter("@Description", viewModel.Description),
                    new SqlParameter("@Quantity", viewModel.Quantity),
                    new SqlParameter("@Discount", viewModel.Discount),
                    new SqlParameter("@IsNew", viewModel.IsNew),
                    new SqlParameter("@IsSale", viewModel.IsSale),
                    new SqlParameter("@CategoryId", viewModel.CategoryId),
                    new SqlParameter("@ColorId", viewModel.ColorId),
                    new SqlParameter("@SizeId", viewModel.SizeId),
                    new SqlParameter("@TagId", viewModel.TagId),
                    new SqlParameter("@ModifiedBy", viewModel.ModifiedBy),
                    new SqlParameter("@ModifiedOn", viewModel.ModifiedOn)
                    ).FirstOrDefault();

                return response;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public long Delete(long Id)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw("Execute DeleteProductMaster @Id",
                 new SqlParameter("@Id", Id)
                );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;
        }

        public IEnumerable<DBProductMaster> GetAll()
        {
            IEnumerable<DBProductMaster> response = _context.ProductMasters.FromSqlRaw("GetAllProductMaster");
            return response;
        }

        public DBProductMaster GetById(long Id)
        {
            DBProductMaster response = _context.ProductMasters.FromSqlRaw("GetProductMasterbyId @Id",
                 new SqlParameter("@Id", Id)
                ).AsEnumerable().FirstOrDefault();

            return response;
        }

        public long AddImageMapping(ProductPictureMappingRequest viewModel)
        {
            try
            {
                var response = _context.Database.ExecuteSqlRaw(" execute InsertProductMaster @ProductId,@PictureName,@PicturePath,@CreatedBy",
                    new SqlParameter("@ProductId", viewModel.ProductId),
                    new SqlParameter("@PictureName", viewModel.PictureName),
                    new SqlParameter("@PicturePath", viewModel.PicturePath),
                    new SqlParameter("@IsDelete", viewModel.IsDelete),
                    new SqlParameter("@CreatedBy", viewModel.CreatedBy)
                    );

                return response;
            }
            catch (Exception ex)
            {

            }
            return 0;

        }

        public IEnumerable<DBProductList> GetProductList()
        {
            return _context.ProductLists.FromSqlRaw("GetProductList").ToList();
        }

        public IEnumerable<DBProductListColors> GetProductColorsList()
        {
            return _context.ProductListColorss.FromSqlRaw("GetProductcolorsList").ToList();
        }

        public IEnumerable<DBProductListPictures> GetProductPicturesList()
        {
            return _context.ProductListPicturess.FromSqlRaw("GetProductPicturesList").ToList();
        }

        public IEnumerable<DBProductListSizes> GetProductSizesList()
        {
            return _context.ProductListSizess.FromSqlRaw("GetProductSizesList").ToList();
        }

        public IEnumerable<DBProductListTags> GetProductTagsList()
        {
            return _context.ProductListTagss.FromSqlRaw("GetProductTagsList").ToList();
        }

        public IEnumerable<DBProductListVariants> GetProductVariantsList()
        {
            return _context.ProductListVariantss.FromSqlRaw("GetProductVariantsList").ToList();
        }
    }
}