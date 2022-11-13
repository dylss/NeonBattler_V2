using System.Collections.Generic;
using System.Linq;
using Controller.Hexagon;
using TMPro;
using UnityEngine;

namespace Game.Util.Pathfinding
{
	public class PathFinder
	{
		public static List<GameObject> CreatePathList(GameObject startHex, GameObject endHex, List<GameObject> grid, BattleObjectController battleObjectController)
		{
			if(battleObjectController == null || startHex == null || endHex == null)
			{
				return null;
			}
			
			//Initialise pathlist
			List<GameObject> pathList = new List<GameObject>();

			//Get all the battlegroundhexagons as a gameobjectsList
			List<GameObject> hexagons = grid;

			//Initialise pathfinding lists
			List<GameObject> unvisited = new List<GameObject>();
			List<GameObject> visited = new List<GameObject>();

			//Reset all the nodes
			ResetPathfindingNodes(hexagons);

			//Set the startingvalues
			NodeScript(startHex).g = 0;
			NodeScript(startHex).h = Distance(startHex, endHex);
			NodeScript(startHex).SetF(1);

			//Add the startHex to start off the pathfinding algorithm
			unvisited.Add(startHex);

			GameObject currentHex = startHex;

			while(unvisited.Count != 0)
			{
				currentHex = GetLowestF(unvisited);
				unvisited.Remove(currentHex);
				visited.Add(currentHex);

				//If end is reached
				if(currentHex == endHex)
				{
					visited.Add(currentHex);
					pathList = BacktrackPath(startHex, currentHex, visited);
					return pathList;
				}

				//Determines the vector between currenthex and parent for straightline comparison
				Vector3 vector3CurrentHexParentHex = currentHex.transform.position;
				if(NodeScript(currentHex).parent != null)
				{
					vector3CurrentHexParentHex = currentHex.transform.position - NodeScript(currentHex).parent.transform.position;
				}

				//Loops through all the neighbours of the currentHexagon
				foreach(GameObject neighbour in NodeScript(currentHex).neighbours)
				{
					//Check if the neighbour is not the endhex or is not available or visitedlist already contains the neighbour
					if(neighbour != endHex && !neighbour.GetComponent<HexagonController>().IsOccupied(battleObjectController.settings.battleObjectGroundAirType) || visited.Contains(neighbour))
					{
						continue;
					}

					//Compare vectors to determine if it's a straight line
					Vector3 vector3NeighbourHexCurrentHex = neighbour.transform.position - currentHex.transform.position;
					float straightLineMultiplier = 1;
					if(vector3CurrentHexParentHex.Compare(vector3NeighbourHexCurrentHex, 5))
					{
						straightLineMultiplier = 1.1f;
					}

					NodeScript(neighbour).parent = currentHex;
					NodeScript(neighbour).g = NodeScript(currentHex).g + 1;
					NodeScript(neighbour).h = Distance(neighbour, endHex);
					NodeScript(neighbour).SetF(straightLineMultiplier);

					if(unvisited.Contains(neighbour))
					{
						if(IsNeighbourGLowerThanUnvisitedG(neighbour, unvisited))
						{
							continue;
						}
					}
					unvisited.Add(neighbour);
				}
			}
			return pathList;
		}

		/// <summary>
		/// Compares the g value from the neighbour to all the unvisited g values.
		/// </summary>
		/// <param name="neighbour"></param>
		/// <param name="unvisited"></param>
		/// <returns></returns>
		private static bool IsNeighbourGLowerThanUnvisitedG(GameObject neighbour, List<GameObject> unvisited)
		{
			foreach(GameObject hex in unvisited)
			{
				if(NodeScript(neighbour).g < NodeScript(hex).g)
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Track back the path from the end to the start by using the parents. Than reverse the list.
		/// </summary>
		/// <param name="visited"></param>
		/// <returns></returns>
		private static List<GameObject> BacktrackPath(GameObject startHex, GameObject currentHex, List<GameObject> visited)
		{
			List<GameObject> backtrackPath = new List<GameObject>();
			while(NodeScript(currentHex).parent != null)
			{
				backtrackPath.Add(currentHex);
				foreach(GameObject hex in visited)
				{
					if(NodeScript(currentHex).parent == hex)
					{
						currentHex = hex;
						break;
					}
				}
			}
			backtrackPath.Reverse();
			return backtrackPath;
		}

		/// <summary>
		/// Resets all the nodes with resetvalues
		/// </summary>
		/// <param name="hexagons"></param>
		private static void ResetPathfindingNodes(List<GameObject> hexagons)
		{
			foreach(GameObject hex in hexagons)
			{
				hex.GetComponent<PathFindingNode>().ResetNode();
			}
		}

		/// <summary>
		/// Easy reference to the NodeScript of every hexagon.
		/// </summary>
		/// <param name="hex"></param>
		/// <returns></returns>
		private static PathFindingNode NodeScript(GameObject hex)
		{
			return hex.GetComponent<PathFindingNode>();
		}

		/// <summary>
		/// Calculates the H (heuristic).
		/// </summary>
		/// <param name="currentHex"></param>
		/// <param name="endHex"></param>
		/// <returns></returns>
		private static float Distance(GameObject currentHex, GameObject endHex)
		{
			return Vector3.Distance(currentHex.transform.position, endHex.transform.position);
		}

		/// <summary>
		/// Determines which hexagon has the lowest F-score and returns it.
		/// </summary>
		/// <param name="unvisited"></param>
		/// <returns>Hexagon with the lowest F-score</returns>
		private static GameObject GetLowestF(List<GameObject> unvisited)
		{
			GameObject current = unvisited.First();

			//create iterator to find the lowest f value and remove that element from unvisited and add it to visited
			foreach(GameObject hex in unvisited)
			{
				if(current.GetComponent<PathFindingNode>().f > hex.GetComponent<PathFindingNode>().f)
				{
					current = hex;
				}
			}
			return current;
		}
	}
}