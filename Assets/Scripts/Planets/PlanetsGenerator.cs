using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class PlanetsGenerator : NetworkBehaviour
{
	public GameObject planetPrefab;

	public int dimensionWidth = 200;
	public int dimensionHeight = 200;
	
	public int numberOfPlanets = 10;

	public float minDistance = 3;

	private const float MinScale = 1;
	
	private const float MaxScale = 4;
	
	[Range(MinScale, MaxScale)]
	public float minRandomScale = 1;
	
	[Range(MinScale, MaxScale)]
	public float maxRandomScale = 1;

	public List<PlanetResource> planetResources = new List<PlanetResource>();
	
	List<PlanetSpecs> specs = new List<PlanetSpecs>();
		
	// Use this for initialization
	void Start ()
	{
		for (int i = 0; i < numberOfPlanets; i++)
		{
			Vector2 coordinates;
			float randomScale;
			
			calculateCoordinatesAndScale(out coordinates, out randomScale);
			
			PlanetSpecs spec = new PlanetSpecs();
			spec.coordinates = coordinates;
			spec.scale = randomScale;
			specs.Add(spec);

			instantiatePlanet(coordinates, randomScale);
		}
	}

	void calculateCoordinatesAndScale(out Vector2 coordinates, out float scale)
	{
		int iteration = 0;
		do
		{
			coordinates = new Vector2(
				Random.Range(-dimensionWidth / 2, dimensionWidth / 2),
				Random.Range(-dimensionHeight / 2, dimensionHeight / 2)
			);

			scale = Random.Range(this.minRandomScale, this.maxRandomScale);
			iteration++;
			if (iteration > 100)
				break;
		} while (!checkIfCoordinatesAreAllowed(scale, coordinates));
	}

	void instantiatePlanet(Vector2 coordinates, float scale)
	{
		GameObject planet = Instantiate(planetPrefab, coordinates, Quaternion.identity);
		planet.transform.parent = this.transform;
		int planetResource = Random.Range(0, this.planetResources.Count);
		if (planetResource == 1)
			Debug.Log("heyho");
		Planet planetScript = planet.GetComponent<Planet>();
		if (!planetScript)
			planetScript = planet.AddComponent<Planet>();
		planetScript.scale = scale;
		planetScript.planetResource = Instantiate(planetResources[planetResource]);
		planetScript.planetResource.transform.parent = planet.transform;
	}
	
	bool checkIfCoordinatesAreAllowed(float scale, Vector2 coordinates)
	{
		foreach (PlanetSpecs spec in specs)
		{
			float distX = Math.Abs(coordinates.x - spec.coordinates.x);
			float distY = Math.Abs(coordinates.y - spec.coordinates.y);

			if (distX < scale / 2 + spec.scale / 2 + minDistance)
				return false;
			if (distY < scale / 2 + spec.scale / 2 + minDistance)
				return false;
		}
		return true;
	}
	
	private class PlanetSpecs
	{
		public float scale;
		public Vector2 coordinates;
	}
}
