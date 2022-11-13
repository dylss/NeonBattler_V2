using System;
using Core.Utilities;
using Model.Account;
using UnityEngine.Networking;

namespace Networking
{
    public class NetworkManager : PersistentSingleton<NetworkManager>
    {
        public static string API_PATH = "localhost:8080";

        protected override void Awake()
        {
            Initialize();
        }

        private void Initialize()
        {
            //Try connect to API
            
            //Try auto-login -> return: token?
            
            //
        }

        public void Login()
        {
            // LoginModel loginModel = new LoginModel();
            // loginModel.password = getpassword;
            // loginModel.username = getusername;
            //
            // String loginPath = "/login";
            // Uri uri = new Uri(API_PATH + loginPath);
            //
            // UnityWebRequest request = HttpClient.CreateRequest(API_PATH, HttpClient.RequestType.POST, loginModel);
            //

        }

        public void Logout()
        {
            
        }
        
        
    }
}