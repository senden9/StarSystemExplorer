using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlanetsGenerator : MonoBehaviour
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
	
	List<PlanetSpecs> specs = new List<PlanetSpecs>();
		
	// Use this for initialization
	void Start ()
	{
	
		for (int i = 0; i < numberOfPlanets; i++)
		{
			int iteration = 0;
			Vector2 coordinates;
			float randomScale;
			do
			{
					coordinates = new Vector2(
					Random.Range(-dimensionWidth / 2, dimensionWidth / 2),
					Random.Range(-dimensionHeight / 2, dimensionHeight / 2)
				);

				randomScale = Random.Range(this.minRandomScale, this.maxRandomScale);
				iteration++;
				Debug.Log("Iteration: " + iteration);
				if (iteration > 10)
					break;
			} while (!checkIfCoordinatesAreAllowed(randomScale, coordinates));
			
			PlanetSpecs spec = new PlanetSpecs();
			spec.coordinates = coordinates;
			spec.scale = randomScale;
			specs.Add(spec);
			
			GameObject planet = Instantiate(planetPrefab, coordinates, Quaternion.identity);
			planet.transform.parent = this.transform;
			planet.GetComponent<Planet>().scale = randomScale;
		}
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
	
	// Update is called once per frame
	void Update () {
		
	}

	private class PlanetSpecs
	{
		public float scale;
		public Vector2 coordinates;
	}
}
