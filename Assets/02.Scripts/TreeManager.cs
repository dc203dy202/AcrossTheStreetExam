using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeManager : MonoBehaviour {

	public Transform floorPrefeb;
	public GameObject treePrefeb;

	public GameObject[] trees = new GameObject[20];

	public float mapSize = 20;
	public int treeCount = 10;

	Vector3 zeroPosition;

	public void Start()
	{
		zeroPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		
		MakeTree();
	}
	

	public void MakeTree()
	{
		Transform newFloor = Instantiate(floorPrefeb, zeroPosition + new Vector3(0, 0, 1), transform.rotation) as Transform;
		for (int i = 0; i < 20; i++)
		{
			trees[i] = Instantiate(treePrefeb, zeroPosition + new Vector3(i * 2 - floorPrefeb.localScale.x / 2 + 1, 0, 1), this.transform.rotation) as GameObject;
			//trees[i].SetActive(false);
			
		}
	}

}
