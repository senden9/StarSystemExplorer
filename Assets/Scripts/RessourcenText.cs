using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RessourcenText : MonoBehaviour {

    public int RessourcenP2;
    public Text RessourcenNumber;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        SetCountText();

	}


    void SetCountText()
    {
        RessourcenNumber.text = RessourcenP2.ToString();
    }
}
