using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour {

	private List<GameObject> listObj;       //풀 오브젝트들이 들어갈 리스트
	private Transform pool;                 //풀
	private GameObject obj;                 //풀에 오브젝트가 없을 경우를 대비한 비상용 오브젝트

	//풀 초기화
	public void InitPool(GameObject obj, int poolSize)
	{
		//리스트 생성
		listObj = new List<GameObject>();
		//풀 캐싱
		pool = transform;
		//오브젝트
		this.obj = obj;

		for (int i = 0; i < poolSize; i++)
		{
			//오브젝트를 생성
			GameObject go = Instantiate(obj) as GameObject;
			//풀에 푸시함
			PushObject(go);
		}
	}

	//풀에서 오브젝트를 하나 꺼냄
	public GameObject PopObject()
	{
		if (listObj.Count > 0)
		{
			GameObject obj = listObj[0];
			//리스트에서 제거
			listObj.RemoveAt(0);
			return obj;
		}
		else
		{   //없을 경우 만들어서 반환
			return Instantiate(obj) as GameObject;
		}
	}

	//오브젝트 풀에 넣기
	public void PushObject(GameObject obj)
	{
		//오브젝트를 리스트에 넣음
		listObj.Add(obj);
		//오브젝트를 풀에 넣음
		obj.transform.parent = pool;
		//위치 초기화
		obj.transform.localPosition = Vector3.zero;
		//비활성화
		obj.SetActive(false);
	}

	//풀 비우기
	public void ClearPool()
	{
		//리스트 null로 초기화 or Clear()
		listObj = null;

		//풀에 있는 자식 오브젝트 모두 제거
		foreach (Transform child in pool)
		{
			GameObject.Destroy(child.gameObject);
		}
	}


	//출처: http://teddy.tistory.com/21 [Teddy Games]
}
