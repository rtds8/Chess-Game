using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Editorial_Script : MonoBehaviour
{
    [MenuItem("Window/Make Sub Lists")]
    public static void Create()
    {
        Board_Manager boardManager = FindObjectOfType<Board_Manager>();
        boardManager.CreateLists();
    }

    [MenuItem("Window/Clear Sub Lists")]
    public static void Clear()
    {
        Board_Manager boardManager = FindObjectOfType<Board_Manager>();
        boardManager.ClearLists();
    }
}
