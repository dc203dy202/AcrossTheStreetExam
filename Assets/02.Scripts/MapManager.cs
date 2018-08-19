using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour {

	GameObject[,] objects = new GameObject[4, 20];


	public GameObject[] floors = new GameObject[4];
	public GameObject[] obstacles = new GameObject[4];
	int[] mapNum = {0, 0, 0, 0};
	int[,] mapSequence = new int[25, 2]; //맵 순서
	public int mapNow = 0;
	int mapCode; //랜덤 맵 변수
	int mapLevel;
	public int mapSize_x = 20;
	public int mapSize_z = 2;

	public int z_axis = 0;
	

	public void Start()
	{
		MakeMap();
		GameStart();
		
	}

	public void GameStart()
	{
		for (int i = 0; i < 15; i++)
		{
			LoadMap(mapCode, mapLevel);
		}
		for(int i = 0; i < 10; i++)
		{
			mapCode = Random.Range(0, 4);
			mapLevel= Random.Range(0, 5);
			LoadMap(mapCode, mapLevel);
		}


	}

	public void LoadMap(int mapCode, int mapLevel)
	{
		DeleteMap();
		Vector3 mapPosition = new Vector3(0, floors[mapCode].transform.localScale.y / 2, z_axis * mapSize_z);
		objects[mapCode, mapNum[mapCode]].transform.position = mapPosition; //zeroPosition에 있던 맵을 옮기고
		objects[mapCode, mapNum[mapCode]].SetActive(true); //활성시킨다
		mapSequence[mapNow, 0] = mapCode; //활성시킨 맵의 종류를 저장
		mapSequence[mapNow, 1] = mapNum[mapCode]; //활성시킨 맵의 번호를 저장


		//후처리
		mapNum[mapCode] = mapNum[mapCode] == 19 ? 0 : mapNum[mapCode] + 1; //이번에 사용한 맵의 종류에 ++하여 다음에 사용할 최신 맵 번호 지정
		mapNow = mapNow == 24 ? 0 : mapNow + 1; //다음 줄 순서 지정
		z_axis++;
	}

	public void DeleteMap()
	{
		objects[mapSequence[mapNow, 0], mapSequence[mapNow, 1]].SetActive(false);
	}

	public void MakeMap()
	{
		Vector3 zeroPosition = new Vector3(0, 0, 0);
		for(int i = 0; i < objects.GetLength(0); i++)
		{
			for(int j = 0; j < objects.GetLength(1); j++)
			{
				objects[i, j] = Instantiate(floors[i], zeroPosition, transform.rotation) as GameObject;
				objects[i, j].SetActive(false);
			}
		}
	}
}
