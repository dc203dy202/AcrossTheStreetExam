using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {

	public float movSpeed = 5.0f;
	public float rotSpeed = 120.0f;

	GameObject MapManager;

	

	void Start () {
		MapManager = GameObject.Find("MapManager");
		this.transform.position = new Vector3(0, 0, 10 * 2);

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKey(KeyCode.W))//앞
			transform.Translate(Vector3.forward * movSpeed * Time.deltaTime);
		else if (Input.GetKey(KeyCode.S))//뒤
			transform.Translate(Vector3.back * movSpeed * Time.deltaTime);
		else if (Input.GetKey(KeyCode.A))//왼
			transform.Translate(Vector3.left * movSpeed * Time.deltaTime);
		else if (Input.GetKey(KeyCode.D))//오
			transform.Translate(Vector3.right * movSpeed * Time.deltaTime);

		


	}
}
