using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnComponent : MonoBehaviour
{
    [SerializeField]
    private Vector3 heightOffset;
    public Vector3 SpawnPos { get; set; }
    public Quaternion SpawnRot { get; set; }

    private Coroutine animatedSpawn;
    
    public enum SpawnType
    {
        INSTANT,
        ANIMATED
    }
    
    public void StartSpawn(SpawnType spawnType)
    {
        
        switch (spawnType)
        {
            case SpawnType.INSTANT:
                transform.position = SpawnPos;
                transform.rotation = SpawnRot;
                break;
            case SpawnType.ANIMATED:
                animatedSpawn = StartCoroutine(AnimatedSpawn());
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(spawnType), spawnType, null);
        }
    }

    public IEnumerator AnimatedSpawn()
    {
        throw new MissingMethodException();
        yield return null;
    }
}
