using UnityEngine;
using System.Collections;

public class RaycastShooting : MonoBehaviour {

	public int bulletDamage = 20;
	public float timeBetweenBullets = 0.01f;
	public float bulletRange = 200f;
	public int ammoCount = 6;
	public Camera cam;
	public GUIText ammoCountText;
	public GUIText scoreText;

	Ray bulletRay;
	RaycastHit bulletHit;
	int shootableMask;
	LineRenderer gunLine;
	float effectsDisplayTime = 0.35f;
	float timer;
	AudioSource[] aSources;
	int maxAmmo;

	void Awake(){
		maxAmmo = ammoCount;
		shootableMask = 8;
		gunLine = transform.GetChild(0).gameObject.GetComponent<LineRenderer>();
		ammoCountText.text = ammoCount.ToString();
		scoreText.text = GlobalValues.score.ToString();
		aSources = GetComponents<AudioSource>();
	}

	void Update(){
		timer += Time.deltaTime;

		ammoCountText.text = ammoCount.ToString();
		scoreText.text = GlobalValues.score.ToString();

		if(Input.GetButtonDown("Fire1") && timer > timeBetweenBullets){
			Shoot();
		}

		if(Input.GetButtonDown("Reload")){
			Reload();
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
		if(ammoCount > 0){
			ammoCount -= 1;

			transform.GetChild(0).GetComponent<AudioSource>().Stop();
			transform.GetChild(0).GetComponent<AudioSource>().Play();

			transform.GetChild(0).animation.Stop("Recoil");
			transform.GetChild(0).animation.Play("Recoil");

			gunLine.enabled = true;
			gunLine.SetPosition(0, transform.position + new Vector3(0, -0.3F, 0));

			bulletRay = cam.ScreenPointToRay(new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0));

			if(Physics.Raycast(bulletRay, out bulletHit, bulletRange)){
				if(bulletHit.collider.tag == "Enemy"){
					bulletHit.collider.GetComponent<AINav>().Damage(bulletDamage);
				}
				gunLine.SetPosition(1, bulletHit.point);
			} else {
				gunLine.SetPosition(1, bulletRay.origin + bulletRay.direction * bulletRange);
			}
		} else{
			aSources[0].Stop();
			aSources[0].Play();
		}
	}

	void Reload(){
		if(ammoCount < maxAmmo){
			timer = (timeBetweenBullets-0.5f);
			ammoCount = maxAmmo;
			aSources[1].Stop();
			aSources[1].Play();
			transform.GetChild(0).animation.Stop("Reload");
			transform.GetChild(0).animation.Play("Reload");
		}
	}
}
