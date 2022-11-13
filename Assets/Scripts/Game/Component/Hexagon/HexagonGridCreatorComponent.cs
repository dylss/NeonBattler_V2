using System;
using System.Collections.Generic;
using System.Linq;
using Controller.Hexagon;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;

namespace Component
{
    public class HexagonGridCreatorComponent : MonoBehaviour
    {
        public GameObject hexHolder;
        public GameObject hexagonPrefab;
        public List<GameObject> grid = new List<GameObject>();
        public SerializedDictionary<int, GameObject> hexIndices = new SerializedDictionary<int, GameObject>();

        [Header("Grid size")]
        public int columns;
        public int rows;
        
        [Header("Extra")]
        public float hexDiameter = 5f;
        public float yOffset = 0.7f;

        public void Build()
        {
            grid = new List<GameObject>();
            hexIndices = new SerializedDictionary<int, GameObject>();

            //Distance calculated by the CAS rule cos = A/S
            float xDistance = Mathf.Cos(Mathf.Deg2Rad * 30) * hexDiameter;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    GameObject hex;
                    HexagonController hexagonController;
                    
                    HexCoordinates hexCoordinate = new HexCoordinates(col, row);

                    //Even rows
                    if (row % 2 == 0)
                    {
                        hex = Instantiate(hexagonPrefab, new Vector3(col * hexDiameter, yOffset, row * xDistance),
                            Quaternion.identity, hexHolder.transform);
                        hexagonController = hex.GetComponent<HexagonController>();
                    }

                    //Uneven rows
                    else
                    {
                        hex = Instantiate(hexagonPrefab,
                            new Vector3(col * hexDiameter + hexDiameter / 2f, yOffset, row * xDistance),
                            Quaternion.identity, hexHolder.transform);
                        hexagonController = hex.GetComponent<HexagonController>();
                    }

                    int gridIndex = col + columns * row;
                    
                    grid.Add(hex);
                    hexIndices.Add(gridIndex, hex);
                    
                    //Hex data
                    hex.name = "Hex: " + gridIndex;
                    hexagonController.Coordinates = hexCoordinate;
                    hexagonController.GridIndex = gridIndex;
                    hexagonController.SetDebugIndexText();
                }
            }

            foreach (GameObject hex in grid)
            {
                hex.GetComponent<HexagonController>().SetNeighbours(grid);
            }
        }

        public void Rebuild()
        {
            Clear();

            Build();
        }

        public void Clear()
        {
            foreach (GameObject hex in grid)
            {
                DestroyImmediate(hex);
            }
            
            if(grid != null && grid.Count != 0) grid.Clear();
            if(hexIndices != null && hexIndices.Count != 0) hexIndices.Clear();
        }

        public Vector3 GetSpawnPosFromGridIndex(int gridIndex)
        {
            if (hexIndices.TryGetValue(gridIndex, out var hex))
            {
                return hex.GetComponent<HexagonController>().GetPayLoadSpawnPosition();
            }

            throw new ArgumentOutOfRangeException("GridIndex out of range: "+ gridIndex.ToString());
        }
    }
}