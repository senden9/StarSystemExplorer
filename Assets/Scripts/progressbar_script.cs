using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar_script : MonoBehaviour {

    Image foregroundImage;
    int progressbarvalue=0;

    public int Value
    {
        get
        {
            if (foregroundImage != null)
                return (int)(foregroundImage.fillAmount * 100);
            else
                return 0;
        }
        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value / 100f;
        }
    }

    // Use this for initialization
    void Start () {
        foregroundImage = gameObject.GetComponent<Image>();
        Value = 0;
    }

    public void buttonPressed() {
        progressbarvalue = progressbarvalue + 10;
        progressbarvalue = progressbarvalue % 110;
        setProgressbarValue(progressbarvalue);
    }

    public void setProgressbarValue(int val) {
        Value = val;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
