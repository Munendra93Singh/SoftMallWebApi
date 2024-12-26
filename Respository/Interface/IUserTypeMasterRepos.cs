using BusinessEntities.Shop.RequestDto;
using Respository.Shop;


namespace Respository.Interface
{
    public interface IUserTypeMasterRepos
    {
        long Add(UserTypeMasterRequest viewModel);
        long Update(UserTypeMasterRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBUserTypeMaster> GetAll();
        DBUserTypeMaster GetById(long Id);
    }
}
