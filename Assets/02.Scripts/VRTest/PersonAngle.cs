using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonAngle : MonoBehaviour {
	//Person의 방향을 카메라의 방향으로 바꿔주기 위한 소스입니다.


	//OVRCameraRig의 CenterEyeAnchor
	public Transform CameraAngle;

	void Start()
	{
	}
	
	void LateUpdate () {
		//this.transform.rotation = CameraAngle.rotation;

		//this.transform.Rotate(new Vector3(0, CameraAngle.rotation.y, 0));
		//자식.transform.localRotation = Quaternion.Euler(부모.rotation.eulerAngles.x, 부모.rotation.eulerAngles.y, 0.0f);
		this.transform.rotation = Quaternion.Euler(0.0f, CameraAngle.rotation.eulerAngles.y, 0.0f);
	}
}
