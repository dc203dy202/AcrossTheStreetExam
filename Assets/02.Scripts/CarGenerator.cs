using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarGenerator : MonoBehaviour {

	public Transform tilePrefeb;
	public GameObject obstaclePrefeb;
	public Vector2 mapSize;
	bool makeCar = true;

	List<Coord> allTileCoords;
	
	public int sec = 1;
	float speed;
	public bool goForward = true;

	public void Start()
	{
		GenerateMap();
		
		StartCoroutine(GenerateCar(sec));
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


		string holderName = "Generated Car";
		if (transform.Find(holderName))
		{
			DestroyImmediate(transform.Find(holderName).gameObject);
		}

		Transform mapHolder = new GameObject(holderName).transform;
		mapHolder.parent = transform;

		for(int x = 0; x < mapSize.x; x++)
		{
			for(int y = 0; y < mapSize.y; y++)
			{
				Vector3 tilePosition = CoordToPosition(x, y);
				Transform newTile = Instantiate(tilePrefeb, tilePosition, Quaternion.Euler(Vector3.right * 90)) as Transform;
				newTile.parent = mapHolder;
			}
		}

		//for(int i = 0; i < obstacleCount; i++)
		//{
		//	Coord randomCoord = GetRandomCoord();
		//	Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y);
		//	Transform newObstacle = Instantiate(obstaclePrefeb, obstaclePosition + Vector3.up * transform.localScale.y / 2, Quaternion.identity) as Transform;
		//	newObstacle.parent = mapHolder;
		//}

	}

	Vector3 CoordToPosition(int x, int y)
	{
		return new Vector3(-mapSize.x / 2 * tilePrefeb.transform.localScale.x + tilePrefeb.transform.localScale.x / 2 + x * tilePrefeb.transform.localScale.x, 0,
												   -mapSize.y / 2 * tilePrefeb.transform.localScale.y + tilePrefeb.transform.localScale.y / 2 + y * tilePrefeb.transform.localScale.y);
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

	IEnumerator GenerateCar(int sec)
	{
		speed = 1 / (float)sec;
		obstaclePrefeb.GetComponent<CarMove>().speed = this.speed;

		while (makeCar)
		{
			if (goForward)
			{
				Vector3 tilePosition = CoordToPosition(0, 0);
				GameObject newCar = Instantiate(obstaclePrefeb, tilePosition + Vector3.up * obstaclePrefeb.transform.localScale.y / 2, obstaclePrefeb.transform.rotation) as GameObject;
			}
			else
			{
				Vector3 tilePosition = CoordToPosition((int)mapSize.x, 0);
				GameObject newCar = Instantiate(obstaclePrefeb, tilePosition + Vector3.up * obstaclePrefeb.transform.localScale.y / 2, Quaternion.Euler(Vector3.up * 270)) as GameObject;
				
			}
			yield return new WaitForSeconds(sec);
		}
	}
}
