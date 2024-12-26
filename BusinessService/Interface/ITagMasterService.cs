using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;

namespace BusinessService.Interface
{
    public interface ITagMasterService  
    {
        ResultDto<long> Add(TagMasterRequest viewModel);
        ResultDto<long> Update(TagMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<TagMasterResponse>> GetAll();
        ResultDto<TagMasterResponse> GetById(long Id);
    }
}
