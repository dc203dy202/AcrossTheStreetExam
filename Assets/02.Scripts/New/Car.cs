using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void CompleteDele(GameObject data);

public class Car : MonoBehaviour
{
	public float speed = 10.0f;

	private CompleteDele dele;  //완료처리 델리게이트
	public BoxCollider col;     //충돌체

	//오브젝트 날아가기
	public void FlyBullet(CompleteDele dele)
	{
		this.dele = dele;
		//총돌 가능
		col.enabled = true;
		//fire!
		this.transform.Translate(Vector3.forward * speed);
	}

	//오브젝트 충돌 체크
	void OnTriggerEnter(Collider other)
	{
		//연속 충돌 방지
		col.enabled = false;

		//Force remove
		//rigid.velocity = Vector3.zero;
		//rigid.angularVelocity = Vector3.zero;



		//사용 완료 처리
		dele(gameObject);
	}

}
