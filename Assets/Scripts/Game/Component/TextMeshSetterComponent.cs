using System.Collections;
using System.Collections.Generic;
using ScriptableObjects;
using TMPro;
using UnityEngine;

public class TextMeshSetterComponent : MonoBehaviour
{
    public StringSO text;

        
    private void Awake()
    {
        GetComponentInChildren<TextMeshProUGUI>().text = text.text;
    }
}
