using BusinessEntities.Common;


namespace BusinessEntities.Shop.RequestDto
{
    public class UserMasterRequest : BaseRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }

    }
}
