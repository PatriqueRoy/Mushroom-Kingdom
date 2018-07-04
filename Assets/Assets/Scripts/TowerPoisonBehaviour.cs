using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPoisonBehaviour : MonoBehaviour {

	//Animator animator;
	ParticleSystem poison;
	public float RateOfFire;

	// Use this for initialization
	void Start () {
		//animator = GetComponentInChildren<Animator> ();
		poison = GetComponent<ParticleSystem> ();
		RateOfFire = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider c){
		if (c.tag == "Enemy") {
			poison.Play ();

			RateOfFire -= Time.deltaTime;

			if (RateOfFire <= 0){
				RateOfFire = 1.0f;
				c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth = c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth - 2;
			//Destroy (c.gameObject);
			}
		}
	}
}
