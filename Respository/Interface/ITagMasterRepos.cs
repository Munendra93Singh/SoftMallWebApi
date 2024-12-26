using BusinessEntities.Shop.RequestDto;
using Respository.Shop;

namespace Respository.Interface
{
    public interface ITagMasterRepos
    {
        long Add(TagMasterRequest viewModel);
        long Update(TagMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBTagMaster> GetAll();
        DBTagMaster GetById(long Id);
    }
}
