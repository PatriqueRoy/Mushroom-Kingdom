using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBulletBehaviour : MonoBehaviour {
	public GameObject target;
	private float speed = 10.0f;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (target == null)
			Destroy (gameObject);
		if (target != null) {
			Homing ();
			Destroy (gameObject, 8.0f);
		}

	}

	void Homing(){
		transform.LookAt(target.transform.position);
		transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision c){
		if (c.gameObject == target) {
			target.GetComponent<EnemyBehaviour> ().BaseUnitHealth = target.GetComponent<EnemyBehaviour> ().BaseUnitHealth - 5;
			//Destroy (target.gameObject);
		}
		Destroy (gameObject);
	}
}
