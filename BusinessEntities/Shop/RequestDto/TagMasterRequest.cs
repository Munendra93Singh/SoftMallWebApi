﻿using BusinessEntities.Common;

namespace BusinessEntities.Shop.RequestDto
{
    public class TagMasterRequest : BaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
