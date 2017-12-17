using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


public class PlayerHealth : NetworkBehaviour
{
    public const int maxHealth = 100;
    [SyncVar]
    public int currentHealth = maxHealth;

    [SyncVar]
    public int resourceCount = 200;

    private int oldResourceCount = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.oldResourceCount != this.resourceCount)
		{
			FindObjectOfType<current_resourceshield>().setCurrentResourceGui(this.resourceCount);
			this.oldResourceCount = this.resourceCount;
		}
	}

	public void collectResource(int count)
	{
		this.resourceCount += count;
	}

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Debug.Log("Dead!", gameObject);
        }
    }
}
