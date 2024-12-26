using BusinessEntities.Common;


namespace BusinessEntities.Shop.ResponseDto
{
    public class UserMasterResponse : BaseResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
