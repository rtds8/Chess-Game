using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King_Movement : MonoBehaviour
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
                TraceKingsPath();
                counter = 1;
            }
        }

        if (Selection_Handler._instance.m_current == null || this.gameObject != Selection_Handler._instance.m_current)
        {
            counter = 0;
            ClearKingsPath();
        }
    }

    void TraceKingsPath()
    {
        for (int i = 0; i < 64; i++)
        {
            if (Board_Manager.instance.allTiles[i] == m_selectedTile && flag == 0)
            {
                m_currentTileIndex = i;
                flag = 1;
            }
        }

        if (pathTiles.Count <= 9)
        {
            pathTiles.Add(m_selectedTile);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Forward_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Up_Diagonal_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Up_Diagonal_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Backward_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Left_Down_Diagonal_Tiles[0]);
            pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex].GetComponent<Tiles_Data_Handler>().Right_Down_Diagonal_Tiles[0]);
        }

        if (pathTiles.Count > 0)
            Path_Highlight_Manager.Instance.HighlightTiles(pathTiles);
    }

    void ClearKingsPath()
    {
        //Path_Highlight_Manager.Instance.UnhighlightTiles(m_selectedTile, pathTiles);
        pathTiles.Clear();
    }
}
