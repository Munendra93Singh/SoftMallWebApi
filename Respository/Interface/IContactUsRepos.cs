using BusinessEntities.Shop.RequestDto;
using Respository.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Respository.Interface
{
    public interface IContactUsRepos
    {
        long Add(ContactUsRequest viewModel);
        long Delete(long Id);
        IEnumerable<DBContactUs> GetAll();
    }
}
