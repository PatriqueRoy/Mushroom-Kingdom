using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;


public class EnemyBehaviour : MonoBehaviour {
	public GameObject Target;
	private NavMeshAgent Enemy;
	public GameObject[] baseTargets;
	public GameObject[] mineTargets;
	public GameObject closestBaseTarget;
	public GameObject closestMineTarget;
	private float baseDistance;
	private float tempBaseDis = 0.0f;
	private int tempBaseIndex;
	private float mineDistance;
	private float tempMineDis = 0.0f;
	private int tempMineIndex;
	private bool prioritySet = false;

	public int BaseUnitHealth = 10;

	// Use this for initialization
	void Start () {
	Enemy = GetComponent<NavMeshAgent>();

	baseTargets = new GameObject[GameObject.FindGameObjectsWithTag("Base").Length];
	mineTargets = new GameObject[GameObject.FindGameObjectsWithTag("Mine").Length];
	baseTargets = GameObject.FindGameObjectsWithTag ("Base");
	mineTargets = GameObject.FindGameObjectsWithTag ("Mine");
	}
	
	// Update is called once per frame
	void Update () {
		targetPicking ();

		if (BaseUnitHealth <= 0) {
			Destroy (this.gameObject);
		}
	}

	void targetPicking(){
		int baseIndex = 0;
		foreach(GameObject tar in baseTargets){
			
			baseDistance = Vector3.Distance (this.transform.position, tar.transform.position);

			if(baseDistance < tempBaseDis || tempBaseDis == 0){
				tempBaseDis = baseDistance;
				tempBaseIndex = baseIndex;
				closestBaseTarget = baseTargets [tempBaseIndex];
			}
			baseIndex++;
		}

		int mineIndex = 0;
		 
			foreach (GameObject tar in mineTargets) {
				mineDistance = Vector3.Distance (this.transform.position, tar.transform.position);

				if (mineDistance < tempMineDis || tempMineDis == 0) {
					tempMineDis = mineDistance;
					tempMineIndex = mineIndex;
					closestMineTarget = mineTargets [tempMineIndex];
				}
				mineIndex++;
			}
		
		if (prioritySet == false) {
			int priority = Random.Range (0, 10);
			if (priority > 5 && closestMineTarget != null) {
				Target = closestMineTarget;
				Enemy.destination = Target.transform.position;
			}
			if (priority <= 5 || closestMineTarget == null) {
				Target = closestBaseTarget;
				Enemy.destination = Target.transform.position;
			}
			prioritySet = true;
		}

	}
}
