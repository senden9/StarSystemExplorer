using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteorid : MonoBehaviour {
    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<Asteorid>() == null) {
            Destroy(gameObject);
        }
    }
}
