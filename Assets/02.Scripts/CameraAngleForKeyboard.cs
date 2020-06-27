using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAngleForKeyboard : MonoBehaviour
{

	public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		if (Input.GetKey(KeyCode.A))//왼
		{
			//transform.Translate(Vector3.left * speed * Time.deltaTime);
			//moveDirection = new Vector3(-speed, 0, 0);
			this.transform.Rotate(0.0f, -speed * Time.deltaTime, 0.0f);


		}
		else if (Input.GetKey(KeyCode.D))//오
		{
			//transform.Translate(Vector3.right * speed * Time.deltaTime);
			//moveDirection = new Vector3(speed, 0, 0);
			this.transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
		}
	}
}
