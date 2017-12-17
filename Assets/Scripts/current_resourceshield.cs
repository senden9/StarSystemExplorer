using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class current_resourceshield : MonoBehaviour {
    Text planetTextComponent1;
    // Use this for initialization
    void Start () {

        planetTextComponent1 = GetComponent<Text>();
        setCurrentResourceGui(0);
    }

    public void setCurrentResourceGui(int resourcenumber)
    {
        
        string guitext = "";
        guitext = guitext + "Current Resources: " + resourcenumber.ToString();
        planetTextComponent1.text = guitext;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
