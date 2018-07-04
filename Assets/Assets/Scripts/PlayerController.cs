using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public bool attacking = false;
	private Animator animator;
	private Collider col;
	//movement 
	private float speed = 5.0f;
	private float distToGround;
	private RaycastHit hit;
	public GameObject Buildingone;
	public GameObject B1;
	public GameObject Buildingtwo;
	public GameObject B2;
	public GameObject Buildingthree;
	public GameObject B3;
	public GameObject Buildingfour;
	public GameObject B4;

	public GameObject Basemanager;


	public AudioSource walking;
	private bool walkPlayOnce = false;
	public AudioSource attackS;
	private bool attackPlayOnce = false;

	void Start () {
		//animation
		animator = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
		col = GetComponent<Collider> ();
		distToGround = col.bounds.extents.y;



	}


	void Update () {
		
		Movement ();
		StartCoroutine("Attack");
		Build ();

		
	}
	void FixedUpdate(){
		Transform cam = Camera.main.transform;
		Physics.Raycast (cam.position, cam.forward, out hit);
	}

	void Movement(){
		float forward = Input.GetAxis ("Vertical") * speed;
		float strafing = Input.GetAxis ("Horizontal") * speed / 1.5f;
		float falling = -5.0f;

		if (forward > 0) { 
			animator.SetBool ("Moving ?", true);
			if (walkPlayOnce == false) {
				walking.Play ();
				walkPlayOnce = true;
			}

		}
		if (forward == 0) { 
			animator.SetBool ("Moving ?", false);
			if (walkPlayOnce == true) {
				walking.Stop ();
				walkPlayOnce = false;
			}
		}
		if (forward < 0) {
			animator.SetBool ("Moving ?", true);
			forward = forward / 2;
		}
		if (animator.GetBool ("Attacking ?") == true) {
			forward = forward / 3;
			strafing = strafing / 1.5f;
		}
		rb.velocity = (transform.right * strafing) + (transform.forward * forward);

		//falling & jumping
		if(isGrounded() == false){
			rb.velocity = (transform.right * strafing) + (transform.forward * forward) + (transform.up * falling);
		}
	}

	bool isGrounded(){
		return Physics.Raycast(transform.position, -Vector3.up, distToGround - 0.9f);
	}
		
	IEnumerator Attack(){
		if(B1 == null && B2 == null && B3 == null && B4 == null){
			if (Input.GetMouseButton (0)) {
				animator.SetBool ("Attacking ?", true);
				if (attackPlayOnce == false) {
					attackS.Play ();
					attackPlayOnce = true;
				}
			} else {
				animator.SetBool ("Attacking ?", false);
				if (attackPlayOnce == true) {
					attackS.Stop ();
					attackPlayOnce = false;
				}
			}
		}
		yield return new WaitForSeconds(0.0f);
	}

	void Build(){
		


		//tower1
		if (Input.GetKeyDown (KeyCode.Alpha1) && B1 == null) {
			Destroy (B2);
			Destroy (B3);
			Destroy (B4);
			B1 = Instantiate (Buildingone, hit.point, Quaternion.identity);
		}

		if (B1 != null && hit.collider.tag == "Ground") {
			B1.transform.position = Vector3.Lerp(B1.transform.position ,new Vector3(hit.point.x, transform.position.y, hit.point.z), 5.0f);
	
		}
		if (B1 != null) {
			if (Input.GetMouseButtonDown(0) && Basemanager.GetComponent<BaseManage>().food >= 25) {
				B1 = Instantiate (Buildingone, hit.point, Quaternion.identity);
				B1.layer = LayerMask.NameToLayer("Default");
				Basemanager.GetComponent<BaseManage>().food = Basemanager.GetComponent<BaseManage>().food - 25;
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				B1.transform.Rotate (B1.transform.rotation.x, B1.transform.rotation.y - 90, B1.transform.rotation.z);
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				B1.transform.Rotate (B1.transform.rotation.x, B1.transform.rotation.y + 90, B1.transform.rotation.z);
			}
		}

		//tower2
		if (Input.GetKeyDown (KeyCode.Alpha2) && B2 == null) {
			Destroy (B1);
			Destroy (B3);
			Destroy (B4);
			B2 = Instantiate (Buildingtwo, hit.point, Quaternion.identity);
		}

		if (B2 != null && hit.collider.tag == "Ground") {
			B2.transform.position = Vector3.Lerp(B2.transform.position ,new Vector3(hit.point.x, transform.position.y, hit.point.z), 5.0f);
		}
		if (B2 != null) {
			if (Input.GetMouseButtonDown(0) && Basemanager.GetComponent<BaseManage>().food >= 50 && Basemanager.GetComponent<BaseManage>().crystals >= 25) {
				B2 = Instantiate (Buildingtwo, hit.point, Quaternion.identity);
				Basemanager.GetComponent<BaseManage>().food = Basemanager.GetComponent<BaseManage>().food - 50;
				Basemanager.GetComponent<BaseManage>().crystals = Basemanager.GetComponent<BaseManage>().crystals - 25;
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				B2.transform.Rotate (B2.transform.rotation.x, B2.transform.rotation.y - 90, B2.transform.rotation.z);
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				B2.transform.Rotate (B2.transform.rotation.x, B2.transform.rotation.y + 90, B2.transform.rotation.z);
			}
		}
		//tower3
		if (Input.GetKeyDown (KeyCode.Alpha3) && B3 == null) {
			Destroy (B2);
			Destroy (B1);
			Destroy (B4);
			B3 = Instantiate (Buildingthree, hit.point, Quaternion.identity);
		}

		if (B3 != null && hit.collider.tag == "Ground") {
			B3.transform.position = Vector3.Lerp(B3.transform.position ,new Vector3(hit.point.x, transform.position.y, hit.point.z), 5.0f);
		}
		if (B3 != null) {
			if (Input.GetMouseButtonDown(0) && Basemanager.GetComponent<BaseManage>().food >= 75 && Basemanager.GetComponent<BaseManage>().crystals >= 50) {
				B3 = Instantiate (Buildingthree, hit.point, Quaternion.identity);	
				Basemanager.GetComponent<BaseManage>().food = Basemanager.GetComponent<BaseManage>().food - 75;
				Basemanager.GetComponent<BaseManage>().crystals = Basemanager.GetComponent<BaseManage>().crystals - 50;
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				B3.transform.Rotate (B3.transform.rotation.x, B3.transform.rotation.y - 90, B3.transform.rotation.z);
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				B3.transform.Rotate (B3.transform.rotation.x, B3.transform.rotation.y + 90, B3.transform.rotation.z);
			}
		}
		//tower4
		if (Input.GetKeyDown (KeyCode.Alpha4) && B4 == null) {
			Destroy (B2);
			Destroy (B3);
			Destroy (B1);
			B4 = Instantiate (Buildingfour, hit.point, Quaternion.identity);
		}

		if (B4 != null && hit.collider.tag == "Ground") {
			B4.transform.position = Vector3.Lerp(B4.transform.position ,new Vector3(hit.point.x, transform.position.y, hit.point.z), 5.0f);
		}
		if (B4 != null) {
			if (Input.GetMouseButtonDown(0) && Basemanager.GetComponent<BaseManage>().food >= 100 && Basemanager.GetComponent<BaseManage>().crystals >= 100) {
				B4 = Instantiate (Buildingfour, hit.point, Quaternion.identity);
				Basemanager.GetComponent<BaseManage>().food = Basemanager.GetComponent<BaseManage>().food - 100;
				Basemanager.GetComponent<BaseManage>().crystals = Basemanager.GetComponent<BaseManage>().crystals - 100;
			}
			if (Input.GetKeyDown (KeyCode.Q)) {
				B4.transform.Rotate (B4.transform.rotation.x, B4.transform.rotation.y - 90, B4.transform.rotation.z);
			}
			if (Input.GetKeyDown (KeyCode.E)) {
				B4.transform.Rotate (B4.transform.rotation.x, B4.transform.rotation.y + 90, B4.transform.rotation.z);
			}
		}

		if (Input.GetMouseButtonDown(1)) {
			Destroy (B1);
			Destroy (B2);
			Destroy (B3);
			Destroy (B4);
		}
	}




}
