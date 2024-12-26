using BusinessEntities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities.Shop.RequestDto
{
    public class ProductPictureMappingRequest : BaseRequest
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string PictureName { get; set; }
        public string PicturePath { get; set; }
        public int IsDelete { get; set; }
    }
}
