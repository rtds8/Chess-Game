using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board_Manager : MonoBehaviour
{
    public static Board_Manager instance;
    public List<GameObject> allTiles;
 
    public void CreateLists()
    {
        instance = this;
        for(int i=0;i<64;i++)
        {
            allTiles[i].GetComponent<Tiles_Data_Handler>().CreateSubLists();
        }
    }

    public void ClearLists()
    {
        for(int i=0;i<64;i++)
        {
            allTiles[i].GetComponent<Tiles_Data_Handler>().ClearSubLists();
        }
    }

    private void Start()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
}
