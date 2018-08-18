using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMove : MonoBehaviour {

	public float Speed = 20.0f;
	//float nowAngle = 0.0f;

	Vector2 InputPoint;  //터치패드 좌표

	// Update is called once per frame
	void Update ()
	{
		//if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKey(KeyCode.Space))
		//{
		//this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);
		//}

		InputPoint = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);  //터치패드 좌표를 받아옴

		if (OVRInput.Get(OVRInput.Button.PrimaryTouchpad)) //터치패드가 눌린 경우의 처리
		{
			if(InputPoint.y > 0)  //터치패드의 y좌표가 0보다 큰 경우의 처리
			{
				this.transform.Translate(Vector3.forward * Speed * Time.deltaTime);  //전진
			}
			if(InputPoint.y < 0)  //터치패드의 y좌표가 0보다 작은 경우의 처리
			{
				this.transform.Translate(Vector3.back * Speed * Time.deltaTime);  //후진
			}
		}


		//nowAngle = this.transform.rotation.y;
		//this.transform.Rotate(new Vector3(0.0f, nowAngle, 0.0f));
	}
}
