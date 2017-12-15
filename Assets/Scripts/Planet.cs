using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

	public float scale = 1.0f;	
	
	// Use this for initialization
	void Start ()
	{
		this.transform.localScale = Vector3.one * scale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
