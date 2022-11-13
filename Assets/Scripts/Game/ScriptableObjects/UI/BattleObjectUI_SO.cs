using UnityEngine;
using UnityEngine.UI;

namespace ScriptableObjects.UI
{
    [CreateAssetMenu(menuName = "UI/BattleObjectUI")]
    public class BattleObjectUI_SO : ScriptableObject
    {
        public Image UIImage;
        [TextArea]
        public string description;
        
    }
}