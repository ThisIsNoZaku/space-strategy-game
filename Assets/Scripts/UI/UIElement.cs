using UnityEngine;
using UnityEngine.Assertions;
using YamlDotNet.Serialization;
using UnityEngine.UI;

public class UIElement
{
    public string id { get; set; }
    public string type { get; set; }
    public UIElement[] children { get; set; }
    public GameObject attachedElement { get; private set; }
    public string layoutChildren { get; private set; }
    public string alignChildren { get; private set; }
    public int size { get; private set; }

    public void initialize(GameObject root, Deserializer deserializer = null)
    {
        if (type == "Canvas")
        {
            attachedElement = root;
        }
        else
        {
            var prefab = Resources.Load("Prefabs/UI/" + type);
            attachedElement = GameObject.Instantiate(prefab, root.transform) as GameObject;
            Assert.IsNotNull(attachedElement);
            attachedElement.name = id;
            var componentRectTransform = attachedElement.GetComponent<RectTransform>();
            componentRectTransform.SetParent(root.transform, true);
            componentRectTransform.offsetMin = new Vector2(0, 0);
            if (children != null)
            {
                applyChildLayout();
            }
            componentRectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 10);
        }

        if (type == "Text")
        {
            var textComponent = attachedElement.GetComponent<Text>();
            textComponent.alignment = TextAnchor.UpperCenter;
        }


        if (children != null)
        {
            foreach (var child in children)
            {
                child.initialize(attachedElement);
            }
        }
    }

    private void applyChildLayout()
    {
        Assert.IsNotNull(layoutChildren, "Component has children but doesn't defined required layoutChildren property");
        HorizontalOrVerticalLayoutGroup layout = null;
        switch(layoutChildren)
        {
            case "vertical":
                layout = attachedElement.AddComponent<VerticalLayoutGroup>();
                break;
            case "horizontal":
                layout = attachedElement.AddComponent<HorizontalLayoutGroup>();
                break;
           
        }
        Assert.IsNotNull(layout);

        Assert.IsNotNull(layoutChildren, "Component has children but doesn't defined required alignChildren property");
        switch (alignChildren)
        {
            case "upper-left":
                layout.childAlignment = TextAnchor.UpperLeft;
                break;
            case "upper-center":
                layout.childAlignment = TextAnchor.UpperCenter;
                break;
            case "upper-right":
                layout.childAlignment = TextAnchor.UpperRight;
                break;
            case "middle-left":
                layout.childAlignment = TextAnchor.MiddleLeft;
                break;
            case "middle-center":
                layout.childAlignment = TextAnchor.MiddleCenter;
                break;
            case "middle-right":
                layout.childAlignment = TextAnchor.MiddleRight;
                break;
            case "lower-left":
                layout.childAlignment = TextAnchor.LowerLeft;
                break;
            case "lower-center":
                layout.childAlignment = TextAnchor.LowerCenter;
                break;
            case "lower-right":
                layout.childAlignment = TextAnchor.LowerRight;
                break;
        }
    }

    private void applyChildAlignment()
    {
        switch (alignChildren)
        {
            case "upper-left":
                break;
        }
    }
}
