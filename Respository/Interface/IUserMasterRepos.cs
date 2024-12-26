using BusinessEntities.Common;
using BusinessEntities.Shop.RequestDto;
using BusinessEntities.Shop.ResponseDto;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface IUserMasterRepos
    {
       long Add(UserMasterRequest viewModel);
       long Update(UserMasterRequest viewModel);
       long Delete(long Id);
       IEnumerable<DBUserMaster> GetAll();
       DBUserMaster GetById(long Id);
       DBUserMasterLogin Login(LoginRequest model);      
    }
}
