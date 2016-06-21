using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	void Update(){
		if(Input.GetButtonDown("Fire1")){
			RaycastHit hit;
			Ray bulletRay = new Ray(transform.position, transform.forward);
			if(Physics.Raycast(bulletRay, out hit)){
				Debug.Log(hit.collider.tag);
				Debug.DrawLine (transform.position, hit.point, Color.red);
				if(hit.collider.tag == "Enemy"){
					hit.collider.gameObject.SetActive(false);
				}
			}
		}
	}
}
