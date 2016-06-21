using UnityEngine;
using System.Collections;

public class Tracer : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1")){
			gameObject.SetActive(true);
		}
	}
}
