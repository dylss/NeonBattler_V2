using Model.Account;
using Networking;
using UnityEngine;

public class BuyComponent : MonoBehaviour
{
    [SerializeField]
    private ShopManager shopManager;

    public static string BUY_URL = "api/battleobject/buy";

    //Buys and validates
    public void Buy(GameObject prefab)
    {
        
        
        //httprequest: 
        //Response = 200 OK, newBalance
        var request = HttpClient.Post<UserModel>(BUY_URL, new BuyModel());
    }
}
