using UnityEngine;
using UnityEngine.UI;

public class SpacecraftColliderCheck : MonoBehaviour
{

	public PlanetAgent planetAgent;

	public enum InteractionKey
	{
		CONQUER,
		NOTHING
	}

	public InteractionKey currentKeyPress = InteractionKey.NOTHING;

	public Image planetInfo;

	private PlanetInfoHide planetInfoHide;
	private disappearing_uipiece infoText;

	private Planet currentPlanet;
	
	public void Start()
	{
		this.planetInfoHide = GameObject.Find("/Player1Ui/Canvas/PlanetInfo").GetComponent<PlanetInfoHide>();
		this.infoText =  GameObject.Find("/Player1Ui/Canvas/PlanetInfo/PlanetInfoText").GetComponent<disappearing_uipiece>();

		this.planetInfoHide.hideGui();
	}
	
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
			this.currentPlanet = planet;
		}	
		this.planetAgent = coll.gameObject.GetComponent<PlanetAgent>();
		if (this.planetAgent != null)
		{
			this.infoText.setGuiText(planet.planetResource.count, planet.name);
			collectResources(planet);
			this.planetInfoHide.showGui();
		}
	}

	private void OnTriggerExit2D(Collider2D coll)
	{
		PlanetAgent pl = coll.gameObject.GetComponent<PlanetAgent>();
		if (pl != null)
		{
			abortConquering();
			this.planetAgent = null;
			this.planetInfoHide.hideGui();
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
		if (this.currentPlanet != null)
		{
			this.infoText.setGuiText(this.currentPlanet.planetResource.count, this.currentPlanet.planetName);
		}
		
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
