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
    public interface IContactUsService
    {
        ResultDto<long> Add(ContactUsRequest viewModel);
        ResultDto<long> Delete(long Id);
        ResultDto<IEnumerable<ContactUsResponse>> GetAll();
    }
}
