using BusinessEntities.Common;


namespace BusinessEntities.Shop.RequestDto
{
    public class CategoryMasterRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public int isSave { get; set; }
        public string Link { get; set; }
    }
}
