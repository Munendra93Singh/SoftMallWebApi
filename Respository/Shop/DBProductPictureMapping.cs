using Respository.Common;

namespace Respository.Shop
{
    public class DBProductPictureMapping : BaseEntity
    {
        public int Id { get; set; }
        public int ProducId { get; set; }
        public string PictureName { get; set; }
        public string picturePath { get; set; }
    }
}
