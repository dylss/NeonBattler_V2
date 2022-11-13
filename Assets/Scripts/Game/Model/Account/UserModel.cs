using Core.Model;

namespace Model.Account
{
    public class UserModel : Model<UserModel>
    {
        public string FirstName { get; set; }
        public string Email { get; set; }
        public int Balance { get; set; }
        
    }
}