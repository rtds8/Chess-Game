using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Path_Highlight_Manager : MonoBehaviour
{
    public static Path_Highlight_Manager Instance;
    [SerializeField] private GameObject m_highlighted_Tile;
    private List<GameObject> m_highlightedTiles;
    
    void Start()
    {
        if(Instance==null)
        {
            Instance = this;
        }

        m_highlightedTiles = new List<GameObject>();

        for (int i = 0; i <= 28; i++)
        {
            GameObject obj = Instantiate(m_highlighted_Tile);
            obj.SetActive(false);
            m_highlightedTiles.Add(obj);
        }
    }

    public void HighlightTiles(List<GameObject> highlightedTiles)
    {
        if (highlightedTiles.Count > 1)
        {
            for (int i = 0; i < highlightedTiles.Count; i++)
            {
                m_highlightedTiles[i].transform.position = new Vector3(highlightedTiles[i].transform.position.x, m_highlighted_Tile.transform.position.y, highlightedTiles[i].transform.position.z);
                m_highlightedTiles[i].transform.rotation = m_highlighted_Tile.transform.rotation;
                m_highlightedTiles[i].SetActive(true);
            }
        }
    }

    public void UnhighlightTiles(GameObject currentTile, List<GameObject> highlightedTiles)
    {
        if(currentTile == highlightedTiles[0] && highlightedTiles.Count!=0)
        {
            for (int i = 0; i < m_highlightedTiles.Count; i++)
            {
                if (m_highlightedTiles[i].activeInHierarchy)
                {
                    m_highlightedTiles[i].SetActive(false);
                }
            }
        }   
    }
}
