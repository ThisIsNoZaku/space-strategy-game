using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IGalaxyLocationBlurEventHandler : IEventSystemHandler
{
    void OnBlur(GalaxyLocationBlurEvent eventData);
	
}
