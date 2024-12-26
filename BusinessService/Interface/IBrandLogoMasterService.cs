using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessService.Interface
{
    public interface IBrandLogoMasterService
    {
        ResultDto<long> Add(BrandLogoMasterRequest viewModel);
        ResultDto<long> Update(BrandLogoMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<BrandLogoMasterResponse>> GetAll();
        ResultDto<BrandLogoMasterResponse> GetById(long Id);
    }
}