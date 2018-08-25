using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	public GameObject treePrefeb;
	public PoolManager poolManager;
	bool[] treeArray = new bool[20];
	public Vector3 startPosition;



	public void Start()
	{

		startPosition = new Vector3(-2, 0, 0);

		//풀 초기화
		poolManager.InitPool(treePrefeb, 20);

		MakeTree(1);
	}

	public void MakeTree(int level)
	{
		//treeArray 초기화
		for (int i = 0; i < 20; i++) treeArray[i] = false;
		//tree 개수 설정
		for (int i = 0; i < 10 + level; i++)
		{
			treeArray[i] = true;
		}
		ShuffleTree(ref treeArray);

		for (int i = 0; i < 20; i++)
		{
			if (treeArray[i])
			{
				UseObject(poolManager.PopObject(), startPosition + new Vector3(i * 0.05f, 0, 0));
			}
			//trees[i] = Instantiate(treePrefeb, transform.position + new Vector3(i * 2 - floorPrefeb.localScale.x / 2 + 1, floorPrefeb.localScale.y, 0), this.transform.rotation) as GameObject;
			////Debug.Log(treePrefeb.transform.localScale.y);	
			////trees[i].SetActive(false);
			//trees[i].transform.parent = newFloor;
		}
	}

	public void ShuffleTree(ref bool[] _array)
	{
		System.Random prng = new System.Random();
		bool[] array = _array;

		for (int i = 0; i < array.Length - 1; i++)
		{
			int randomIndex = prng.Next(i, array.Length);
			bool tempItem = array[randomIndex];
			array[randomIndex] = array[i];
			array[i] = tempItem;

		}
	}


	//오브젝트 사용
	public void UseObject(GameObject obj, Vector3 position)
	{
		//오브젝트를 스테이지로 가져옴
		obj.transform.parent = this.transform;
		//위치 초기화
		obj.transform.localPosition = position;
		//오브젝트 활성화
		obj.SetActive(true);
	}


	//사용 종료 처리
	public void UseComplete(GameObject obj)
	{
		//해당 오브젝트 풀로 이동
		poolManager.PushObject(obj);
	}


	//public Transform floorPrefeb;
	//public GameObject treePrefeb;
	//public Transform pool;

	//public GameObject[] trees = new GameObject[20];
	//bool[] treeArray = new bool[20];

	//public float mapSize = 20;
	//public int treeCount = 10;

	//Vector3 zeroPosition;

	//bool shuffled = false;

	//public void Start()
	//{
	//	zeroPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);

	//	MakeTree();
	//	CallManager();
	//}

	//public void Update()
	//{


	//	////object가 active false 되어버리면 셔플을 수행할 수 없다.
	//	//if(gameObject.activeSelf == false && shuffled == false)
	//	//{
	//	//	Debug.Log("Active False");
	//	//	CallManager();
	//	//	shuffled = true;
	//	//}
	//	//if (shuffled == true && gameObject.activeSelf)
	//	//{
	//	//	shuffled = false;
	//	//}
	//}

	//public void CallManager()
	//{
	//	int randomLevel = Random.Range(0, 5);
	//	SetTreeNumber(randomLevel + 5);
	//	for (int i = 0; i < treeArray.Length; i++)
	//	{
	//		if (treeArray[i])
	//		{
	//			trees[i].SetActive(true);
	//		}
	//		else
	//		{
	//			trees[i].SetActive(false);
	//		}
	//	}
	//}

	//public void MakeTree()
	//{
	//	Transform newFloor = Instantiate(floorPrefeb, zeroPosition + new Vector3(0, floorPrefeb.localScale.y / 2, 0), transform.rotation) as Transform;
	//	newFloor.parent = this.transform;
	//	for (int i = 0; i < 20; i++)
	//	{
	//		trees[i] = Instantiate(treePrefeb, zeroPosition + new Vector3(i * 2 - floorPrefeb.localScale.x / 2 + 1, floorPrefeb.localScale.y, 0), this.transform.rotation) as GameObject;
	//		//Debug.Log(treePrefeb.transform.localScale.y);	
	//		//trees[i].SetActive(false);
	//		//trees[i].transform.parent = newFloor;
	//		//trees[i].transform.parent = pool;
	//	}
	//}

	//public void SetTreeNumber(int number)
	//{
	//	for (int i = 0; i < treeArray.Length; i++)
	//	{
	//		treeArray[i] = false;
	//		trees[i].SetActive(false);
	//	}
	//	for (int i = 0; i < number; i++)
	//	{
	//		treeArray[i] = true;
	//	}

	//	treeArray = ShuffleTree(treeArray);
	//	//ShuffleTree(treeArray);
	//}

	//public bool[] ShuffleTree(bool[] _array)
	//{
	//	System.Random prng = new System.Random();
	//	bool[] array = _array;

	//	for (int i = 0; i < array.Length - 1; i++)
	//	{
	//		int randomIndex = prng.Next(i, array.Length);
	//		bool tempItem = array[randomIndex];
	//		array[randomIndex] = array[i];
	//		array[i] = tempItem;
	//	}

	//	return array;

	//}
}
