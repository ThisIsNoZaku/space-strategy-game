using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GalaxyLocationFocusEvent : BaseEventData
{
    public readonly GalaxyLocation location;

    public GalaxyLocationFocusEvent(EventSystem eventSystem, GalaxyLocation location): base(eventSystem)
    {
        this.location = location;
    }

}
