using UnityEngine;
using System.Collections;
using System;

public class GameScript : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int score;
	private int scoreBonus;
	private int scoreRisk;

	private System.Random rng;

	private Vector3 movement;

	public GUIText guiScore;

	void Start(){
		rng = new System.Random((int)DateTime.Now.Ticks);
		rb = GetComponent<Rigidbody>();
		scoreBonus = 0;
		scoreRisk = 1;
	}

	void Update(){
		if(transform.position.x > 40 || transform.position.x < -40 || transform.position.z > 40 || transform.position.z < -40){
			transform.Translate(0, 0, 0, Space.World);
		}
	}

	// Physics Code
	void FixedUpdate () {
		/**
		* Player Movement Code
		**/
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");

		movement = new Vector3(h, 0F, v);

		rb.AddForce(movement * speed);
	}

	void OnCollisionEnter(Collision col){
		if(col.gameObject.name == "Collectable"){
			col.gameObject.transform.position = new Vector3(rng.Next(-20, 20), transform.position.y, rng.Next(-20, 20));
			scoreBonus++;
			score += scoreBonus;
		} else if (col.gameObject.name == "Virus"){
			col.gameObject.transform.position = new Vector3(rng.Next(-20, 20), transform.position.y, rng.Next(-20, 20));
			scoreRisk += scoreBonus*2;
			score -= 1+(scoreRisk);
			scoreBonus = 0;
			scoreRisk = 1;
		}
		guiScore.text = score.ToString();
	}

}
