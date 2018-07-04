using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour {
	//target of tower
	private Vector3 targetPos;
	public GameObject[] Enemies;
	public GameObject closestEnemy;
	private float tempDis = 0.0f;
	private int tempIndex;
	//private bool prioritySet = false;
	//attack variables
	public float Distance;
	public float Distance2;
	public float AtkRange;
	public GameObject tBullet;
	public Transform tBulletSpawn;
	public float RateOfFire;
	//animation
	Animator animator;
	//camera


	void Start (){
		animator = GetComponent<Animator> ();


		RateOfFire = 3.0f;
		AtkRange = 50.0f;
	}
		
	void Update (){
		Enemies = new GameObject[GameObject.FindGameObjectsWithTag("Enemy").Length];
		Enemies = GameObject.FindGameObjectsWithTag ("Enemy");

		if(closestEnemy == null)
			Targeting ();

		if (closestEnemy != null) {
			

			Distance2 = Vector3.Distance (this.transform.position, closestEnemy.transform.position);

			targetPos = new Vector3 (closestEnemy.transform.position.x, this.transform.position.y, closestEnemy.transform.position.z);

			transform.LookAt(targetPos);

			if (Distance2 <= AtkRange){
				RateOfFire -= Time.deltaTime;

				if (RateOfFire <= 0){
					RateOfFire = 3.0f;
					animator.SetBool ("Attacking ?", true);
					GameObject turretBulletInstance = Instantiate (tBullet, tBulletSpawn.position, tBulletSpawn.rotation) as GameObject;
					turretBulletInstance.GetComponent<TowerBulletBehaviour>().target = closestEnemy;
				}else
					animator.SetBool ("Attacking ?", false);
			}
		}
	}

	void Targeting(){
		int Index = 0;
		foreach(GameObject tar in Enemies){
			if(Enemies != null)
				Distance = Vector3.Distance (this.transform.position, tar.transform.position);

			if(Distance < tempDis || tempDis == 0){
				tempDis = Distance;
				tempIndex = Index;
				closestEnemy = Enemies [tempIndex];
			}
			Index++;
		}
	}
}
