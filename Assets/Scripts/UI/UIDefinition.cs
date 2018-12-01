using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Core;

public class UIDefinition : MonoBehaviour {
    public GameObject canvas;
    /**
     * How much of the available space this component should take up.
     */ 
    private int weight;

	// Use this for initialization
	void Start () {
        Assert.IsNotNull(canvas.GetComponent<Canvas>());
        load("ui", canvas.GetComponent<Canvas>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void load(string inputPath, Canvas root)
    {
        TextAsset configFile = Resources.Load(inputPath) as TextAsset;
        Assert.IsNotNull(configFile);
        Deserializer deserializer = new DeserializerBuilder()
            .WithNamingConvention(new CamelCaseNamingConvention())
            .Build();
        UIElement ui = deserializer.Deserialize<UIElement>(configFile.text);
        ui.initialize(canvas);
    }
}
