using Microsoft.EntityFrameworkCore;
using Repositories.Shop;
using Respository.Shop;

namespace Respository
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext()
        {

        }
        public AplicationDBContext(DbContextOptions<AplicationDBContext> options) : base(options)
        {

        }

        public DbSet<DBSizeMaster> SizeMasters { get; set; }
        public DbSet<DBTagMaster> TagMasters { get; set; }
        public DbSet<DBUserTypeMaster>UserTypeMasters { get; set; }
        public DbSet<DBColorMaster> ColorMasters { get; set; }
        public DbSet<DBUserMaster> UserMasters { get; set; }
        public DbSet<DBUserMasterLogin> UserMasterLogins { get; set; }
        public DbSet<DBCustomerMaster> CustomerMasters { get; set;}
        public DbSet<DBCustomerMasterLogin> CustomerMasterLogins { get; set; }
        public DbSet<DBContactUs> ContactUss { get; set; }
        public DbSet<DBBrandLogoMaster> BrandLogoMasters { get; set; }
        public DbSet<DBCategoryMaster> CategoryMasters { get; set; }
        public DbSet<DBProductMaster> ProductMasters { get; set;}
        public DbSet<DBProductPictureMapping> ProductPictureMappings { get; set; }
        public DbSet<DBProductList> ProductLists { get; set; }
        public DbSet<DBProductListColors> ProductListColorss { get; set; }
        public DbSet<DBProductListPictures> ProductListPicturess { get; set; }
        public DbSet<DBProductListSizes> ProductListSizess { get; set; }
        public DbSet<DBProductListTags> ProductListTagss { get; set; }
        public DbSet<DBProductListVariants> ProductListVariantss { get; set; }
    }
}

