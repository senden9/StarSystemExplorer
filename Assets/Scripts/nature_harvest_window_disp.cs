using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nature_harvest_window_disp : MonoBehaviour {
    public GameObject Harvestinfo;
    // Use this for initialization
    void Start () {
        Harvestinfo = gameObject;
        

    }

    public void OnButtonpressedtest() {

        toggleHarvestinfo();

    }

    public void toggleHarvestinfo() {
        if (Harvestinfo.GetComponent<Image>().enabled)
        {
            Harvestinfo.GetComponent<Image>().enabled = false;
            Harvestinfo.GetComponentInChildren<Text>().enabled = false;
        }
        else
        {
            Harvestinfo.GetComponent<Image>().enabled = true;
            Harvestinfo.GetComponentInChildren<Text>().enabled = true;
        }

    }

    // Update is called once per frame
    void Update(){

    }
}
