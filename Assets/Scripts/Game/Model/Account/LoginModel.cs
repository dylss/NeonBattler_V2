using Core.Model;

namespace Model.Account
{
    public class LoginModel : Model<LoginModel>
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}