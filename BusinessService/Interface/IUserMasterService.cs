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
    public interface IUserMasterService
    {
        ResultDto<long> Add(UserMasterRequest viewModel);
        ResultDto<long> Update(UserMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<UserMasterResponse>> GetAll();
        ResultDto<UserMasterResponse> GetById(long Id);
        ResultDto<UserMasterLoginResponse> Login(LoginRequest model);
    }
}
