using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour {

	public float speed = 10.0f;

	void Update () {
		this.transform.Translate(Vector3.forward * speed);
	}
}
