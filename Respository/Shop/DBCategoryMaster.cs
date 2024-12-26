using Respository.Common;

namespace Respository.Shop
{
    public class DBCategoryMaster : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int isSave { get; set; }
        public string Link { get; set; }
    }
}
