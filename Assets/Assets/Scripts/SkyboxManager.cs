using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour {
	

	public Material DrySky;
	public Material PoisonSky;
	public Material LushSky;
	public Material IceSky;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider c){
		if (this.tag == "Dry" && c.tag == "Player") {
			RenderSettings.skybox = DrySky;
		}
		if (this.tag == "Poison" && c.tag == "Player") {
			RenderSettings.skybox = PoisonSky;
		}
		if (this.tag == "Lush" && c.tag == "Player") {
			RenderSettings.skybox = LushSky;
		}
		if (this.tag == "Ice" && c.tag == "Player") {
			RenderSettings.skybox = IceSky;
		}
		DynamicGI.UpdateEnvironment();
	}
}
