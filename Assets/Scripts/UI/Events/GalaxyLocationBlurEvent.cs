using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GalaxyLocationBlurEvent : BaseEventData {
    public readonly GalaxyLocation location;

    public GalaxyLocationBlurEvent(EventSystem eventSystem, GalaxyLocation location) : base(eventSystem)
    {
        this.location = location;
    }
}
