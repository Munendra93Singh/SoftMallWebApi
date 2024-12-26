using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using BusinessEntities.Common;
using System.Collections.Generic;

namespace BusinessService.Interface
{
    public interface ISizeMasterService
    {
        ResultDto <long> Add(SizeMasterRequest viewModel);
        ResultDto<long> Update(SizeMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto <IEnumerable<SizeMasterResponse>> GetAll();
        ResultDto <SizeMasterResponse> GetById(long Id);
    }
}
