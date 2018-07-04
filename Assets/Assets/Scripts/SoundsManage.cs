using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsManage : MonoBehaviour {
	private static SoundsManage instance;
	Scene currentScene;
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "mainMenu" || currentScene.name == "Instructions") {
			DontDestroyOnLoad (this);
			if (instance == null) {
				instance = this;
			} else {
				DestroyObject (gameObject);
			}
		}

	}
	// Update is called once per frame
	void Update () {
		currentScene = SceneManager.GetActiveScene ();

		if (currentScene.name == "playArea") {
			Destroy(GameObject.Find("SoundManager"));
		}
	}
}
