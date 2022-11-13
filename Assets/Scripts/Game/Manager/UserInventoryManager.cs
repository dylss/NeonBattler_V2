using System;
using System.Collections.Generic;
using DefaultNamespace;
using Networking;
using UnityEngine;

namespace Manager
{
    public class UserInventoryManager : MonoBehaviour
    {
        private List<BattleObjectSettingsModel> _battleObjectSettingsModels;
        private void Awake()
        {
            _battleObjectSettingsModels = GetBattleObjectsFromDB();
        }

        private List<BattleObjectSettingsModel> GetBattleObjectsFromDB()
        {
            return null;
            // HttpClient.Get<List<BattleObjectSettingsModel>>();
        }
    }
}