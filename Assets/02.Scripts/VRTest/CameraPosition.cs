using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour {
	//OVRCamera의 포지션과 Person의 포지션을 맞추는 소스입니다.

	public Transform Person;

	void Start()
	{

	}

	void LateUpdate () {
		this.transform.position = Person.position;
	}
}
