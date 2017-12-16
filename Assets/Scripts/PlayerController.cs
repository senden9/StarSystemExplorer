// Use PlayerControllerWithoutNetwork. It has also a network part.

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

        var x = Input.GetAxis("Vertical") * 3.0f;
        var z = Input.GetAxis("Horizontal") * -150.0f;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.TransformDirection(new Vector2(0, x));
        rb.angularVelocity = z;

        //transform.Translate(0, x, 0);
        //transform.Rotate(0, 0, z);
    }
}
