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
		agent.SetDestination(target.position);

		if(isDead)
			Respawn();
	}

	public void Respawn(){
		Vector3 newSpawnpoint = new Vector3(0,0,0);
		do{
			newSpawnpoint = Random.insideUnitCircle * 8;
			newSpawnpoint.z = newSpawnpoint.y;
			newSpawnpoint -= transform.position;
			newSpawnpoint.y = 6;
			Debug.Log(newSpawnpoint);
			if((GameObject.FindWithTag("Player").transform.position - newSpawnpoint).sqrMagnitude < 0.5){
				Debug.Log("TOO CLOSE!");
			}
		}while((GameObject.FindWithTag("Player").transform.position - newSpawnpoint).sqrMagnitude < 0.5);
		isDead = false;
		playerHealth = maxHealth;
		transform.position = newSpawnpoint;
		GlobalValues.score += 1;
	}

	public void Damage(int _damage){
		playerHealth -= _damage;
		Debug.Log(playerHealth);
		if (playerHealth <= 0){
			isDead = true;
		}
	}
}
