using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RadioStationController))]
public class RadioStationControllerEditor : Editor 
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        RadioStationController myScript = (RadioStationController)target;
        if(GUILayout.Button("Next Station"))
        {
            myScript.NextStation();
        }
    }
}


