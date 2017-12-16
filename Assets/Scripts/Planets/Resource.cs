using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
	public ResourceTypes resourceType = ResourceTypes.TEST_RESOURCE;
	
	public Sprite sprite;

	public float miningTimeMultiplicator = 1.0f;

	public float regenerationTimeMultiplicator = 1.0f;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
