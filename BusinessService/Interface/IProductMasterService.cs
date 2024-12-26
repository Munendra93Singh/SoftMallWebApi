using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;

namespace BusinessService.Interface
{
    public interface IProductMasterService
    {
        ResultDto<ProductMasterResponse> Add(ProductMasterRequest viewModel);
        ResultDto<ProductMasterResponse> Update(ProductMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<ProductMasterResponse>> GetAll();
        ResultDto<ProductMasterResponse> GetById(long Id);
        ResultDto<long> AddImageMapping(ProductPictureMappingRequest viewModel);


        // For get All Product List With all Details
        IEnumerable<ProductListResponse> GetProductList();
        ResultDto<IEnumerable<ProductListColorsResponse>> GetProductColorsList();
        ResultDto<IEnumerable<ProductListPicturesResponse>> GetProductPicturesList();
        ResultDto<IEnumerable<ProductListSizesResponse>> GetProductSizesList();
        ResultDto<IEnumerable<ProductListTagsResponse>> GetProductTagsList();
        ResultDto<IEnumerable<ProductListVariantsResponse>> GetProductVariantsList();




    }
}
