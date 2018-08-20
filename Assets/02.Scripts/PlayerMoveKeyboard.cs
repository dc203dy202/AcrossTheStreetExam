using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour {

	public float speed = 5.0f;
	public float gravity = 20.0f;

	private CharacterController controller;
	Vector3 moveDirection;

	int beforeZ;

	GameObject MapManager;

	

	void Start () {
		controller = GetComponent<CharacterController>();
		MapManager = GameObject.Find("MapManager");
		this.transform.position = new Vector3(0, 0, 10 * 2);
		beforeZ = (int) this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (true) //controller.isGrounded 수정
		{
			if (Input.GetKey(KeyCode.W) || (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).y > 0))//앞
			{
				//transform.Translate(Vector3.forward * speed * Time.deltaTime);
				moveDirection = new Vector3(0, 0, speed);
			}
			else if ((Input.GetKey(KeyCode.S) || (OVRInput.Get(OVRInput.Button.PrimaryTouchpad) && OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad).y < 0))
				&& this.transform.position.z > beforeZ - 2 * 5)//뒤
			{
				//transform.Translate(Vector3.back * speed * Time.deltaTime);
				moveDirection = new Vector3(0, 0, -speed);
			}
			else if (Input.GetKey(KeyCode.A))//왼
			{
				//transform.Translate(Vector3.left * speed * Time.deltaTime);
				moveDirection = new Vector3(-speed, 0, 0);
			}
			else if (Input.GetKey(KeyCode.D))//오
			{
				//transform.Translate(Vector3.right * speed * Time.deltaTime);
				moveDirection = new Vector3(speed, 0, 0);
			}
			moveDirection = transform.TransformDirection(moveDirection);
		}

		moveDirection.y -= gravity * Time.deltaTime;

		controller.Move(moveDirection * Time.deltaTime);
		moveDirection = new Vector3(0, 0, 0);

		CallLoadMap();


	}

	public void CallLoadMap()
	{
		if(this.transform.position.z > beforeZ + 2)
		{
			MapManager.GetComponent<MapManager>().LoadMap((int)Random.Range(0.0f, 4.0f), (int)Random.Range(0.0f, 5.0f));
			beforeZ += 2;
		}
	}
}
