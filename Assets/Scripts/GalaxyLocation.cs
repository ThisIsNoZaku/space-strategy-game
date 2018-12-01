using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class GalaxyLocation : MonoBehaviour {
    private static int count = 0;
    public float horizontalPositionOffset;
    public float verticalPositionOffset;
    private EventSystem events;
    /**
     * The type of location
     */ 
    public string type;

    public GalaxyLocation(string type, float horizontalPositionOffset, float verticalPositionOffset)
    {
        this.type = type;
        this.horizontalPositionOffset = horizontalPositionOffset;
        this.verticalPositionOffset = verticalPositionOffset;
    }

    public void OnMouseDown()
    {
        ExecuteEvents.ExecuteHierarchy<IGalaxyLocationFocusEventHandler>(this.gameObject, new PointerEventData(this.events), 
            delegate (IGalaxyLocationFocusEventHandler handler, BaseEventData data)
            {
                handler.OnFocus(new GalaxyLocationFocusEvent(this.events, this));
                Debug.Log("Focus Callback called");
            });
    }

    // Use this for initialization
    void Start () {
        this.name = this.name + count++;
        this.events = FindObjectOfType<EventSystem>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public abstract class GalaxyLocationType
    {
        public static readonly string EMPTY = "EMPTY";
        public static readonly string PLANET = "PLANET";
    }
}
