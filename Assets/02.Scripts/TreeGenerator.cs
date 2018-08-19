﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGenerator : MonoBehaviour
{

	public Transform floorPrefeb;
	public Transform treePrefeb;
	public Vector2 mapSize;
	public int treeCount = 10;

	List<Coord> allTileCoords;
	Queue<Coord> shuffledTileCoords;

	public int seed = 10;

	private void Start()
	{
		GenerateMap();
	}

	public void GenerateMap()
	{

		allTileCoords = new List<Coord>();

		for (int x = 0; x < mapSize.x; x++)
		{
			for (int y = 0; y < mapSize.y; y++)
			{
				allTileCoords.Add(new Coord(x, y));
			}
		}
		shuffledTileCoords = new Queue<Coord>(Utility.ShuffleArray(allTileCoords.ToArray(), seed));


		string holderName = "Generated Tree";
		if (transform.Find(holderName))
		{
			DestroyImmediate(transform.Find(holderName).gameObject);
		}

		Transform mapHolder = new GameObject(holderName).transform;
		mapHolder.parent = transform;

		for (int x = 0; x < mapSize.x; x++)
		{
			for (int y = 0; y < mapSize.y; y++)
			{
				Vector3 tilePosition = CoordToPosition(x, y, floorPrefeb);
				Transform newTile = Instantiate(floorPrefeb, tilePosition, Quaternion.Euler(Vector3.right * 0)) as Transform;
				newTile.parent = mapHolder;
			}
		}

		for (int i = 0; i < treeCount; i++)
		{
			Coord randomCoord = GetRandomCoord();
			Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y, treePrefeb);
			Transform newObstacle = Instantiate(treePrefeb, obstaclePosition + Vector3.up * floorPrefeb.transform.localScale.y / 2, treePrefeb.transform.rotation) as Transform;
			newObstacle.parent = mapHolder;
		}

	}

	Vector3 CoordToPosition(int x, int y, Transform Prefeb)
	{
		return new Vector3(-mapSize.x / 2 * floorPrefeb.transform.localScale.x + floorPrefeb.transform.localScale.x / 2 + x * floorPrefeb.transform.localScale.x, floorPrefeb.transform.localScale.y / 2,
						   -mapSize.y / 2 * floorPrefeb.transform.localScale.z + floorPrefeb.transform.localScale.z / 2 + y * floorPrefeb.transform.localScale.z);
	}

	public Coord GetRandomCoord()
	{
		Coord randomCoord = shuffledTileCoords.Dequeue();
		shuffledTileCoords.Enqueue(randomCoord);
		return randomCoord;
	}

	public struct Coord
	{
		public int x;
		public int y;

		public Coord(int _x, int _y)
		{
			x = _x;
			y = _y;
		}
	}
}
