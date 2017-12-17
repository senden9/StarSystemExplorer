using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetInfoHide : MonoBehaviour {

    public GameObject Planetinfo;


    // Use this for initialization
    void Start () {
        Planetinfo = gameObject;
        //Planetinfo = gameObject.GetComponent<Image>();

    }
	
    public void onButtonPressed (){
        toggleGui();

    }

    private void toggleGui() {
       
        if (Planetinfo.GetComponent<Image>().enabled)
        {
            Planetinfo.GetComponent<Image>().enabled = false;
            Planetinfo.GetComponentInChildren<Text>().enabled = false;
        }
        else {
            Planetinfo.GetComponent<Image>().enabled = true;
            Planetinfo.GetComponentInChildren<Text>().enabled = true;
        }
        //if (Planetinfo.renderer.) { Planetinfo.SetActive(false); }
        //else { Planetinfo.SetActive(true); }
        
    }



	// Update is called once per frame
	void Update () {
		
	}
}
