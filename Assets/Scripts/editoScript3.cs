using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class editoScript3 : EditorWindow
{
   // static boardManager boardManager = new boardManager();
    [MenuItem("Window/CreateLists")]
    public static void Window()
    {
        GetWindow<editoScript3>("Createe List");
    }

    private void OnGUI()
    {
        if (GUILayout.Button("Create"))
        {
            boardManager boardManager = FindObjectOfType<boardManager>();
            boardManager.Addlist();
        }

        else if(GUILayout.Button("Remove"))
        {
            boardManager boardManager = FindObjectOfType<boardManager>();
            boardManager.RemoveList();
        }

        if(GUILayout.Button("CurrentTiles"))
        {
            boardManager boardManager = FindObjectOfType<boardManager>();
            boardManager.CurrentTiles();
        }

    }


}
