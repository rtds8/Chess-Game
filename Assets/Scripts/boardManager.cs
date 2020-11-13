using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardManager : MonoBehaviour
{
    public List<square> hightlight;
    //public boardManager Instance { get; private set; }

    public List<square> pathRaised;
    //public Stack<square> pathRaised;

    public List<square> currentTiles;

    public List<path> pieces;
    private void Start()
    {
        for (int i = 0; i < hightlight.Count; i++)
        {
           // Instantiate(hightlight[i]);
            hightlight[i].gameObject.transform.position -= new Vector3(0, 1, 0);
        }
    }

    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    //Editor script functions
    
    public void Addlist()
    {
       // if (Instance == null) { Instance = this; }
        
        for(int i = 0; i< 64; i++)
        {
            //Up
            for (int j = i+8; j<64; j+=8)
                hightlight[i].up.Add( hightlight[j]);

            //Down
            for(int j = i-8; j>=0; j-=8)
                hightlight[i].down.Add(hightlight[j]);

            //Right
            for (int j = i + 1; j / 8 == i / 8; j++)
                hightlight[i].right.Add(hightlight[j]);

            //Left
            for (int j = i - 1; j / 8 == i / 8 && j>=0; j--)
                hightlight[i].left.Add(hightlight[j]);

            //URD            
            for (int j = i + 9, prev = i; j < 64 && (j / 8)-1 == prev / 8; j += 9)
            {
                prev = j;
                hightlight[i].upperRighDiagonal.Add(hightlight[j]);
            }

            //ULD
            for (int j = i + 7, prev = i; j / 8 != prev / 8 && j < 64; j += 7)
            {
                prev = j;
                hightlight[i].upperLeftDiagonal.Add(hightlight[j]);
            }

            //LRD
            for (int j = i - 7, prev = i; j / 8 != prev / 8 && j >= 0; j -= 7)
            {
                prev = j;
                hightlight[i].lowerRighDiagonal.Add(hightlight[j]);
            }

            //LLD
            for (int j = i - 9, prev = i; j >= 0 && (j / 8) + 1 == prev / 8; j -= 9)
            {
                prev = j;
                hightlight[i].lowerLeftDiagonal.Add(hightlight[j]);
            }
        }

    }

    public void RemoveList()
    {
        for (int i = 0; i < 64; i++)
        {
            hightlight[i].up.Clear();
            hightlight[i].down.Clear();
            hightlight[i].right.Clear();
            hightlight[i].left.Clear();
            hightlight[i].lowerLeftDiagonal.Clear();
            hightlight[i].lowerRighDiagonal.Clear();
            hightlight[i].upperLeftDiagonal.Clear();
            hightlight[i].upperRighDiagonal.Clear();

            Debug.Log(i);
        }

    }

    public void CurrentTiles()
    {
        for(int i = 0; i<= pieces.Count; i++)
        {
            currentTiles.Add(pieces[i].m_currentsquare);
        }
    }
}

