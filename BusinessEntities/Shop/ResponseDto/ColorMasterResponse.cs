using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Shop.ResponseDto
{
    public  class ColorMasterResponse : BaseResponse
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
     

    }
}
