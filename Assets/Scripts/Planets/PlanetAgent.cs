using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Planet))]
public class PlanetAgent : MonoBehaviour
{
    public OwnedByPlayer ownedBy = OwnedByPlayer.NO_ONE;

    public static float minePerSecondBase = 100.0f;
    
    public float minePerSecond = minePerSecondBase;
    
    public static float regeneratePerSecondBase = 100.0f;
    
    public float regeneratePerSecond = regeneratePerSecondBase;
    
    private Planet planetScript;

    private float partlyMined = 0;
    private float partlyRegenerated = 0;

    public float secondsToConquer = 5;

    public float currentConquerTime = 0;
    public OwnedByPlayer currentlyBeeingConqueredBy = OwnedByPlayer.NO_ONE;

    public List<Sprite> conquerStagesPlayer1;

    public List<Sprite> inhabitedStages;
    
    
    public void mine(float deltaTime)
    {
        if (planetScript.planetResource.count <= 0)
            return;
        
        partlyMined += deltaTime * minePerSecond * planetScript.planetResource.resource.miningTimeMultiplicator;
        if (partlyMined < 1)
            return;
        
        int mined = (int) partlyMined;
        partlyMined = partlyMined - mined;
        
        planetScript.planetResource.count -= mined;

        if (planetScript.planetResource.count <= 0)
        {
            planetScript.planetResource.count = 0;
            if (ownedBy == OwnedByPlayer.PLAYER_2)
            {
                ownedBy = OwnedByPlayer.DESTROYED;
            }
        }

        this.planetScript.resourcesMined(mined);
    }

    public void reduceResources(int count)
    {
        planetScript.planetResource.count -= count;
        if (planetScript.planetResource.count < 0)
        {
            planetScript.planetResource.count = 0;
        }
    }
    
    public void regenerate(float deltaTime)
    {
        if (this.ownedBy == OwnedByPlayer.DESTROYED)
            return;

        if (partlyRegenerated > planetScript.planetResource.maxCount)
            return;
        
        partlyRegenerated += deltaTime * regeneratePerSecond * planetScript.planetResource.resource.regenerationTimeMultiplicator;
        planetScript.planetResource.count += (int) partlyRegenerated;
        partlyRegenerated -= (int) partlyRegenerated;
        
        if (planetScript.planetResource.count > planetScript.planetResource.maxCount)
        {
            planetScript.planetResource.count = planetScript.planetResource.maxCount;
        }
    }

    public void Update()
    {
        if (ownedBy == OwnedByPlayer.DESTROYED)
            return;
        
        if (ownedBy == OwnedByPlayer.PLAYER_1)
        {
            float deltaTime = Time.deltaTime;
            this.mine(deltaTime);
            this.regenerate(deltaTime);
        }
    }

    public void Start()
    {
        planetScript = this.transform.GetComponent<Planet>();
        if (!planetScript)
        {
            Debug.LogError("No Planet found in parent");
        }
    }

    public void conquer(OwnedByPlayer from, float deltaTime)
    {
        Debug.Log("Owned By: " + this.ownedBy);
        Debug.Log("Is Already beeing conquered: " +
                  (currentlyBeeingConqueredBy != OwnedByPlayer.NO_ONE && currentlyBeeingConqueredBy != from));
        Debug.Log("Times up? : " + (this.currentConquerTime >= this.secondsToConquer));
        if ((this.ownedBy != OwnedByPlayer.DESTROYED ||
            this.ownedBy != OwnedByPlayer.NO_ONE) && (
            (currentlyBeeingConqueredBy != OwnedByPlayer.NO_ONE && currentlyBeeingConqueredBy != from) ||
            this.currentConquerTime >= this.secondsToConquer))
        {
            return;
        }
        
        this.currentlyBeeingConqueredBy = from;
        this.currentConquerTime += deltaTime;
        Debug.Log("Current Conquering Time: " + this.currentConquerTime);

        if (this.currentConquerTime >= this.secondsToConquer)
        {
            this.ownedBy = from;
            Debug.Log("Conquered by: " + from);
        }
    }

    public void abortConquering()
    {
        Debug.Log("Aborting Conquering");
        this.currentConquerTime = 0;
        this.currentlyBeeingConqueredBy = OwnedByPlayer.NO_ONE;
    }
}
