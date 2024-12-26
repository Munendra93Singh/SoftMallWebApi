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
    public interface IColorMasterService
    {
        ResultDto<long> Add(ColorMasterRequest viewModel);
        ResultDto<long> Update(ColorMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<ColorMasterResponse>> GetAll();
        ResultDto<ColorMasterResponse> GetById(long Id);
    }
}
