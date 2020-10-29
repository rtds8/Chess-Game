using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Movement : MonoBehaviour
{
    [SerializeField] private GameObject m_currentTile;
    public List<GameObject> pathTiles = new List<GameObject>();
    private int c = 0, f = 0, m_currentTileIndex = -1, front = -1, left = -1, right = -1, back = -1;
    private bool addedAll = false;

    void FixedUpdate()
    {
        if (this.gameObject == Selection_Handler._instance.m_current && c == 0)
        {
            TraceKnightsPath();
            c = 1;
        }

        if (Selection_Handler._instance.m_current == null || this.gameObject != Selection_Handler._instance.m_current)
        {
            c = 0;
            ClearKnightsPath();
        }
    }

    void TraceKnightsPath()
    {
        for (int i = 0; i < 64; i++)
        {
            if (Board_Manager.instance.allTiles[i] == m_currentTile && f == 0)
            {
                m_currentTileIndex = i;
                pathTiles.Add(Board_Manager.instance.allTiles[m_currentTileIndex]);
                f = 1;
            }
        }

        front = m_currentTileIndex + 16;
        back = m_currentTileIndex - 16;
        right = m_currentTileIndex + 2;
        left = m_currentTileIndex - 2;

        if(pathTiles.Count < 10 && addedAll == false)
        {
            if (front < 64 && (front % 8) == (m_currentTileIndex % 8))
            {
                pathTiles.Add(Board_Manager.instance.allTiles[front].GetComponent<Tiles_Data_Handler>().Right_Tiles[0]);
                pathTiles.Add(Board_Manager.instance.allTiles[front].GetComponent<Tiles_Data_Handler>().Left_Tiles[0]);
            }

            if (back >= 0 && (back % 8) == (m_currentTileIndex % 8))
            {
                pathTiles.Add(Board_Manager.instance.allTiles[back].GetComponent<Tiles_Data_Handler>().Right_Tiles[0]);
                pathTiles.Add(Board_Manager.instance.allTiles[back].GetComponent<Tiles_Data_Handler>().Left_Tiles[0]);
            }

            if (left >= 0 && (left / 8) == (m_currentTileIndex / 8))
            {
                pathTiles.Add(Board_Manager.instance.allTiles[left].GetComponent<Tiles_Data_Handler>().Forward_Tiles[0]);
                pathTiles.Add(Board_Manager.instance.allTiles[left].GetComponent<Tiles_Data_Handler>().Backward_Tiles[0]);
            }

            if (right < 64 && (right / 8) == (m_currentTileIndex / 8))
            {
                pathTiles.Add(Board_Manager.instance.allTiles[right].GetComponent<Tiles_Data_Handler>().Forward_Tiles[0]);
                pathTiles.Add(Board_Manager.instance.allTiles[right].GetComponent<Tiles_Data_Handler>().Backward_Tiles[0]);
            }

            addedAll = true;
        }
        Path_Highlight_Manager.Instance.HighlightTiles(pathTiles);
    }

    void ClearKnightsPath()
    {
        pathTiles.Clear();
    }
}
