using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    [SerializeField] public square m_currentsquare;
    [SerializeField] boardManager boardManager;
    public void removePath()
    {
        for (int i= boardManager.pathRaised.Count - 1; i>= 0; i--)
        {
            boardManager.pathRaised[i].transform.localPosition -= new Vector3(0, 1, 0);
            boardManager.pathRaised.RemoveAt(i);
        }
        
    }
    public void pawnPath()
    {
        if(m_currentsquare.up.Count >= 2 )
            for(int i = 0; i< 2 && boardManager.currentTiles.Contains(m_currentsquare.up[i]) != true; i++)
            {
                m_currentsquare.up[i].transform.localPosition += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.up[i]);
            }
        else if(m_currentsquare.up.Count == 1 && boardManager.currentTiles.Contains(m_currentsquare.up[0]) != true)
        {
            m_currentsquare.up[0].transform.localPosition += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.up[0]);
        }
    }

    public void rookPath()
    {
        for (int i = 0; i < m_currentsquare.up.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.up[i]) != true)
            {
                m_currentsquare.up[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.up[i]);
            }
            else break;
        }

        for (int i = 0; i < m_currentsquare.down.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.down[i]) != true)
            {
                m_currentsquare.down[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.down[i]);
            }
            else break;
        }

        for (int i = 0; i < m_currentsquare.left.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.left[i]) != true)
            {
                m_currentsquare.left[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.left[i]);
            }
            else break;
        }

        for (int i = 0; i < m_currentsquare.right.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.right[i]) != true)
            {
                m_currentsquare.right[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.right[i]);
            }
            else break;
        }

    }

    public void knightPath()
    {
        if (m_currentsquare.up.Count >= 2)
        {
            if (m_currentsquare.up[1].left.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.up[1].left[0]) == false)
            {
                m_currentsquare.up[1].left[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.up[1].left[0]);
            }

            if (m_currentsquare.up[1].right.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.up[1].right[0]) == false)
            {
                m_currentsquare.up[1].right[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.up[1].right[0]);
            }
        }

        if (m_currentsquare.down.Count >= 2)
        {
            if (m_currentsquare.down[1].left.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.down[1].left[0]) == false)
            {
                m_currentsquare.down[1].left[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.down[1].left[0]);
            }

            if (m_currentsquare.down[1].right.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.down[1].right[0]) == false)
            {
                m_currentsquare.down[1].right[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.down[1].right[0]);
            }
        }


        if (m_currentsquare.left.Count >= 2)
        {

            if (m_currentsquare.left[1].up.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.left[1].up[0]) == false)
            {
                m_currentsquare.left[1].up[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.left[1].up[0]);
            }

            if (m_currentsquare.left[1].down.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.left[1].down[0]) == false)
            {
                m_currentsquare.left[1].down[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.left[1].down[0]);
            }
        }

        if (m_currentsquare.right.Count >= 2)
        {

            if (m_currentsquare.right[1].up.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.right[1].up[0]) == false)
            {
                m_currentsquare.right[1].up[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.right[1].up[0]);
            }

            if (m_currentsquare.right[1].down.Count > 0 && boardManager.currentTiles.Contains(m_currentsquare.right[1].down[0]) == false)
            {
                m_currentsquare.right[1].down[0].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.right[1].down[0]);
            }
        }

    }

    public void bishopPath()
    {
        for (int i = 0; i < m_currentsquare.upperLeftDiagonal.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.upperLeftDiagonal[i]) != true)
            {
                m_currentsquare.upperLeftDiagonal[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.upperLeftDiagonal[i]);
            }
            else break;
        }

        for (int i = 0; i < m_currentsquare.upperRighDiagonal.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.upperRighDiagonal[i]) != true)
            {
                m_currentsquare.upperRighDiagonal[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.upperRighDiagonal[i]);
            }
            else break;
        }

        for (int i = 0; i < m_currentsquare.lowerLeftDiagonal.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.lowerLeftDiagonal[i]) != true)
            {
                m_currentsquare.lowerLeftDiagonal[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.lowerLeftDiagonal[i]);
            }
            else break;
        }

        for (int i = 0; i < m_currentsquare.lowerRighDiagonal.Count; i++)
        {
            if (boardManager.currentTiles.Contains(m_currentsquare.lowerRighDiagonal[i]) != true)
            {
                m_currentsquare.lowerRighDiagonal[i].transform.position += new Vector3(0, 1, 0);
                boardManager.pathRaised.Add(m_currentsquare.lowerRighDiagonal[i]);
            }
            else break;
        }
    }

    public void queenPath()
    {
        rookPath();
        bishopPath();
    }

    public void kingPath()
    {
        if(m_currentsquare.up[0] != null && boardManager.currentTiles.Contains(m_currentsquare.up[0]) != true)
        {
            m_currentsquare.up[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.up[0]);
        }

        if (m_currentsquare.down[0] != null && boardManager.currentTiles.Contains(m_currentsquare.down[0]) != true)
        {
            m_currentsquare.down[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.down[0]);
        }

        if (m_currentsquare.right[0] != null && boardManager.currentTiles.Contains(m_currentsquare.right[0]) != true)
        {
            m_currentsquare.right[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.right[0]);
        }

        if (m_currentsquare.left[0] != null && boardManager.currentTiles.Contains(m_currentsquare.left[0]) != true)
        {
            m_currentsquare.left[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.left[0]);
        }

        if (m_currentsquare.upperLeftDiagonal[0] != null && boardManager.currentTiles.Contains(m_currentsquare.upperLeftDiagonal[0]) != true)
        {
            m_currentsquare.upperLeftDiagonal[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.upperLeftDiagonal[0]);
        }

        if (m_currentsquare.lowerRighDiagonal[0] != null && boardManager.currentTiles.Contains(m_currentsquare.lowerRighDiagonal[0]) != true)
        {
            m_currentsquare.lowerRighDiagonal[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.lowerRighDiagonal[0]);
        }

        if (m_currentsquare.upperRighDiagonal[0] != null && boardManager.currentTiles.Contains(m_currentsquare.upperRighDiagonal[0]) != true)
        {
            m_currentsquare.upperRighDiagonal[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.upperRighDiagonal[0]);
        }

        if (m_currentsquare.lowerLeftDiagonal[0] != null && boardManager.currentTiles.Contains(m_currentsquare.lowerLeftDiagonal[0]) != true)
        {
            m_currentsquare.lowerLeftDiagonal[0].transform.position += new Vector3(0, 1, 0);
            boardManager.pathRaised.Add(m_currentsquare.lowerLeftDiagonal[0]);
        }

    }
}
