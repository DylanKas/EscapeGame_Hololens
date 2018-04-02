using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAudioBeginGame : MonoBehaviour {
    public GameObject sound;
	// Use this for initialization
	void Start () {
        AudioSource audio = sound.GetComponent<AudioSource>();
        audio.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
