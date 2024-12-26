using BusinessEntities.Shop.RequestDto;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface IBrandLogoMasterRepos
    {
        long Add(BrandLogoMasterRequest viewModel);
        long Update(BrandLogoMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBBrandLogoMaster> GetAll();
        DBBrandLogoMaster GetById(long Id);
    }
}

