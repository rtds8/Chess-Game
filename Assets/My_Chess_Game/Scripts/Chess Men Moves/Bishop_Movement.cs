using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop_Movement : MonoBehaviour
{
    [SerializeField] private LayerMask Tiles;
    private GameObject m_selectedTile;
    private int counter = 0, flag = 0, m_currentTileIndex = -1;
    public List<GameObject> pathTiles = new List<GameObject>();
    void FixedUpdate()
    {
        if (this.gameObject == Selection_Handler._instance.m_current && counter == 0)
        {
            if (Physics.Raycast(this.gameObject.transform.position, Vector3.down, out RaycastHit hitinfo, Mathf.Infinity, Tiles))
            {
                m_selectedTile = hitinfo.transform.gameObject;
                TraceBishopsPath();
                counter = 1;
            }
        }

        if (Selection_Handler._instance.m_current == null || this.gameObject != Selection_Handler._instance.m_current)
        {
            counter = 0;
            ClearBishopsPath();
        }
    }

    void TraceBishopsPath()
    {
        for (int i = 0; i < 64; i++)
        {
            if (Board_Manager.instance.allTiles[i] == m_selectedTile && flag == 0)
            {
                m_currentTileIndex = i;
                flag = 1;
            }
        }

        if (pathTiles.Count <= 15)
        {
            pathTiles.Add(m_selectedTile);

            for (int j = 0; j < Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Up_Diagonal_Tiles.Count; j++)
            {
                pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Up_Diagonal_Tiles[j]);
            }

            for (int j = 0; j < Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Up_Diagonal_Tiles.Count; j++)
            {
                pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Up_Diagonal_Tiles[j]);
            }

            for (int j = 0; j < Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Down_Diagonal_Tiles.Count; j++)
            {
                pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Down_Diagonal_Tiles[j]);
            }

            for (int j = 0; j < Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Down_Diagonal_Tiles.Count; j++)
            {
                pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Down_Diagonal_Tiles[j]);
            }
        }

        if(pathTiles.Count > 0)
            Path_Highlight_Manager.Instance.HighlightTiles(pathTiles);
    }

    void ClearBishopsPath()
    {
        //Path_Highlight_Manager.Instance.UnhighlightTiles(m_selectedTile, pathTiles);
        pathTiles.Clear();
    }
}
