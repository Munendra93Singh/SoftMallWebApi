﻿using BusinessEntities.Common;


namespace BusinessEntities.Shop.RequestDto
{
    public class ProductMasterRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public decimal SalePrice { get; set; }
        public string ShortDetails { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Discount { get; set; }
        public int IsNew { get; set; }
        public int IsSale { get; set; }
        public int CategoryId { get; set; }
        public int TagId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
    }
}
