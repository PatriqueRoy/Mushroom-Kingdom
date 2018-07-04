using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuffBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider c){
		if (c.tag == "Enemy") {
			c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth = c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth / 2;
		}
	}
	void OnTriggerExit(Collider c){
		if (c.tag == "Enemy") {
			c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth = c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth * 2;
		}
	}
}
