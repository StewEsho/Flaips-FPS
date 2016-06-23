using UnityEngine;
using System.Collections;

public class AINav : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		target = GameObject.FindWithTag("Player").transform;
		agent = GetComponent<NavMeshAgent>();
	}

	// Update is called once per frame
	void Update () {
		agent.SetDestination(target.position);
	}
}
