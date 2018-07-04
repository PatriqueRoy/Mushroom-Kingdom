using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MineManage : MonoBehaviour {


	public int MineHealth;
	// Use this for initialization
	void Start () {
		MineHealth = 3;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Enemy") {
			StartCoroutine("healthDamage", c.gameObject);
		}
	}

	IEnumerator healthDamage(GameObject e){
		Destroy (e.gameObject, 1.0f);
		yield return new WaitForSeconds(1.0f);
		if (MineHealth > 0) {
			MineHealth--;
		}
	}
}
