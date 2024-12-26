using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;


namespace BusinessService.Interface
{
    public interface IUserTypeMasterService
    {
        ResultDto<long> Add(UserTypeMasterRequest viewModel);
        ResultDto<long> Update(UserTypeMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<UserTypeMasterResponse>> GetAll();
        ResultDto<UserTypeMasterResponse> GetById(long Id);

    }
}
