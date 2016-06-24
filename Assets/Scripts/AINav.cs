using UnityEngine;
using System.Collections;

public class AINav : MonoBehaviour {

	//Map Navigation
	public Transform target;
	NavMeshAgent agent;

	//enemy health
	public int maxHealth = 240;
	int playerHealth;
	public int bulletDamage = 25;
	bool isDead = false;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<NavMeshAgent>();
		playerHealth = maxHealth;
	}

	// Update is called once per frame
	void Update () {
		// agent.SetDestination(target.position);

		if(isDead)
			gameObject.SetActiveRecursively(false);
	}

	public void Damage(int _damage){
		playerHealth -= _damage;
		Debug.Log(playerHealth);
		if (playerHealth <= 0){
			isDead = true;
		}
	}
}
