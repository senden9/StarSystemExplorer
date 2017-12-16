using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteorid : MonoBehaviour {
    [Range(0,100)]
    public int damage = 10;

    void OnCollisionEnter2D(Collision2D coll) {
        if (coll.gameObject.GetComponent<Asteorid>() == null) {
            Destroy(gameObject);
        }

        PlayerHealth health = coll.gameObject.GetComponent<PlayerHealth>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
