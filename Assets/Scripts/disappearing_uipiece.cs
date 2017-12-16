using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class disappearing_uipiece : MonoBehaviour {

    //GameObject planetInfoText; // gameObject in Hierarchy
    Text planetTextComponent;
    // Use this for initialization
    public void Start () {
        //planetInfoText = GameObject.Find("PlanetInfo");

        planetTextComponent = GetComponent<Text>();

        planetTextComponent.text = "boobies";
    }

    public void setGuiText(int resourcenumber) {
        //Random rnd = new Random();
        //int randomnumber = rnd.Next(1,16777215);
        //string guitext = "";
        //guitext = guitext + "Resources: "+ resourcenumber.ToString() + "\n";
        //guitext = guitext + "Number: " + randomnumber.ToString();
        //planetTextComponent.text = guiText;
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
