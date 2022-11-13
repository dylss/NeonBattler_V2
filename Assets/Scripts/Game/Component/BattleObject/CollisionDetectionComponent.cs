using System;
using System.Collections.Generic;
using Model;
using RoboRyanTron.Unite2017.Events;
using ScriptableObjects.RuntimeSets;
using UnityEngine;
using UnityEngine.Events;

namespace Component.BattleObject
{
    
    [RequireComponent(typeof(Collider))]
    public class CollisionDetectionComponent : MonoBehaviour
    {
        public UnityEvent<Collision> collisionEnterEvent;

        private void OnCollisionEnter(Collision other)
        {
            collisionEnterEvent?.Invoke(other);
        }
    }
}