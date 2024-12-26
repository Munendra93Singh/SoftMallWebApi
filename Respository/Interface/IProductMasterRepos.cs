using BusinessEntities.Shop.RequestDto;
using Repositories.Shop;
using Respository.Shop;

namespace Respository.Interface
{
    public interface IProductMasterRepos
    {
        DBProductMaster Add(ProductMasterRequest viewModel);
        DBProductMaster Update(ProductMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBProductMaster> GetAll();
        DBProductMaster GetById(long Id);
        long AddImageMapping(ProductPictureMappingRequest viewModel);


        // For get All Product List With all Details
        IEnumerable<DBProductList> GetProductList();
        IEnumerable<DBProductListColors> GetProductColorsList();
        IEnumerable<DBProductListPictures> GetProductPicturesList();
        IEnumerable<DBProductListSizes> GetProductSizesList();
        IEnumerable<DBProductListTags> GetProductTagsList();
        IEnumerable<DBProductListVariants> GetProductVariantsList();

    }
}
