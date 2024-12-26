
using BusinessEntities.Shop.RequestDto;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface IColorMasterRepos
    {
        long Add(ColorMasterRequest viewModel);
        long Update(ColorMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBColorMaster> GetAll();
        DBColorMaster GetById(long Id);
    }
}
