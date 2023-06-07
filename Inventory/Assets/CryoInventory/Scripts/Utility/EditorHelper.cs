using UnityEditor;
using UnityEngine;

namespace CryoInventory.Utility
{
    public static class EditorHelper
    {
        public static readonly GUIStyle HeadlineCenter = new GUIStyle(GUI.skin.label)
        {
            fontSize = 21,
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter,
            fixedHeight = 30
        };
        
        public static readonly GUIStyle BoldLabelCenter = new GUIStyle(GUI.skin.label)
        {
            fontStyle = FontStyle.Bold,
            alignment = TextAnchor.MiddleCenter,
        };

        public static void HorizontalLine(float height = 1)
        {
            Rect rect = EditorGUILayout.GetControlRect(false, height);

            rect.height = height;

            EditorGUI.DrawRect(rect, new Color ( 0.1f,0.1f,0.1f, 1 ) );
        }
    }
}