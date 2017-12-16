using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetResource : MonoBehaviour
{
	public Resource resource;
	
	public float meanResourceCount = 10;

	public float sigmaResourcecount = 1;

	public int count;

	public int maxCount
	{
		get { return _maxCount; }
	}

	private int _maxCount;
	
	// Use this for initialization
	void Start ()
	{
		_maxCount = (int) Utils.generateNormalRandom(meanResourceCount, sigmaResourcecount);
		count = _maxCount;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
