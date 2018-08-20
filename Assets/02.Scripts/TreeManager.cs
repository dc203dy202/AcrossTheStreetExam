using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	public Transform floorPrefeb;
	public GameObject treePrefeb;

	public GameObject[] trees = new GameObject[20];
	bool[] treeArray = new bool[20];

	public float mapSize = 20;
	public int treeCount = 10;

	Vector3 zeroPosition;

	bool shuffled = false;

	public void Start()
	{
		zeroPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		MakeTree();
		CallManager();
	}

	public void Update()
	{
		if(gameObject.activeSelf != true && shuffled != false)
		{
			CallManager();
			shuffled = true;
		}
		if (gameObject.activeSelf)
		{
			shuffled = false;
		}
	}

	public void CallManager()
	{
		int randomLevel = Random.Range(0, 5);
		SetTreeNumber(randomLevel + 5);
		for(int i = 0; i < treeArray.Length; i++)
		{
			if (treeArray[i])
			{
				trees[i].SetActive(true);
			}
		}
	}

	public void MakeTree()
	{
		Transform newFloor = Instantiate(floorPrefeb, zeroPosition + new Vector3(0, floorPrefeb.localScale.y / 2, 0), transform.rotation) as Transform;
		newFloor.parent = this.transform;
		for (int i = 0; i < 20; i++)
		{
			trees[i] = Instantiate(treePrefeb, zeroPosition + new Vector3(i * 2 - floorPrefeb.localScale.x / 2 + 1, floorPrefeb.localScale.y , 0), this.transform.rotation) as GameObject;
			//Debug.Log(treePrefeb.transform.localScale.y);	
			//trees[i].SetActive(false);
			trees[i].transform.parent = newFloor;
		}
	}

	public void SetTreeNumber(int number)
	{
		for (int i = 0; i < treeArray.Length; i++)
		{
			treeArray[i] = false;
			trees[i].SetActive(false);
		}
		for (int i = 0; i < number; i++)
		{
			treeArray[i] = true;
		}

		ShuffleTree(treeArray);
	}

	public void ShuffleTree(bool[] array)
	{
		System.Random prng = new System.Random();

		for(int i = 0; i < array.Length - 1; i++)
		{
			int randomIndex = prng.Next(i, array.Length);
			bool tempItem = array[randomIndex];
			array[randomIndex] = array[i];
			array[i] = tempItem;
		}

	}
	IEnumerator aaa()
	{
		CallManager();
		yield return new WaitForSeconds(1);
	}
}
