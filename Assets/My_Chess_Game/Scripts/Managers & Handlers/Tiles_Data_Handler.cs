using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiles_Data_Handler : MonoBehaviour
{
    [SerializeField] private GameObject m_currentTile;
    [SerializeField] private int m_currentIndex = -1;
    public List<GameObject> Right_Tiles;
    public List<GameObject> Left_Tiles;
    public List<GameObject> Forward_Tiles;
    public List<GameObject> Backward_Tiles;
    public List<GameObject> Left_Up_Diagonal_Tiles;
    public List<GameObject> Left_Down_Diagonal_Tiles;
    public List<GameObject> Right_Up_Diagonal_Tiles;
    public List<GameObject> Right_Down_Diagonal_Tiles;

    public void CreateSubLists()
    {
        m_currentTile = this.gameObject;

        //Getting_Current_Index

        for (int i = 0; i < 64; i++)
        {
            if (m_currentTile.name == Board_Manager.instance.allTiles[i].name)
            {
                m_currentIndex = i;
            }
        }

        //Right_Tiles

        for (int j = m_currentIndex + 1; j / 8 == m_currentIndex / 8; j++)
        {
            Right_Tiles.Add(Board_Manager.instance.allTiles[j]);
        }

        //Left_Tiles

        for (int j = m_currentIndex - 1; j / 8 == m_currentIndex / 8 && j >= 0; j--)
        {
            Left_Tiles.Add(Board_Manager.instance.allTiles[j]);
        }

        //Forward_Tiles

        for (int j = m_currentIndex + 8; j < 64 ; j += 8)
        {
            Forward_Tiles.Add(Board_Manager.instance.allTiles[j]);
        }

        //Backward_Tiles

        for (int j = m_currentIndex - 8; j >= 0; j -= 8)
        {
            Backward_Tiles.Add(Board_Manager.instance.allTiles[j]);
        }

        //Left_Up_Diagonal_Tiles

        int l = m_currentIndex + 7, k = m_currentIndex;
        while(( l / 8 == ( k / 8 ) + 1 ) && l < 64)
        {
            Left_Up_Diagonal_Tiles.Add(Board_Manager.instance.allTiles[l]);
            l += 7;
            k += 8;
        }

        //Left_Down_Diagonal_Tiles

        int m = m_currentIndex - 9, n = m_currentIndex;
        while ((m / 8 == (n / 8) - 1) && m >= 0)
        {
            Left_Down_Diagonal_Tiles.Add(Board_Manager.instance.allTiles[m]);
            m -= 9;
            n -= 8;
        }

        //Right_Up_Diagonal_Tiles

        int p = m_currentIndex + 9, q = m_currentIndex;
        while ((p / 8 == (q / 8) + 1) && p < 64)
        {
            Right_Up_Diagonal_Tiles.Add(Board_Manager.instance.allTiles[p]);
            p += 9;
            q += 8;
        }

        //Right_Down_Diagonal_Tiles

        int r = m_currentIndex - 7, t = m_currentIndex;
        while ((r / 8 == (t / 8) - 1) && r >= 0)
        {
            Right_Down_Diagonal_Tiles.Add(Board_Manager.instance.allTiles[r]);
            r -= 7;
            t -= 8;
        }
    }

    public void ClearSubLists()
    {
        m_currentIndex = -1;
        m_currentTile = null;
        Right_Tiles.Clear();
        Left_Tiles.Clear();
        Forward_Tiles.Clear();
        Backward_Tiles.Clear();
        Left_Up_Diagonal_Tiles.Clear();
        Left_Down_Diagonal_Tiles.Clear();
        Right_Up_Diagonal_Tiles.Clear();
        Right_Down_Diagonal_Tiles.Clear();
    }
}