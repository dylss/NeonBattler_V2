using System;
using System.Collections.Generic;
using System.Linq;
using Game.Model.Enums;
using TMPro;
using UnityEngine;

namespace Controller.Hexagon
{
	public class HexagonController : MonoBehaviour
	{
		public enum HexDirections
		{
			NW,
			W,
			SW,
			SE,
			E,
			NE
		}

		public Transform payLoadSpawnTransform;
		public int GridIndex { get; set; }
		public HexCoordinates Coordinates { get; set; }
		public Dictionary<HexDirections, GameObject> neighbours = new Dictionary<HexDirections, GameObject>();
		public List<GameObject> neighboursList = new List<GameObject>();
		
		[SerializeField] private Transform ground;
		[SerializeField] private Transform air;
		private bool OccupyGround { get; set; }
		private bool OccupyAir { get; set; }
		
		public void SetDebugIndexText()
		{
			TextMeshProUGUI textMeshProUGUI = GetComponentInChildren<TextMeshProUGUI>();
			if (textMeshProUGUI != null)
			{
				textMeshProUGUI.text = GridIndex.ToString();
			}
		}

		public void SetNeighbours(List<GameObject> grid)
		{
			Dictionary<HexDirections, HexCoordinates> neighbourCoords;

			if(Coordinates.Row % 2 == 0)
			{
				neighbourCoords = GetEvenColumnNeighbourCoords();
			}
			else
			{
				neighbourCoords = GetUnevenColumnNeighbourCoords();
			}

			foreach(KeyValuePair<HexDirections, HexCoordinates> pair in neighbourCoords)
			{
				foreach(GameObject hex in grid)
				{
					if(hex.GetComponent<HexagonController>().Coordinates == pair.Value)
					{
						neighbours.Add(pair.Key, hex);
					}
				}
			}

			neighboursList = neighbours.Values.ToList();
		}

		public Dictionary<HexDirections, HexCoordinates> GetEvenColumnNeighbourCoords()
		{
			Dictionary<HexDirections, HexCoordinates> temp = new Dictionary<HexDirections, HexCoordinates>();

			temp.Add(HexDirections.NW, new HexCoordinates(-1 + Coordinates.Col, 1 + Coordinates.Row));
			temp.Add(HexDirections.W, new HexCoordinates(-1 + Coordinates.Col, 0 + Coordinates.Row));
			temp.Add(HexDirections.SW, new HexCoordinates(-1 + Coordinates.Col, -1 + Coordinates.Row));
			temp.Add(HexDirections.SE, new HexCoordinates(0 + Coordinates.Col, -1 + Coordinates.Row));
			temp.Add(HexDirections.E, new HexCoordinates(1 + Coordinates.Col, 0 + Coordinates.Row));
			temp.Add(HexDirections.NE, new HexCoordinates(0 + Coordinates.Col, 1 + Coordinates.Row));

			return temp;
		}

		public Dictionary<HexDirections, HexCoordinates> GetUnevenColumnNeighbourCoords()
		{
			Dictionary<HexDirections, HexCoordinates> temp = new Dictionary<HexDirections, HexCoordinates>();

			temp.Add(HexDirections.NW, new HexCoordinates(0 + Coordinates.Col, 1 + Coordinates.Row));
			temp.Add(HexDirections.W, new HexCoordinates(-1 + Coordinates.Col, 0 + Coordinates.Row));
			temp.Add(HexDirections.SW, new HexCoordinates(0 + Coordinates.Col, -1 + Coordinates.Row));
			temp.Add(HexDirections.SE, new HexCoordinates(1 + Coordinates.Col, -1 + Coordinates.Row));
			temp.Add(HexDirections.E, new HexCoordinates(1 + Coordinates.Col, 0 + Coordinates.Row));
			temp.Add(HexDirections.NE, new HexCoordinates(1 + Coordinates.Col, 1 + Coordinates.Row));

			return temp;
		}

		public List<GameObject> GetNeighbours()
		{
			return neighbours.Values.ToList();
		}

		public Vector3 GetPayLoadSpawnPosition()
		{
			return payLoadSpawnTransform.position;
		}
		
		public bool IsOccupied(BattleObjectGroundAirType battleObjectGroundAirType)
		{
			switch (battleObjectGroundAirType)
			{
				case BattleObjectGroundAirType.Ground:
					return OccupyGround;
				case BattleObjectGroundAirType.Air:
					return OccupyAir;
				default:
					throw new ArgumentOutOfRangeException(nameof(battleObjectGroundAirType), battleObjectGroundAirType, null);
			}
		}

		public void Occupy(BattleObjectGroundAirType battleObjectGroundAirType)
		{
			switch (battleObjectGroundAirType)
			{
				case BattleObjectGroundAirType.Ground:
					OccupyGround = true;
					break;
				case BattleObjectGroundAirType.Air:
					OccupyAir = true;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(battleObjectGroundAirType), battleObjectGroundAirType, null);
			}
		}
        
		public void Leave(BattleObjectGroundAirType battleObjectGroundAirType)
		{
			switch (battleObjectGroundAirType)
			{
				case BattleObjectGroundAirType.Ground:
					OccupyGround = false;
					break;
				case BattleObjectGroundAirType.Air:
					OccupyAir = false;
					break;
				default:
					throw new ArgumentOutOfRangeException(nameof(battleObjectGroundAirType), battleObjectGroundAirType, null);
			}
		}
	}
}
