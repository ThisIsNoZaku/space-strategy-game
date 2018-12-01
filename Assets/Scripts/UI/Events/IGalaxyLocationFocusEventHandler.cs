using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IGalaxyLocationFocusEventHandler : IEventSystemHandler {
    void OnFocus(GalaxyLocationFocusEvent eventData);
	
}
