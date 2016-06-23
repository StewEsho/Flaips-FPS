using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public int bulletDamage = 20;
	public float timeBetweenBullets = 0.15f;
	public float bulletRange = 200f;

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

		if(Input.GetButton("Fire1") && timer >= timeBetweenBullets){
			Shoot();
		}

		if(timer >= timeBetweenBullets * effectsDisplayTime){
			// DisableEffects();
		}
	}

	public void DisableEffects(){
		gunLine.enabled = false;
	}

	void Shoot(){
		timer = 0.0F;

		gunLine.enabled = true;
		gunLine.SetPosition(0, transform.position);

		bulletRay = new Ray(transform.position, transform.forward);

		if(Physics.Raycast(bulletRay, out bulletHit, bulletRange, shootableMask)){
			GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			sphere.transform.position = bulletHit.point;
			gunLine.SetPosition(1, bulletHit.point);
		} else {
			gunLine.SetPosition(1, bulletRay.origin + bulletRay.direction * bulletRange);
		}
	}
}
