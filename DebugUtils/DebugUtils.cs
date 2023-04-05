using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUtils
{
    public static void DrawText(string text, Vector3 position, Vector3 scale)
    {
        DrawText(text, position, scale, null, Color.white);
    }
    public static void DrawText(string text, Vector3 position, Vector3 scale, Transform parent, Color color, out TextMesh textMeshOut)
    {
        if (parent == null)
        {
            if (GameObject.Find("Debug") == null)
                parent = new GameObject("Debug").transform;
            else
                parent = GameObject.Find("Debug").transform;
        }
        GameObject textObject = new GameObject("Debug_text");
        textObject.transform.position = position;
        textObject.transform.localScale = scale;
        textObject.transform.parent = parent;

        TextMesh textComponent = textObject.AddComponent<TextMesh>();
        textComponent.fontSize = 100;
        textComponent.text = text;
        textComponent.color = color;
        textComponent.alignment = TextAlignment.Center;
        textComponent.anchor = TextAnchor.MiddleCenter;

        textMeshOut = textComponent;
    }
    public static void DrawText(string text, Vector3 position, Vector3 scale, Transform parent, Color color)
    {
        if (parent == null)
        {
            if (GameObject.Find("Debug") == null)
                parent = new GameObject("Debug").transform;
            else
                parent = GameObject.Find("Debug").transform;
        }

        GameObject textObject = new GameObject("Debug_text");
        textObject.transform.position = position;
        textObject.transform.localScale = scale;
        textObject.transform.parent = parent;

        TextMesh textComponent = textObject.AddComponent<TextMesh>();
        textComponent.fontSize = 100;
        textComponent.text = text;
        textComponent.color = color;
        textComponent.alignment = TextAlignment.Center;
        textComponent.anchor = TextAnchor.MiddleCenter;
    }
}
