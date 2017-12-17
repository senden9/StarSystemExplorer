using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playBackgroundaudio : MonoBehaviour {


    private AudioSource backgroundmusic;
	// Use this for initialization
	void Awake () {
        backgroundmusic = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
