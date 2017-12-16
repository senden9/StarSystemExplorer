using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class circular_progressbar : MonoBehaviour {


    Image circularImage;
    float progressbarvalue;

    public float Value
    {
        get
        {
            if (circularImage != null)
                return (float)(circularImage.fillAmount);
            else
                return 0;
        }
        set
        {
            if (circularImage != null)
                circularImage.fillAmount = (float)value ;
        }
    }
    // Use this for initialization
    void Start () {
        circularImage = gameObject.GetComponent<Image>();
        Value = 0.0f;
    }
    public void buttonPressedCircular()
    {
        progressbarvalue = progressbarvalue + 0.1f;
        if (progressbarvalue > 1){
            progressbarvalue = 0;
        }
        Debug.Log(progressbarvalue);
        setCircularProgressbarValue(progressbarvalue);
    }

    public void setCircularProgressbarValue(float val) {
        Value = val;
    }
    // Update is called once per frame
    void Update () {
		
	}
}
