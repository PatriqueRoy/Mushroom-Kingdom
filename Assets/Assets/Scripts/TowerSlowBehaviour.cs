using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TowerSlowBehaviour : MonoBehaviour {

	ParticleSystem Ice;
	// Use this for initialization
	void Start () {
		Ice = GetComponent<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider c){
		if (c.tag == "Enemy") {
			Ice.Play ();
			c.gameObject.GetComponent<NavMeshAgent> ().speed = 2.5f;
		}
	}
	void OnTriggerExit(Collider c){
		if (c.tag == "Enemy") {
			c.gameObject.GetComponent<NavMeshAgent> ().speed = 3.5f;
		}
	}
}
