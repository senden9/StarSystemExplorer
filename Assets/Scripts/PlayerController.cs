using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        var x = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var z = Input.GetAxis("Horizontal") * Time.deltaTime * -150.0f;

        transform.Translate(0, x, 0);
        transform.Rotate(0, 0, z);
    }
}
