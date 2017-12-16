using UnityEngine;

public class FloatingResource : MonoBehaviour
{
	public int resourceCount = 0;

	public OwnedBy ownedBy;
	
	// Shoudl be set according to resourceCount and the max resource count per 
	// floating resource which is dertermined by the planet resource max
	public float scale = 1.0f;
	
	public Resource resource;

	// Will be used so that it orbits the planet it comes from
	public GameObject orbiting;
	
	void Start()
	{
		createSprite();
	}

	void createSprite()
	{
		GameObject go = new GameObject("FloatingResource");
		go.transform.parent = this.transform;
		SpriteRenderer resourceRenderer = go.AddComponent<SpriteRenderer>();
		resourceRenderer.sprite = resource.sprite;
		resourceRenderer.sortingOrder = 1;
		
		go.transform.localPosition = Vector2.zero;
		go.transform.localScale = Vector3.one * scale;
	}

	private void FixedUpdate()
	{
		this.transform.rotation *= new Quaternion(0.0f, 0.0f, Time.deltaTime, 1.0f) ;
	}

	void Update()
	{
		// TODO: Orbit around here
		this.transform.localScale = Vector3.one * scale;
		
	}
}
