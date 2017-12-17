using UnityEngine;

public class FloatingResource : MonoBehaviour
{
	public int resourceCount = 0;

	public OwnedByPlayer ownedBy;
	
	public Resource resource;
	
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
		go.transform.localScale = Vector3.one;
	}

	private void FixedUpdate()
	{
		this.transform.rotation *= new Quaternion(0.0f, 0.0f, Time.deltaTime, 1.0f) ;
	}
}
