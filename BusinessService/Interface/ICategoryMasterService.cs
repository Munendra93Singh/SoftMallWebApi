using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;


namespace BusinessService.Interface
{
    public interface ICategoryMasterService
    {
        ResultDto<long> Add(CategoryMasterRequest viewModel);
        ResultDto<long> Update(CategoryMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<CategoryMasterResponse>> GetAll();
        ResultDto<CategoryMasterResponse> GetById(long Id);
    }
}
