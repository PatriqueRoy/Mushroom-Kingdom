using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;


public class EnemySpawning : MonoBehaviour {

	public int Wave = 1;
	public int spawned = 0;
	private bool WaveStart = false;
	public GameObject Enemy;
	public Transform[] spawnLoc;
	public int spawnTime;
	public bool display = true;
	private bool once = false;
	public Text waveText;
	private GameObject EnemyInstance;
	public int totalEnemies = 0;
	public Text remainText;
	public Text NextWave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//wave 1
		if (Input.GetKeyDown (KeyCode.Space) && Wave == 1 && once == false) {
			once = true;
			WaveStart = true;
			display = false;
		}
		if (Wave == 1 && spawned == 5 && totalEnemies == 0) {
			once = false;
			display = true;
			Wave = 2;
			spawned = 0;
		}
		//wave 2
		if (Input.GetKeyDown (KeyCode.Space) && Wave == 2 && once == false) {
			once = true;
			WaveStart = true;
			display = false;
		}
		if (Wave == 2 && spawned == 10 && totalEnemies == 0) {
			once = false;
			display = true;
			Wave = 3;
			spawned = 0;
		}
		//wave 3
		if (Input.GetKeyDown (KeyCode.Space) && Wave == 3 && once == false) {
			once = true;
			WaveStart = true;
			display = false;
		}
		if (Wave == 3 && spawned == 15 && totalEnemies == 0) {
			once = false;
			display = true;
			Wave = 4;
			spawned = 0;
		}
		//Wave 4
		if (Input.GetKeyDown (KeyCode.Space) && Wave == 4 && once == false) {
			once = true;
			WaveStart = true;
			display = false;
		}
		if (Wave == 4 && spawned == 20 && totalEnemies == 0) {
			once = false;
			display = true;
			Wave = 5;
			spawned = 0;
		}
		//Wave 5
		if (Input.GetKeyDown (KeyCode.Space) && Wave == 5 && once == false) {
			once = true;
			WaveStart = true;
			display = false;
		}

		if (WaveStart == true) {
			StartCoroutine ("Spawn");
			WaveStart = false;
		}

		if (Wave == 5 && spawned == 25 && totalEnemies == 0) {
			SceneManager.LoadScene ("Win");
		}


		waveText.text = "Wave \n " + Wave.ToString ();
		remainText.text = "Enemies Remaining \n " + totalEnemies.ToString ();

		totalEnemies = GameObject.FindGameObjectsWithTag ("Enemy").Length;
	}

	IEnumerator Spawn(){
		//wave 1
		if (Wave == 1){
			for (int i = 0; i < 5; i++) {
				yield return new WaitForSeconds (2.0f);
				int spawnPointIndex = Random.Range (0, spawnLoc.Length);
				EnemyInstance = Instantiate (Enemy, spawnLoc [spawnPointIndex].position, spawnLoc [spawnPointIndex].rotation) as GameObject;

				spawned++;
			}
		}
		//wave 2
		if (Wave == 2){
			for (int i = 0; i < 10; i++) {
				yield return new WaitForSeconds (2.0f);
				int spawnPointIndex = Random.Range (0, spawnLoc.Length);
				EnemyInstance = Instantiate (Enemy, spawnLoc [spawnPointIndex].position, spawnLoc [spawnPointIndex].rotation) as GameObject;

				spawned++;
			}
		}
		//wave 3
		if (Wave == 3){
			for (int i = 0; i < 15; i++) {
				yield return new WaitForSeconds (2.0f);
				int spawnPointIndex = Random.Range (0, spawnLoc.Length - 1);
				EnemyInstance = Instantiate (Enemy, spawnLoc [spawnPointIndex].position, spawnLoc [spawnPointIndex].rotation) as GameObject;

				spawned++;
			}
		}
		//wave 4
		if (Wave == 4){
			for (int i = 0; i < 20; i++) {
				yield return new WaitForSeconds (2.0f);
				int spawnPointIndex = Random.Range (0, spawnLoc.Length - 1);
				EnemyInstance = Instantiate (Enemy, spawnLoc [spawnPointIndex].position, spawnLoc [spawnPointIndex].rotation) as GameObject;

				spawned++;
			}
		}
		//wave 5
		if (Wave == 5){
			for (int i = 0; i < 25; i++) {
				yield return new WaitForSeconds (1.5f);
				int spawnPointIndex = Random.Range (0, spawnLoc.Length - 1);
				EnemyInstance = Instantiate (Enemy, spawnLoc [spawnPointIndex].position, spawnLoc [spawnPointIndex].rotation) as GameObject;

				spawned++;
			}
		}



	}

	void OnGUI(){
		if (display == true) {
			NextWave.gameObject.SetActive (true);
		} else {
			NextWave.gameObject.SetActive (false);
		}
	}
}
