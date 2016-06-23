using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	void FixedUpdate(){
		RaycastHit hit;
		Ray bulletRay = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

		if(Input.GetButtonDown("Fire1")){
			if(Physics.Raycast(bulletRay, out hit)){
				Debug.Log(hit.collider.tag);
				if(hit.collider.tag == "Enemy"){
					hit.collider.gameObject.SetActive(false);
					Debug.Log("Deadzo!");
				}
			}
		}
	}
}
