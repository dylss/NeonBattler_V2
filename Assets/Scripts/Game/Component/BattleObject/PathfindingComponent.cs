using System;
using System.Collections.Generic;
using Component;
using Component.BattleObject;
using Game.Util.Pathfinding;
using UnityEngine;
using Random = System.Random;

namespace Game.Component.BattleObject
{
    //Responsible for creating, updating, showing, etc. paths
    public class PathfindingComponent : MonoBehaviour
    {
        public Queue<PathFindingNode> Path { get; private set; }
        public PathFindingNode PeekFirstNode => Path.Peek();
        public PathFindingNode UseFirstNode => Path.Dequeue();
        public PathFindingNode PeekSecondNode;

        public LineRenderer lineRenderer;

        [SerializeField] private bool drawGizmos;



        private void Awake()
        {
            
        }

        public void FindPath()
        {

        }

        private void OnDrawGizmos()
        {
            if (Path != null && Path.Count != 0 && drawGizmos)
            {
                PathFindingNode currentNode = null;
                PathFindingNode previousNode = null;
                foreach (PathFindingNode node in Path)
                {
                    previousNode = currentNode;
                    currentNode = node;
                    if (previousNode == null)
                    {
                        continue;
                    }
                    Gizmos.color = UnityEngine.Random.ColorHSV();
                    Gizmos.DrawLine(currentNode.transform.position, previousNode.transform.position);
                }
            }
        }
    }
}