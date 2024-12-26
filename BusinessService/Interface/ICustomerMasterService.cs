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
    public interface ICustomerMasterService
    {
        ResultDto<long> Add(CustomerMasterRequest viewModel);
        ResultDto<long> Update(CustomerMasterRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<CustomerMasterResponse>> GetAll();
        ResultDto<CustomerMasterResponse> GetById(long Id);
        ResultDto<CustomerMasterLoginResponse> Login(LoginRequest model);
    }
}
