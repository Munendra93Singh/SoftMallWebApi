using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Shop.ResponseDto
{
    public class CustomerMasterLoginResponse
    {
        public int Id { get; set; }
        public string FirstName {  get; set; }
        public string lastName {  set; get; }
        public string Email { get; set; }

    }
}
