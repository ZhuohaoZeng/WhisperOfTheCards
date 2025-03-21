using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CustomEditor(typeof(DrawPileManager))]
public class DrawPileManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        DrawPileManager drawPileManager = (DrawPileManager)target;
        if (GUILayout.Button("Draw Next Card"))
        {
            HandManager handManager = FindObjectOfType<HandManager>();
            if (handManager != null)
            {
                drawPileManager.DrawCard(handManager);
            }
        }
        base.OnInspectorGUI();
    }
}
