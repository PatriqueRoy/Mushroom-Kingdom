using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManage : MonoBehaviour {

	private bool display = false;
	public GameObject GatePoison;
	private BoxCollider GateP_c;
	private ParticleSystem GateP_p;
	public GameObject GateLush;
	private BoxCollider GateL_c;
	private ParticleSystem GateL_p;
	public GameObject GateIce;
	private BoxCollider GateI_c;
	private ParticleSystem GateI_p;
	// Use this for initialization
	void Start () {
		GateP_c = GatePoison.GetComponentInChildren<BoxCollider> ();
		GateP_p = GatePoison.GetComponentInChildren<ParticleSystem> ();
		GateL_c = GateLush.GetComponentInChildren<BoxCollider> ();
		GateL_p = GateLush.GetComponentInChildren<ParticleSystem> ();
		GateI_c = GateIce.GetComponentInChildren<BoxCollider> ();
		GateI_p = GateIce.GetComponentInChildren<ParticleSystem> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay(Collider c){
		if (this.tag == "GateP") {
			display = true;
			if (Input.GetKeyDown (KeyCode.F)) {
				GateP_c.enabled = false;
				GateP_p.Stop();
			}
		}
		if (this.tag == "GateL") {
			display = true;
			if (Input.GetKeyDown (KeyCode.F)) {
				GateL_c.enabled = false;
				GateL_p.Stop();
			}
		}
		if (this.tag == "GateI") {
			display = true;
			if (Input.GetKeyDown (KeyCode.F)) {
				GateI_c.enabled = false;
				GateI_p.Stop();
			}
		}
	}
	void OnTriggerExit(Collider c){
		display = false;
	}
	void OnGUI(){
		if (display == true) {
			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2.5f, 200f, 200f), "Press 'F' to Deactivate Gate");
		}
	}
}
