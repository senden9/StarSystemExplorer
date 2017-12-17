using UnityEngine;

public class SpacecraftColliderCheck : MonoBehaviour
{

	public PlanetAgent planetAgent;

	public enum InteractionKey
	{
		CONQUER,
		NOTHING
	}

	public InteractionKey currentKeyPress = InteractionKey.NOTHING;
	
	private void OnTriggerEnter2D(Collider2D coll)
	{
		if (coll.gameObject.GetComponent<SpacecraftColliderCheck>())
		{
			return;
		}

		Planet planet = coll.gameObject.GetComponent<Planet>();
		if (planet != null)
		{
			collectResources(planet);
		}
		
		this.planetAgent = coll.gameObject.GetComponent<PlanetAgent>();
		if (this.planetAgent != null)
		{
			collectResources(planet);
		}
	}

	private void OnTriggerExit2D(Collider2D coll)
	{
		PlanetAgent pl = coll.gameObject.GetComponent<PlanetAgent>();
		if (pl != null)
		{
			abortConquering();
			this.planetAgent = null;
		}
	}

	private void collectResources(Planet planet)
	{
		ResourceTypes resourceType;
		int count = planet.emptyFloatingListAndReturnAccumulatedValues(out resourceType);
		Debug.Log("Collected: " + resourceType + " " + count);
		FindObjectOfType<PlayerHealth>().collectResource(count);
	}

	private void Update()
	{
		if (this.planetAgent != null)
		{
			if (Input.GetKey(KeyCode.E))
			{
				currentKeyPress = InteractionKey.CONQUER;
				this.planetAgent.conquer(OwnedByPlayer.PLAYER_1, Time.deltaTime);
			}
		}
		
		if (!Input.GetKey(KeyCode.E) && currentKeyPress == InteractionKey.CONQUER)
		{
			currentKeyPress = InteractionKey.NOTHING;
			abortConquering();
		}
	}

	private void abortConquering()
	{
		if (this.planetAgent != null)
		{
			this.planetAgent.abortConquering();
		}
	}
}
