using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class LocationDetailsPanel : MonoBehaviour {
    public Universe universe;
    public GalaxyLocation selectedLocation;

    private Text locationNameLabel;

	// Use this for initialization
	void Start () {
        this.locationNameLabel = GameObject.Find("LocationNameLabel").GetComponent<Text>();
        Assert.IsNotNull(this.locationNameLabel);
        universe = GameObject.Find("Universe").GetComponent<Universe>();
	}

    // Update is called once per frame
    void Update() {
        if (universe.state.selectedLocation != null)
        {
            GetComponent<Image>().enabled = true;
            if (universe.state.selectedLocation != selectedLocation)
            {
                selectedLocation = universe.state.selectedLocation;
                if (selectedLocation != null)
                {
                    updateLocationLabel();
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        } else
        {
            GetComponent<Image>().enabled = false;
        }
	}

    private void updateLocationLabel()
    {
        if (selectedLocation != null)
        {
            this.locationNameLabel.text = selectedLocation.name;
        }
        else
        {
            this.locationNameLabel.text = "";
        }
    }
}
