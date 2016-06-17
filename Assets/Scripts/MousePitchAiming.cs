using UnityEngine;
using System.Collections;

public class MousePitchAiming : MonoBehaviour {
	public float mouseYSensitivity = 45.0F;

	// Update is called once per frame
	void Update () {
		if(transform.eulerAngles.x >= 270.1){
			transform.Rotate(Time.deltaTime * -Input.GetAxis("Mouse Y") * mouseYSensitivity, 0, 0);
		}else if (transform.eulerAngles.x < 270.1 && transform.eulerAngles.x > 269.9){
			if(-Input.GetAxis("Mouse Y") > 0){
				transform.Rotate(Time.deltaTime * -Input.GetAxis("Mouse Y") * mouseYSensitivity, 0, 0);
			}
		}

		if(transform.eulerAngles.x <= 89.9){
			transform.Rotate(Time.deltaTime * -Input.GetAxis("Mouse Y") * mouseYSensitivity, 0, 0);
		}else if (transform.eulerAngles.x > 89.9 && transform.eulerAngles.x < 90.1){
			if(-Input.GetAxis("Mouse Y") < 0){
				transform.Rotate(Time.deltaTime * -Input.GetAxis("Mouse Y") * mouseYSensitivity, 0, 0);
			}
		}
	}
}
