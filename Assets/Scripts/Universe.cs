using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using System;
using UnityEngine.EventSystems;

public class Universe : MonoBehaviour, IGalaxyLocationBlurEventHandler, IGalaxyLocationFocusEventHandler{
    public GameObject galaxyPrefab;
    public Sprite[] planetSprites;
    private EventSystem events;
    public UniverseState state = new UniverseState();

    public void OnFocus(GalaxyLocationFocusEvent eventData)
    {
        this.state.selectedLocation = eventData.location;
        Debug.Log("Universe Focus Handler");
    }

    public void OnMouseDown()
    {
        Debug.Log("Universe Click Handler");
        this.OnBlur(null);
    }

    public void OnBlur(GalaxyLocationBlurEvent eventData)
    {
        Debug.Log("Universe Blur Handler");
    }

    // Use this for initialization
    void Start () {
        events = FindObjectOfType<EventSystem>();
        Debug.Log("Initialize Random seed");
        var random = new System.Random(0);
        Assert.AreNotEqual(0, this.planetSprites.Length);
        var generationParameters = new Galaxy.GalaxyGenerationParameters(10, 10, .2f, .8f, .2f, .8f, .25f,
            this.planetSprites);
        Debug.Log("Need to generate Galaxy");
        var galaxy = Instantiate<GameObject>(galaxyPrefab);
        galaxy.transform.SetParent(this.transform);
        galaxy.GetComponent<Galaxy>().generate(random, generationParameters);
	}
	
	// Update is called once per frame
	void Update () {
        var rightClickPressed = Input.GetMouseButtonDown(1);
		if(rightClickPressed)
        {
            this.state.selectedLocation = null;
        }
	}
}
