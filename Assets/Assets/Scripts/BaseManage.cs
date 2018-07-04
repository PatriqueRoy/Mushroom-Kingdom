using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class BaseManage : MonoBehaviour {
	public GameObject food1;
	public GameObject food2;
	public GameObject food3;
	public GameObject mine1;
	public GameObject mine2;
	public GameObject mine3;
	private int foodUpgrade = 0;
	private int mineUpgrade = 0;
	public int crystals = 0;
	public int food = 200;
	private int BaseHealth = 10;
	private int foodIncome = 50;
	private int foodUfcost = 50;
	private int foodUocost = 0;
	private int oreUfcost = 50;
	private int oreUocost = 0;
	private int oreIncome = 0;
	public Text foodT;
	public Text oreT;
	public Text healthT;
	public GameObject FoodUpgradeElement;
	public GameObject OreUpgradeElement;
	public Text t1Cost;
	public Text t2Cost;
	public Text t3Cost;
	public Text t4Cost;
	public Text fCost;
	public Text oCost;
	public Text m1HealthT;
	public Text m2HealthT;
	public Text m3HealthT;
	public bool m1broken = false;
	public bool m2broken = false;
	public bool m3broken = false;
	private int repairCost = 0;
	public GameObject spawner;
	private int curWave = 1;
	private bool pressed = false; 

	// Use this for initialization
	void Start () {
		m1HealthT.enabled = false;
		m2HealthT.enabled = false;
		m3HealthT.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		foodT.text = "Food: " + food.ToString () + " (+" + foodIncome.ToString() + ")";
		oreT.text = "Ore: " + crystals.ToString () + " (+" + oreIncome.ToString() + ")";
		healthT.text = "Base Health: " + BaseHealth.ToString ();
		t1Cost.text = "Cost:\n 25 x Food";
		t2Cost.text = "Cost:\n 50 x Food \n 25 x Ore";
		t3Cost.text = "Cost:\n 75 x Food \n 50 x Ore";
		t4Cost.text = "Cost:\n 100 x Food \n 100 x Ore";
		if (foodUpgrade < 3) {
			fCost.text = "Cost:\n " + foodUfcost + " x Food \n " + foodUocost + " x Ore";
		} else {
			fCost.text = "Max Level";
		}
		if (mineUpgrade < 3 && m1broken == false && m2broken == false && m3broken == false) {
			oCost.text = "Cost:\n " + oreUfcost + " x Food \n " + oreUocost + " x Ore";
		} else {
			oCost.text = "Max Level";
		}
		if (m1broken == true || m2broken == true || m3broken == true) {
			oCost.text = "Repair Cost:\n" + repairCost + " x Ore";
		}
			
		if (mine1.activeSelf == true) {
			if (mine1.GetComponentInChildren<MineManage> ().MineHealth == 0 && m1broken == false) {
				m1broken = true;
				repairCost = repairCost + 50;
				oreIncome = oreIncome - 50;
			}
		}
		if (mine2.activeSelf == true) {
			if (mine2.GetComponentInChildren<MineManage> ().MineHealth == 0 && m2broken == false) {
				m2broken = true;
				repairCost = repairCost + 50;
				oreIncome = oreIncome - 50;
			}
		}
		if (mine3.activeSelf == true) {
			if (mine3.GetComponentInChildren<MineManage> ().MineHealth == 0 && m3broken == false) {
				m3broken = true;
				repairCost = repairCost + 50;
				oreIncome = oreIncome - 50;
			}
		}


		if (mineUpgrade >= 1) {
			m1HealthT.enabled = true;
			m1HealthT.text = "Mine #1 Health: " + mine1.GetComponentInChildren<MineManage>().MineHealth;
		}
		if (mineUpgrade >= 2) {
			m2HealthT.enabled = true;
			m2HealthT.text = "Mine #2 Health: " + mine2.GetComponentInChildren<MineManage>().MineHealth;
		}
		if (mineUpgrade >= 3) {
			m3HealthT.enabled = true;
			m3HealthT.text = "Mine #3 Health: " + mine3.GetComponentInChildren<MineManage>().MineHealth;
		}


		if (BaseHealth <= 0) {
			SceneManager.LoadScene ("GameOver");
		}

		if (spawner.GetComponent<EnemySpawning> ().Wave > curWave) {
			curWave++;
			food = food + foodIncome;
			crystals = crystals + oreIncome;
		}
	}
	void OnTriggerStay(Collider c){
		if (c.gameObject.tag == "Player") {

			FoodUpgradeElement.SetActive(true);
			OreUpgradeElement.SetActive (true);

			if (Input.GetKeyDown (KeyCode.Alpha5)) {
				if (foodUpgrade == 0 && food >= 50) {
					food1.SetActive (true);
					food = food - 50;
					foodIncome = 100;
					foodUocost = 50;
					foodUpgrade++;
					pressed = true;
				}
				if (foodUpgrade == 1 && food >= 50 && crystals >= 50 && pressed == false) {
					food2.SetActive (true);
					food = food - 50;
					crystals = crystals - 50;
					foodIncome = 150;
					foodUocost = 100;
					foodUpgrade++;
					pressed = true;
				}
				if (foodUpgrade == 2 && food >= 50 && crystals >= 100 && pressed == false) {
					food3.SetActive (true);
					food = food - 50;
					crystals = crystals - 100;
					foodIncome = 200;
					foodUpgrade++;
					pressed = true;
				}
				pressed = false;
			}
			if (Input.GetKeyDown (KeyCode.Alpha6) && m1broken == false && m2broken == false && m3broken == false) {
				if (mineUpgrade == 0 && food >= 50) {
					mine1.SetActive (true);
					food = food - 50;
					oreIncome = 50;
					oreUfcost = 100;
					oreUocost = 50;
					mineUpgrade++;
					pressed = true;
				}
				if (mineUpgrade == 1 && food >= 100 && crystals >= 50 && pressed == false) {
					mine2.SetActive (true);
					food = food - 50;
					crystals = crystals - 50;
					oreIncome = 100;
					oreUfcost = 150;
					oreUocost = 100;
					mineUpgrade++;
					pressed = true;
				}
				if (mineUpgrade == 2 && food >= 150 && crystals >= 100 && pressed == false) {
					mine3.SetActive (true);
					food = food - 50;
					crystals = crystals - 100;
					oreIncome = 150;
					mineUpgrade++;
					pressed = true;
				}
				pressed = false;
			}
			if (Input.GetKeyDown (KeyCode.Alpha6) && m1broken == true || Input.GetKeyDown (KeyCode.Alpha6) && m2broken == true || Input.GetKeyDown (KeyCode.Alpha6) && m3broken == true) {
				//repair 1
				if (repairCost == 50) {
					oreIncome = oreIncome + 50;
				}
				if (repairCost == 100) {
					oreIncome = oreIncome + 100;
				}
				//repair 3
				if (repairCost == 150) {
					oreIncome = oreIncome + 150;
				}

				m1broken = false;
				m2broken = false;
				m3broken = false;
				mine1.GetComponentInChildren<MineManage> ().MineHealth = 3;
				mine2.GetComponentInChildren<MineManage> ().MineHealth = 3;
				mine3.GetComponentInChildren<MineManage> ().MineHealth = 3;
				crystals = crystals - repairCost;
				repairCost = repairCost - repairCost;
			}
		}


	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "Enemy") {
			StartCoroutine("healthDamage", c.gameObject);
		}
	}
	void OnTriggerExit(Collider c){
		if (c.gameObject.tag == "Player") {
			FoodUpgradeElement.SetActive(false);
			OreUpgradeElement.SetActive (false);
		}
	}
	IEnumerator healthDamage(GameObject e){
		Destroy (e.gameObject, 2.0f);
		yield return new WaitForSeconds(2.0f);
		BaseHealth--;
	}
}
