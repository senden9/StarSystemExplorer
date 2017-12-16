using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressbar_script : MonoBehaviour {

    Image foregroundImage;
    float progressbarvalue=0;

    public float Value
    {
        get
        {
            if (foregroundImage != null)
                return (float)(foregroundImage.fillAmount );
            else
                return 0;
        }
        set
        {
            if (foregroundImage != null)
                foregroundImage.fillAmount = value;
        }
    }

    // Use this for initialization
    void Start () {
        foregroundImage = gameObject.GetComponent<Image>();
        Value = 0;
    }

    public void buttonPressed() {
        progressbarvalue = progressbarvalue + 0.10f;
        if (progressbarvalue > 1)
        {
            progressbarvalue = 0;
        }
        setProgressbarValue(progressbarvalue);
    }

    public void setProgressbarValue(float val) {
        Value = val;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
