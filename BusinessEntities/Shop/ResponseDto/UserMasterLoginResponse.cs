

namespace BusinessEntities.Shop.ResponseDto
{
    public class UserMasterLoginResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        //Added For Token
        public string Token { get; set; }
    }
}
