using UnityEngine;
using System.Collections;
using UnityEditor;



[CustomEditor(typeof(UIWidgetRecord))]
public class UIWidgetRecordInspector : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var wr = (UIWidgetRecord)this.target;
        if (wr.mWidth < 2)
        {
            wr.mWidth = 2;
        }
        if (wr.mHeight < 2)
        {
            wr.mHeight = 2;
        }
        GUILayout.BeginHorizontal();
        float width = EditorGUILayout.IntField("Size",(int) wr.mWidth, GUILayout.MinWidth(150f));
        EditorGUIUtility.labelWidth = 12f;
        float height = EditorGUILayout.FloatField("x", (int)wr.mHeight, GUILayout.MinWidth(30f));
        UnityEditor.Undo.RecordObject(wr, "wr");
        wr.mWidth = (width);
        wr.mHeight = (height);
        wr.OnRenderObject();
        if (GUILayout.Button("Snap", GUILayout.Width(60f)))
        {
            wr.MakePixelPerfect();
        }
        GUILayout.EndHorizontal();
    }
}