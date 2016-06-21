using UnityEngine;
using System.Collections;

public class ViewmodelRecoil : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			animation.Stop("Recoil");
			animation.Play("Recoil");
		}
	}
}
