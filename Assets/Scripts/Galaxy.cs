using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Galaxy : MonoBehaviour
{
    public GameObject galaxyLocationPrefab;
    public GameObject[,] locations;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void generateLocations(GalaxyGenerationParameters parameters)
    {
        Debug.Log("Generating locations");
        this.locations = new GameObject[parameters.rowCount, parameters.columnCount];
        for (int row = 0; row < parameters.rowCount; row++)
        {
            for (int column = 0; column < parameters.columnCount; column++)
            {
                var location = Instantiate(galaxyLocationPrefab);
                Assert.IsNotNull(location);
                location.transform.position = new Vector3(row - parameters.rowCount / 2 + .5f, column - parameters.columnCount / 2 + .5f);
                location.transform.SetParent(this.transform);
                this.locations[row, column] = location;
            }
        }
    }

    public void generate(System.Random random, GalaxyGenerationParameters parameters)
    {
        generateLocations(parameters);
        Debug.Log("Loading GalaxyLocation prefab");
        galaxyLocationPrefab = Resources.Load<GameObject>("Prefabs/GalaxyLocation");
        Assert.IsNotNull(this.galaxyLocationPrefab);
        Debug.Log("Generating Galaxy");
        var regions = new GameObject[parameters.rowCount, parameters.columnCount];
        Debug.Log(parameters.rowCount + " rows");
        Debug.Log(parameters.columnCount + " columns");
        for (int row = 0; row < parameters.rowCount; row++)
        {
            for (int column = 0; column < parameters.columnCount; column++)
            {
                Debug.Log("Generating Location");
                //Determine contents of region.
                bool containsPlanet = random.Next(1, 100) <= (int)(parameters.planetDensity * 100);
                float horizontalOffset = random.Next(-5, 5) / 10f;
                float verticalOffset = random.Next(-5, 5) / 10f;
                var sprite = parameters.planetSpriteOptions[random.Next(0, parameters.planetSpriteOptions.Length)];
                var location = this.locations[row, column];
                var galaxyLocation = location.GetComponent<GalaxyLocation>();
                galaxyLocation.type = containsPlanet ? GalaxyLocation.GalaxyLocationType.PLANET :
                    GalaxyLocation.GalaxyLocationType.EMPTY;
                location.GetComponent<SpriteRenderer>().sprite = sprite;

                regions[row, column] = location;
            }
        }
        locations = regions;
    }

    public class GalaxyGenerationParameters
    {
        public int rowCount;
        public int columnCount;
        public float minHorizontalPosition;
        public float maxHorizontalPosition;
        public float minVerticalPosition;
        public float maxVerticalPosition;
        public float planetDensity;
        public Sprite[] planetSpriteOptions;

        public GalaxyGenerationParameters(int rowCount, int columnCount, float minHorizontalPosition,
            float maxHorizontalPosition, float minVerticalPosition, float maxVerticalPosition, float planetDensity,
            Sprite[] planetSpriteOptions)
        {
            this.rowCount = rowCount;
            this.columnCount = columnCount;
            this.minHorizontalPosition = minHorizontalPosition;
            this.maxHorizontalPosition = maxHorizontalPosition;
            this.minVerticalPosition = minVerticalPosition;
            this.maxVerticalPosition = maxVerticalPosition;
            this.planetDensity = planetDensity;
            this.planetSpriteOptions = planetSpriteOptions;
        }
    }
}
