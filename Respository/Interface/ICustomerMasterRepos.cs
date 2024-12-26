using BusinessEntities.Shop.RequestDto;
using Respository.Shop;
using System.Collections.Generic;

namespace Respository.Interface
{
    public interface ICustomerMasterRepos
    {
        long Add(CustomerMasterRequest viewModel);
        long Update(CustomerMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBCustomerMaster> GetAll();
        DBCustomerMaster GetById(long Id);
        DBCustomerMasterLogin Login(LoginRequest model);
    }
}
