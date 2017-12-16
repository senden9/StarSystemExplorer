using UnityEngine;

public class SpacecraftColliderCheck : MonoBehaviour {
	
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<SpacecraftColliderCheck>())
		{
			return;
		}

		Planet planet = coll.gameObject.GetComponent<Planet>();
		if (planet != null)
		{
			ResourceTypes resourceType;
			int count = planet.emptyFloatingListAndReturnAccumulatedValues(out resourceType);
			Debug.Log("Collected: " + resourceType + " " + count);
		}
	}
}
