using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : GalaxyLocation {
    /**
     * The size of the population of each species on the planet.
     */ 
    public readonly Dictionary<string, int> population;
    public Planet(float horizontalPositionOffset, float verticalPositionOffset) : base("planet", horizontalPositionOffset, verticalPositionOffset)
    {

    }




    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
