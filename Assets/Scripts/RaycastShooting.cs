using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public int bulletDamage = 20;
	public float timeBetweenBullets = 0.01f;
	public float bulletRange = 200f;
	public Camera cam;

	Ray bulletRay;
	RaycastHit bulletHit;
	int shootableMask;
	LineRenderer gunLine;
	float effectsDisplayTime = 0.4f;
	float timer;

	void Awake(){
		shootableMask = 8;
		gunLine = transform.Find("Tesla").gameObject.GetComponent<LineRenderer>();
	}

	void Update(){
		timer += Time.deltaTime;

		if(Input.GetButtonDown("Fire1")){
			Shoot();
		}

		if(timer >= timeBetweenBullets * effectsDisplayTime){
			DisableEffects();
		}
	}

	public void DisableEffects(){
		gunLine.enabled = false;
	}

	void Shoot(){
		timer = 0.0F;

		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position + new Vector3(0.2F, -0.1F, 0.3F));

		bulletRay = cam.ScreenPointToRay(new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0));

		if(Physics.Raycast(bulletRay, out bulletHit, bulletRange)){
			if(bulletHit.collider.tag == "Enemy"){
				bulletHit.collider.gameObject.SetActive(false);
			}
			gunLine.SetPosition(1, bulletHit.point);
		} else {
			gunLine.SetPosition(1, bulletRay.origin + bulletRay.direction * bulletRange);
		}
	}
}
