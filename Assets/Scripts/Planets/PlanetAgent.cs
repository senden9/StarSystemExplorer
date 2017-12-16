using UnityEngine;
[RequireComponent(typeof(Planet))]
public class PlanetAgent : MonoBehaviour
{
    public OwnedBy ownedBy = OwnedBy.NO_ONE;

    public static float minePerSecondBase = 100.0f;
    
    public float minePerSecond = minePerSecondBase;
    
    public static float regeneratePerSecondBase = 100.0f;
    
    public float regeneratePerSecond = regeneratePerSecondBase;
    
    private Planet planetScript;

    private float partlyMined = 0;
    private float partlyRegenerated = 0;
    
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
            if (ownedBy == OwnedBy.PLAYER_2)
            {
                ownedBy = OwnedBy.DESTROYED;
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
        if (this.ownedBy == OwnedBy.DESTROYED)
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
        if (ownedBy == OwnedBy.DESTROYED)
            return;
        
        if (ownedBy == OwnedBy.PLAYER_1)
        {
            float deltaTime = Time.deltaTime;
            this.mine(deltaTime);
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
}
