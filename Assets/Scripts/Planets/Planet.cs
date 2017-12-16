using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Planet : MonoBehaviour
{
	public float scale = 1.0f;
	
	public PlanetResource planetResource;

	private int oldResourceCount = 0;

	private int oldResourceImageCount = 0;
	
	private String resourceName = "ResourceIndicator";

	public int resourceIndicatorCount = 10;

	public float maxResourceScale = 0.2f;
	
	//Highest Resoruce grows and gets resources added until it is "full"
	private List<GameObject> freeResources = new List<GameObject>();
	
	// Use this for initialization
	void Start ()
	{
		this.transform.localScale = Vector3.one * scale;
		this.oldResourceCount = planetResource.count;
		this.oldResourceImageCount = calculateResourceImageCount();
		Debug.Log("Number of resource indicators: " + this.oldResourceImageCount);
		renderResource(0, this.oldResourceImageCount);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (planetResource != null && oldResourceCount != planetResource.count)
		{
			int numberResourceImages = calculateResourceImageCount();

			if (this.oldResourceImageCount != numberResourceImages)
			{
				renderResource(this.oldResourceImageCount, numberResourceImages);
				this.oldResourceImageCount = numberResourceImages;
				Debug.Log("Number of resource indicators: " + this.oldResourceImageCount);
			}
			oldResourceCount = planetResource.count;
		}
	}

	int calculateResourceImageCount()
	{
		if (this.planetResource.count == 0)
			return 0;
		int indicators = (int) ((float) this.planetResource.count / (float) this.planetResource.maxCount * resourceIndicatorCount);
		return indicators;
	}

	void renderResource(int oldCount, int newCount)
	{
		if (!planetResource.resource.sprite)
			return;
		int toDelete = oldCount - newCount;
		int toAdd = newCount - oldCount;
		
		deleteOldResources(toDelete);
		addResources(toAdd);
	}

	void deleteOldResources(int count)
	{
		if (count <= 0)
			return;
		List<Transform> resources = new List<Transform>();
		foreach (Transform child in transform)
			if (child.name.Equals(resourceName))
				resources.Add(child);
		if (resources.Count == 0)
			return;
		for (int i = 0; i < count; i++)
		{
			int randomIndex = Random.Range(0, resources.Count);
			Destroy(resources[randomIndex].gameObject);
		}
	}

	void addResources(int count)
	{
		if (count <= 0)
			return;
		float localScale = scale * 0.8f;
		for(int i = 0; i < count; i++)
		{
			Vector2 pos = new Vector2(Random.Range(0, localScale) - localScale / 2, Random.Range(0, localScale) - localScale / 2 );
			addResource(pos);
		}
	}

	void addResource(Vector2 localPosition, float resourceScale = 0.2f)
	{
		GameObject go = new GameObject(resourceName);
		SpriteRenderer resourceRenderer = go.AddComponent<SpriteRenderer>();
		resourceRenderer.sprite = planetResource.resource.sprite;
		resourceRenderer.sortingOrder = 1;
		go.transform.parent = this.transform;
		go.transform.localPosition = localPosition;
		go.transform.localScale = Vector3.one * resourceScale;
	}

	public void resourcesMined(int amountMined)
	{
		int maxPerFloating = (int) ((float) this.planetResource.maxCount / (float) resourceIndicatorCount);
		if (maxPerFloating == 0)
			maxPerFloating = 1;

		GameObject obj = null;
		FloatingResource floating = null;

		if (freeResources.Count == 0)
		{
			// TODO: They CAN exceeed maxPerFloating, but i really donot care by now...
			addNewFloating(out obj, out floating);
		}
		else
		{
			obj = this.freeResources[this.freeResources.Count - 1];
			floating = obj.GetComponent<FloatingResource>();
				
			if (this.freeResources.Count == 0 || floating.resourceCount > maxPerFloating)
			{
				addNewFloating(out obj, out floating);
			}
		}

		// TODO: By now, resources CAN have more than maxPerFloating, but i do not want to fix this
		floating.resourceCount += amountMined;
		obj.transform.localScale = Vector3.one * (float) floating.resourceCount / (float) maxPerFloating * maxResourceScale;
	}

	public int emptyFloatingListAndReturnAccumulatedValues(out ResourceTypes resourceType)
	{
		int resources = 0;
		for (int i = freeResources.Count - 1; i >= 0; i--)
		{
			FloatingResource floating = freeResources[i].GetComponent<FloatingResource>();
			if (floating != null)
				resources += floating.resourceCount;
			Destroy(freeResources[i]);
		}
		resourceType = this.planetResource.resource.resourceType;
		this.freeResources = new List<GameObject>();
		return resources;
	}

	public void addNewFloating(out GameObject obj, out FloatingResource floating)
	{
		obj = new GameObject("FloatingResource");
		obj.transform.parent = this.transform;

		floating = obj.AddComponent<FloatingResource>();
		floating.resource = Instantiate(this.planetResource.resource);
		floating.resource.transform.parent = obj.transform;

		float t = scale * Random.Range(0, 2 * (float) Math.PI);
		float scaling = 1.25f;
		obj.transform.localPosition = new Vector2((float) Math.Cos(t) * scaling, (float) Math.Sin(t) * scaling);
		floating.resource.transform.localPosition = obj.transform.localPosition;
		floating.resourceCount = 0;

		PolygonCollider2D colldier = obj.AddComponent<PolygonCollider2D>();
		colldier.isTrigger = true;

		this.freeResources.Add(obj);
	}
}
