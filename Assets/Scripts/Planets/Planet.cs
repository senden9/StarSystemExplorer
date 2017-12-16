using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{

	public float scale = 1.0f;

	public PlanetResource planetResource;

	private GameObject resource;

	private int oldResourceCount = 0;

	private int oldResourceImageCount = 0;
	
	private String resourceName = "Resource";
	
	// Use this for initialization
	void Start ()
	{
		this.transform.localScale = Vector3.one * scale;
		this.oldResourceCount = planetResource.count;
		this.oldResourceImageCount = calculateResourceImageCount();
		renderResource(this.oldResourceImageCount);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (oldResourceCount != planetResource.count)
		{
			int numberResourceImages = calculateResourceImageCount();
			Debug.Log("Percentage: " + numberResourceImages);

			if (this.oldResourceImageCount != numberResourceImages)
			{
				renderResource(numberResourceImages);
				this.oldResourceImageCount = numberResourceImages;
			}
			
			oldResourceCount = planetResource.count;
		}
		
	}

	int calculateResourceImageCount()
	{
		if (this.planetResource.count == 0)
			return 0;
		return (int) ((float) this.planetResource.count / (float) this.planetResource.maxCount * 10) + 1;
	}

	void renderResource(int numberResourceImages)
	{
		if (!planetResource.resource.sprite)
			return;
		deleteOldResources();
		addResources(numberResourceImages);
	}

	void deleteOldResources()
	{
		List<Transform> resources = new List<Transform>();
		foreach (Transform child in transform)
			if (child.name.Equals(resourceName))
				resources.Add(child);
		for (int i = resources.Count - 1; i >= 0; i--)
			Destroy(resources[i].gameObject);
	}

	void addResources(int count)
	{
		float localScale = scale * 0.8f;
		for(int i = 0; i < count; i++)
		{
			Vector2 pos = new Vector2(Random.Range(0, localScale) - localScale / 2, Random.Range(0, localScale)  - localScale / 2 );
			addResource(pos);
		}
	}

	void addResource(Vector2 localPosition, float resourceScale = 0.2f)
	{
		GameObject go = new GameObject("Resource");
		SpriteRenderer resourceRenderer = go.AddComponent<SpriteRenderer>();
		resourceRenderer.sprite = planetResource.resource.sprite;
		resourceRenderer.sortingOrder = 1;
		go.transform.parent = this.transform;
		go.transform.localPosition = localPosition;
		go.transform.localScale = Vector3.one * resourceScale;
	}
}
