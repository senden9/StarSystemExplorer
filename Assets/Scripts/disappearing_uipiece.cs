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

        setGuiText(14);
    }

    public void setGuiText(int resourcenumber) {
        int randomnumber = Random.Range(1, 16777215);
        string guitext = "";
        guitext = guitext + "Resources: "+ resourcenumber.ToString() + "\n";
        guitext = guitext + "Planet Nr.: " + randomnumber.ToString("X");
        planetTextComponent.text = guitext;
    }

    
	
	// Update is called once per frame
	void Update () {
		
	}
}
