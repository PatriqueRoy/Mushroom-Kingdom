using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour {

	// Use this for initialization
	void OnTriggerStay(Collider c){
		if (Input.GetMouseButton (0) && gameObject.GetComponentInParent<PlayerController> ().B1 == null && gameObject.GetComponentInParent<PlayerController> ().B2 == null
		    && gameObject.GetComponentInParent<PlayerController> ().B3 == null && gameObject.GetComponentInParent<PlayerController> ().B4 == null) {

			gameObject.GetComponentInParent<PlayerController> ().attacking = true;

		} else {
			gameObject.GetComponentInParent<PlayerController> ().attacking = false;
		}

		if (c.tag == "Enemy") {
			if (gameObject.GetComponentInParent<PlayerController> ().attacking == true) {
				StartCoroutine ("damage", c.gameObject);

			} 
		}
	} 

	IEnumerator damage(GameObject c){
		yield return new WaitForSeconds(0.5f);
		if(c.gameObject != null)
			c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth = c.gameObject.GetComponent<EnemyBehaviour> ().BaseUnitHealth - 10;
	}
}

