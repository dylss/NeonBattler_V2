using System;
using System.Collections.Generic;
using Controller.Hexagon;
using Game.Model.Enums;
using UnityEngine;

namespace Game.Util.Pathfinding
{
    public class PathFindingNode : MonoBehaviour
    {
        public Vector2 coordinate;
        public List<GameObject> neighbours = new List<GameObject>();

        [HideInInspector]
        public bool isVisited = false;
        [HideInInspector]
        public float g = 0;
        [HideInInspector]
        public float h = 0;
        [HideInInspector]
        public float f = 0;
        
        private float _straightLineMultiplier = 1;
        
        public GameObject parent = null;


        
        public void Start()
        {
            neighbours = GetComponent<HexagonController>().neighboursList;
        }
        
        public void SetF(float straightLineMultiplier = 1)
        {
            _straightLineMultiplier = straightLineMultiplier;
            f = (g + h) / straightLineMultiplier;
        }
        
        public void ResetNode()
        {
            this.g = 0;
            this.h = 0;
            this.f = 0;
            this.isVisited = false;
            this.parent = null;
        }
    }
}