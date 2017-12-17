using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScreenOnClick : MonoBehaviour {

    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }

    public void LoadByname(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }

}
