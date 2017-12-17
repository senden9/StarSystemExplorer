using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nature_harvest_window_text : MonoBehaviour {
    public Text Harvesttext;
    bool bla=true;
    // Use this for initialization
    void Start () {
        Harvesttext = GetComponent<Text>();
    }

    public void Buttonpressedtest1()
    {
        if (bla)
        {
            setHarvestGui(14, bla);
            bla = !bla;
        }
    }

    public void setHarvestGui(int Resources_available,bool harvesting) {
        string guitext = "Resources available:" + Resources_available.ToString()+"\n";
        if (!harvesting) {
            guitext = guitext + "To start harvesting: H";
        }else{
            guitext = guitext + "currently harvesting to abbort press H"; 
                }
       
        Harvesttext.text = guitext;
    }
	// Update is called once per frame
	void Update () {
		
	}
}
