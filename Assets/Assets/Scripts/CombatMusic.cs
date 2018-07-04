using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CombatMusic : MonoBehaviour {
	
	public AudioMixerSnapshot outCombat;
	public AudioMixerSnapshot inCombat;
	public float bpm = 95;


	private float m_TransitionIn;
	private float m_TransitionOut;
	private float m_QuarterNote;
	private bool first = false;

	public GameObject wave;

	// Use this for initialization
	void Start () 
	{
		m_QuarterNote = 60 / bpm;
		m_TransitionIn = m_QuarterNote;
		m_TransitionOut = m_QuarterNote * 11;

	}
	
	// Update is called once per frame
	void Update () {
		if(wave.GetComponent<EnemySpawning>().display == true && first == true)
			outCombat.TransitionTo(m_TransitionOut);
		
		if (wave.GetComponent<EnemySpawning> ().display == false) {
			first = true;
			inCombat.TransitionTo (m_TransitionIn);
		}


	}
}
