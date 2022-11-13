using UnityEngine;

namespace Core.Model
{
    [System.Serializable]
    public abstract class Model<T>
    {
        
        // Given JSON input:
        // {"lives":3, "health":0.8}
        // the Load function will change the object on which it is called such that
        // lives == 3 and health == 0.8
        // the 'playerName' field will be left unchanged
        public void Load(string jsonData)
        {
            JsonUtility.FromJsonOverwrite(jsonData, this);
        }
        
        // Given:
        // playerName = "Dr Charles"
        // lives = 3
        // health = 0.8f
        // SaveToString returns:
        // {"playerName":"Dr Charles","lives":3,"health":0.8}
        public string SaveToString()
        {
            return JsonUtility.ToJson(this);
        }
        
        // Given JSON input:
        // {"name":"Dr Charles","lives":3,"health":0.8}
        // this example will return a PlayerInfo object with
        // name == "Dr Charles", lives == 3, and health == 0.8f.
        public T CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<T>(jsonString);
        }
    }
}