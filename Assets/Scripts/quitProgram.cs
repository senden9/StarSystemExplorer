using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quitProgram : MonoBehaviour {

    public void quit()
    {
        Debug.Log("has quit.");
        Application.Quit();
    }
}
