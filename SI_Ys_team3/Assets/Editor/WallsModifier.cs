using UnityEngine;
using System.Collections;
using UnityEditor;

public class WallsModifier : EditorWindow {

    // Add menu named "My Window" to the Window menu
    [MenuItem("Walls/Modify Walls")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        WallsModifier window = (WallsModifier)EditorWindow.GetWindow(typeof(WallsModifier));
        window.Show();
    }

    void OnGUI()
    {
        if(Selection.gameObjects.Length == 1 && Selection.gameObjects[0].tag == "Cell")
        {
            GameObject go = Selection.gameObjects[0];

            GUILayout.Label("Change activated walls on selected cell", EditorStyles.boldLabel);
            go.transform.FindChild("WallUp").gameObject.SetActive(EditorGUILayout.Toggle("Upper Wall",
                                                                                         go.transform.FindChild("WallUp").gameObject.activeInHierarchy));
            go.transform.FindChild("WallDown").gameObject.SetActive(EditorGUILayout.Toggle("Down Wall",
                                                                                         go.transform.FindChild("WallDown").gameObject.activeInHierarchy));
            go.transform.FindChild("WallLeft").gameObject.SetActive(EditorGUILayout.Toggle("Left Wall",
                                                                                         go.transform.FindChild("WallLeft").gameObject.activeInHierarchy));
            go.transform.FindChild("WallRight").gameObject.SetActive(EditorGUILayout.Toggle("Right Wall",
                                                                                         go.transform.FindChild("WallRight").gameObject.activeInHierarchy));
        }
        else
        {
            GUILayout.Label("Select one cell to modify the walls", EditorStyles.boldLabel);
        }
        
        
    }
}
