using UnityEngine;

public class SpacecraftColliderCheck : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<SpacecraftColliderCheck>())
		{
			return;
		}

		FloatingResource resource = coll.gameObject.GetComponent<FloatingResource>();
		if (resource != null)
		{
			Debug.Log("Collected: " + resource.resourceCount);
			Destroy(coll.gameObject);
		}
	}
}
