using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarGenerator : MonoBehaviour {

	public Transform floorPrefeb;
	public GameObject carPrefeb;
	public float mapSize = 20;

	bool makeCar = true;

	List<Coord> allTileCoords;
	  
	public int sec = 1;
	float speed;
	public bool goForward = true;

	public void Start()
	{
		//InitPool(carPrefeb, 10);		

		goForward = Random.Range(0, 2) == 1;
		sec = Random.Range(1, 5);
		GenerateMap();
		StartCoroutine(GenerateCar(sec));

		//StartCoroutine(CarLoop());
	}


	public void GenerateMap()
	{

		allTileCoords = new List<Coord>();

		for (int x = 0; x < mapSize; x++)
		{
				allTileCoords.Add(new Coord(x, 0));
		}


		string holderName = "Generated Car";
		if (transform.Find(holderName))
		{
			DestroyImmediate(transform.Find(holderName).gameObject);
		}

		Transform mapHolder = new GameObject(holderName).transform;
		mapHolder.parent = transform;

		for (int x = 0; x < mapSize; x++)
		{
				Vector3 tilePosition = CoordToPosition(x, 0);
				Transform newTile = Instantiate(floorPrefeb, this.transform.position + tilePosition, Quaternion.Euler(Vector3.right * 0)) as Transform;
				newTile.parent = mapHolder;
		}

		//for(int i = 0; i < treeCount; i++)
		//{
		//	Coord randomCoord = GetRandomCoord();
		//	Vector3 obstaclePosition = CoordToPosition(randomCoord.x, randomCoord.y);
		//	Transform newObstacle = Instantiate(carPrefeb, obstaclePosition + Vector3.up * transform.localScale.y / 2, Quaternion.identity) as Transform;
		//	newObstacle.parent = mapHolder;
		//}

	}

	Vector3 CoordToPosition(int x, int y)
	{
		return new Vector3(-mapSize / 2 * floorPrefeb.transform.localScale.x + floorPrefeb.transform.localScale.x / 2 + x * floorPrefeb.transform.localScale.x, 0,
												   y * floorPrefeb.transform.localScale.y);
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
		speed = 0.1f / (float)sec;
		carPrefeb.GetComponent<CarMove>().speed = this.speed;

		while (makeCar)
		{
			if (goForward)
			{
				Vector3 tilePosition = CoordToPosition(0, 0);
				GameObject newCar = Instantiate(carPrefeb, this.transform.position + tilePosition + Vector3.up * carPrefeb.transform.localScale.y / 2, carPrefeb.transform.rotation) as GameObject;
			}
			else
			{
				Vector3 tilePosition = CoordToPosition((int)mapSize, 0);
				GameObject newCar = Instantiate(carPrefeb, this.transform.position +  tilePosition + Vector3.up * carPrefeb.transform.localScale.y / 2, Quaternion.Euler(Vector3.up * 270)) as GameObject;

			}
			yield return new WaitForSeconds(sec);
		}
	}


	////************************************
	////			CARCONTROLLER
	////************************************
	
	//private IEnumerator CarLoop(int sec)
	//{
	//	WaitForSeconds waitSec = new WaitForSeconds(sec);

	//	while (true)
	//	{
	//		UseObject(PopObject());

	//		yield return waitSec;
	//	}
	//}


	////오브젝트 사용, 발사
	//private void UseObject(GameObject obj)
	//{
	//	//오브젝트를 스테이지로 가져옴
	//	obj.transform.parent = this.transform;
	//	//위치 초기화
	//	obj.transform.localPosition = Vector3.zero;
	//	//오브젝트 활성화
	//	obj.SetActive(true);
	//	//오브젝트 발사 날아가기
	//	obj.GetComponent<Car>().FlyBullet(new CompleteDele(UseComplete));
	//}

	////사용 종료 처리
	//private void UseComplete(GameObject obj)
	//{
	//	//해당 오브젝트 풀로 이동
	//	PushObject(obj);
	//}



	////************************************
	////			POOLMANAGER
	////************************************
	//private List<GameObject> listObj;       //풀 오브젝트들이 들어갈 리스트
	//private Transform pool;                 //풀
	//private GameObject obj;                 //풀에 오브젝트가 없을 경우를 대비한 비상용 오브젝트

	////풀 초기화
	//public void InitPool(GameObject obj, int poolSize)
	//{
	//	//리스트 생성
	//	listObj = new List<GameObject>();
	//	//풀 캐싱
	//	pool = transform;
	//	//오브젝트
	//	this.obj = obj;

	//	for (int i = 0; i < poolSize; i++)
	//	{
	//		//오브젝트를 생성
	//		GameObject go = Instantiate(obj) as GameObject;
	//		//풀에 푸시함
	//		PushObject(go);
	//	}
	//}

	////풀에서 오브젝트를 하나 꺼냄
	//public GameObject PopObject()
	//{
	//	if (listObj.Count > 0)
	//	{
	//		GameObject obj = listObj[0];
	//		//리스트에서 제거
	//		listObj.RemoveAt(0);
	//		return obj;
	//	}
	//	else
	//	{   //없을 경우 만들어서 반환
	//		return Instantiate(obj) as GameObject;
	//	}
	//}

	////오브젝트 풀에 넣기
	//public void PushObject(GameObject obj)
	//{
	//	//오브젝트를 리스트에 넣음
	//	listObj.Add(obj);
	//	//오브젝트를 풀에 넣음
	//	obj.transform.parent = pool;
	//	//위치 초기화
	//	obj.transform.localPosition = Vector3.zero;
	//	//비활성화
	//	obj.SetActive(false);
	//}

	////풀 비우기
	//public void ClearPool()
	//{
	//	//리스트 null로 초기화 or Clear()
	//	listObj = null;

	//	//풀에 있는 자식 오브젝트 모두 제거
	//	foreach (Transform child in pool)
	//	{
	//		GameObject.Destroy(child.gameObject);
	//	}
	//}

}
