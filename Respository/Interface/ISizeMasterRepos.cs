using BusinessEntities.Shop.RequestDto;
using Respository.Shop;

namespace Respository.Interface
{
    public interface ISizeMasterRepos
    {
        long Add(SizeMasterRequest viewModel);
        long Update(SizeMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBSizeMaster> GetAll();
        DBSizeMaster GetById(long Id);
    }
}
