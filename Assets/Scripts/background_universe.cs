using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_universe : MonoBehaviour {

    private GameObject background;
    public GameObject [] backgroundTiles;

    

    public int columns = 50;
    public int rows = 100;
    public float scale = 1;

    public Vector3 origin;
	// Use this for initialization
	void Start () {
        background = new GameObject("Boardholder");
        background.transform.SetParent(transform);
        InstantiateBackground();
        background.transform.localScale = Vector3.one * scale;
        background.transform.position = origin;
    }

    
    void InstantiateBackground()
    {
       

        for (int j = 0; j < rows; j++) {
            for (int i = 0; i <columns ; i++) {
                InstantiateFromArray(backgroundTiles, j, i);

            }
        }

        
    }

    

    void InstantiateFromArray(GameObject[] prefabs, float xCoord, float yCoord)
    {
        // Create a random index for the array.
        
        int randomIndex = Random.Range(0, prefabs.Length);
        
        // The position to be instantiated at is based on the coordinates.
        Vector3 position = new Vector3(xCoord, yCoord, 0f);

        // Create an instance of the prefab from the random index of the array.
        GameObject tileInstance = Instantiate(prefabs[randomIndex], position, Quaternion.identity) as GameObject;
        Vector3 size = tileInstance.GetComponent<Renderer>().bounds.size;
        tileInstance.transform.localScale = new Vector3(1.0f / size.x, 1.0f / size.y, 1);
        // Set the tile's parent to the board holder.
        tileInstance.transform.parent = background.transform;
        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
