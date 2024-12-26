using BusinessEntities.Shop.RequestDto;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface ICategoryMasterRepos
    {
        long Add(CategoryMasterRequest viewModel);
        long Update(CategoryMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBCategoryMaster> GetAll();
        DBCategoryMaster GetById(long Id);
    }
}

