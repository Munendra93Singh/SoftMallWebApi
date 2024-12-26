using System;

namespace BusinessEntities.Common
{
    public class BaseRequest
    {
        public BaseRequest()
        {
            CreatedBy = 101;
            ModifiedBy = 101;
            ModifiedOn = Convert.ToDateTime(DateTime.Now.ToString());
        }
        public string? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
