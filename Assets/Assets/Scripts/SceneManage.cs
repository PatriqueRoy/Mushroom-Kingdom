using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SceneManage : MonoBehaviour {

	private bool locked;
	CursorLockMode wantedMode;
	Scene currentScene;

	private Button start;
	private Button quit;

	public Canvas HUD;
	public Canvas pauseMenu;

	public GameObject look;

	public GameObject ControlS;
	public GameObject UIS;
	public GameObject InfoS;



	// Use this for initialization
	void Start () {
		currentScene = SceneManager.GetActiveScene ();
		if (currentScene.name == "mainMenu") {
			Button btnS = GameObject.Find("Start").GetComponent<Button> ();
			btnS.onClick.AddListener (StartOnClick);
			Button btnQ = GameObject.Find("End").GetComponent<Button> ();
			btnQ.onClick.AddListener (QuitOnClick);
			Button btnO = GameObject.Find("Options").GetComponent<Button> ();
			btnO.onClick.AddListener (OptionsOnClick);
		}

		if (currentScene.name == "Instructions") {
			Button btnS = GameObject.Find("Controls").GetComponent<Button> ();
			btnS.onClick.AddListener (ControlOnClick);
			Button btnQ = GameObject.Find("UI").GetComponent<Button> ();
			btnQ.onClick.AddListener (UIOnClick);
			Button btnO = GameObject.Find("Info").GetComponent<Button> ();
			btnO.onClick.AddListener (InfoOnClick);
			Button btnB = GameObject.Find("return").GetComponent<Button> ();
			btnB.onClick.AddListener (MenuOnClick);
		}

		if (currentScene.name == "GameOver") {
			Button btnR = GameObject.Find("Restart").GetComponent<Button> ();
			btnR.onClick.AddListener (RestartOnClick);
			Button btnQ = GameObject.Find("Quit").GetComponent<Button> ();
			btnQ.onClick.AddListener (MenuOnClick);
		}

		if (currentScene.name == "Win") {
			Button btnR = GameObject.Find("Restart").GetComponent<Button> ();
			btnR.onClick.AddListener (RestartOnClick);
			Button btnQ = GameObject.Find("Quit").GetComponent<Button> ();
			btnQ.onClick.AddListener (MenuOnClick);
		}
		if (currentScene.name == "testArea" || currentScene.name == "playArea") {
			Cursor.lockState = wantedMode = CursorLockMode.Locked;
			locked = true;
			pauseMenu.gameObject.SetActive (false);
		}
	}
	
	// Update is called once per frame
	void Update () {
		MouseLock ();
		if (currentScene.name == "playArea") {
			if(Input.GetKeyDown(KeyCode.P)|| Input.GetKeyDown(KeyCode.Escape)){
				pauseMenu.gameObject.SetActive (true);
				look.GetComponent<MouseLook> ().enabled = false;
				Time.timeScale = 0;

				Button btnR = GameObject.Find("Resume").GetComponent<Button> ();
				btnR.onClick.AddListener (ResumeOnClick);
				Button btnQ = GameObject.Find("Quit").GetComponent<Button> ();
				btnQ.onClick.AddListener (MenuOnClick);
			}
		}
	}

	void MouseLock(){
		if (currentScene.name == "mainMenu" || currentScene.name == "GameOver" || currentScene.name == "Win") {
			Cursor.lockState = wantedMode;
			wantedMode = CursorLockMode.None;
		}
		if (currentScene.name == "testArea" || currentScene.name == "playArea") {
			Cursor.lockState = wantedMode;
			if (Input.GetKeyDown (KeyCode.P) && locked == true || Input.GetKeyDown (KeyCode.Escape) && locked == true) {
				wantedMode = CursorLockMode.None;
				locked = false;
			} 
			if (Input.GetMouseButtonDown (0) && locked == false && pauseMenu.gameObject.activeSelf == false) {
				wantedMode = CursorLockMode.Locked;
				locked = true;
			}
		}
	}
	void StartOnClick(){
		SceneManager.LoadScene ("playArea");
	}
	void QuitOnClick(){
		Application.Quit();
	}
	void RestartOnClick(){
		SceneManager.LoadScene ("playArea");
	}
	void MenuOnClick(){
		SceneManager.LoadScene ("mainMenu");
	}
	void ResumeOnClick(){
		pauseMenu.gameObject.SetActive (false);
		look.GetComponent<MouseLook> ().enabled = true;
		wantedMode = CursorLockMode.Locked;
		locked = true;
		Time.timeScale = 1;
	}
	void OptionsOnClick(){
		SceneManager.LoadScene ("Instructions");
	}
	void ControlOnClick(){
		ControlS.gameObject.SetActive (true);
		UIS.gameObject.SetActive (false);
		InfoS.gameObject.SetActive (false);
	}
	void UIOnClick(){
		ControlS.gameObject.SetActive (false);
		UIS.gameObject.SetActive (true);
		InfoS.gameObject.SetActive (false);
	}
	void InfoOnClick(){
		ControlS.gameObject.SetActive (false);
		UIS.gameObject.SetActive (false);
		InfoS.gameObject.SetActive (true);
	}
	void OnGUI(){
		if (currentScene.name == "playArea" && wantedMode != CursorLockMode.None) {
			GUI.Box (new Rect (Screen.width / 2, Screen.height / 2, 10, 10), "");
		}
	}
}
