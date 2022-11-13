using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct HexCoordinates
{
	[SerializeField]
	private int col, row;

	public int Col
	{
		get
		{
			return col;
		}
	}

	public int Row
	{
		get
		{
			return row;
		}
	}

	public HexCoordinates(int col, int row)
	{
		this.col = col;
		this.row = row;
	}

	public static HexCoordinates FromOffsetCoordinates(int col, int row)
	{
		return new HexCoordinates(col - row / 2, row);
	}

	public static bool operator ==(HexCoordinates hexCoords1, HexCoordinates hexCoords2)
	{
		return hexCoords1.Equals(hexCoords2);
	}

	public static bool operator !=(HexCoordinates hexCoords1, HexCoordinates hexCoords2)
	{
		return !hexCoords1.Equals(hexCoords2);
	}

	public override string ToString()
	{
		return "(" +
			Col.ToString() + ", " + Row.ToString() + ")";
	}

	public string ToStringOnSeparateLines()
	{
		return Col.ToString() + "\n" + Row.ToString();
	}
}
