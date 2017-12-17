using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class disappearing_uipiece : MonoBehaviour {

    //GameObject planetInfoText; // gameObject in Hierarchy
    Text planetTextComponent;
    // Use this for initialization
    public void Start () {
        //planetInfoText = GameObject.Find("PlanetInfo");
	    int randomnumber = Random.Range(1, 16777215);
        planetTextComponent = GetComponent<Text>();

        setGuiText(0, randomnumber.ToString("X"));
    }

    public void setGuiText(int resourcenumber, String planetName) {
        
        string guitext = "";
        guitext = guitext + "Resources: "+ resourcenumber.ToString() + "\n";
        guitext = guitext + "Planet Nr.: " + planetName;
        planetTextComponent.text = guitext;
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
