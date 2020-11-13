using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class select : MonoBehaviour
{
     private static square m_currentsquare;
     public static square _Currentsquare { get => m_currentsquare;} //current square script of selected tile

    [SerializeField] private string knightTag = "Knight";
    [SerializeField] private string pawnTag = "Pawn";
    [SerializeField] private string rookTag = "Rook";
    [SerializeField] private string bishopTag = "Bishop";
    [SerializeField] private string queenTag = "Queen";
    [SerializeField] private string kingTag = "King";

    public Transform selected = null;
    public Transform selectedTile = null;
    public RaycastHit hit; //current selected piece
    public RaycastHit hit2; //second hit, for movement

    [SerializeField]private int tilesLayer = 1 << 8;
    [SerializeField]private int pieceLayer = 1 << 9;

    [SerializeField] private int index; //index at which current tile needs to be swapped

    [SerializeField] boardManager boardManager;
    private void Start()
    {
        selected = null;
        index = 0;
    }
    void Update()
    {
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity, pieceLayer))
            {
                var selection = hit.transform;

                if (selected != selection)
                {
                    if (selected != null)
                    {
                        selected.transform.position -= new Vector3(0, 0.5f, 0);
                        selected = null;
                    }
                    if (selection.CompareTag(rookTag) || selection.CompareTag(pawnTag) || selection.CompareTag(knightTag) || selection.CompareTag(bishopTag) || selection.CompareTag(queenTag) || selection.CompareTag(kingTag))
                    {
                        selection.transform.position += new Vector3(0, 0.5f, 0);
                    }
                }
                selected = selection;

                //Raising path
                path pathOf = selected.GetComponent<path>();
                pathOf.removePath();
                if (selected.CompareTag(rookTag))
                {
                    pathOf.rookPath();
                }
                else if (selected.CompareTag(pawnTag))
                {
                    pathOf.pawnPath();
                }
                else if (selected.CompareTag(knightTag))
                {
                    pathOf.knightPath();
                }
                else if (selected.CompareTag(bishopTag))
                {
                    pathOf.bishopPath();
                }
                else if (selected.CompareTag(queenTag))
                {
                    pathOf.queenPath();
                }
                else if (selected.CompareTag(kingTag))
                {
                    pathOf.kingPath();
                }


            Debug.Log(selected.localPosition);
            }

            //Movement
            if (Input.GetMouseButtonDown(0) && Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit2, Mathf.Infinity, tilesLayer) && boardManager.currentTiles.Contains(hit2.transform.gameObject.GetComponent<square>()) == false)
            {
                if (boardManager.pathRaised.Contains(hit2.transform.gameObject.GetComponent<square>()))
                {
                    Debug.Log("YES FINA<<Y");
                    selected.localPosition = new Vector3(hit2.transform.localPosition.x, selected.localPosition.y, hit2.transform.localPosition.z);

                    for (int i = 0; i < boardManager.pieces.Count; i++)
                    {
                        if (selected.GetComponent<path>() == boardManager.pieces[i])
                        {
                            index = i;
                            break;
                        }
                    }

                    boardManager.currentTiles.RemoveAt(index);
                    boardManager.currentTiles.Insert(index, hit2.transform.gameObject.GetComponent<square>());
                    selected.GetComponent<path>().m_currentsquare = hit2.transform.gameObject.GetComponent<square>();

                    path pathOf = selected.GetComponent<path>();
                    pathOf.removePath();

                    if (selected != null)
                    {
                        selected.transform.position -= new Vector3(0, 0.5f, 0);
                        selected = null;
                    }
                    
                }
            }

        //Debug.Log(index + "ind");



        // boardManager.currentTiles.Remove(_Currentsquare);

        //m_currentsquare = hit2.transform.gameObject.GetComponent<square>();

        //boardManager.currentTiles.Add(_Currentsquare);

    }
}


















/*if (Physics.Raycast(selected.localPosition, selected.TransformDirection(new Vector3(0, 0, -1)), out hit2, 1000, tilesLayer))
                {
                    m_currentsquare = hit2.transform.gameObject.GetComponent<square>();
                    //Debug.Log(_Currentsquare);

                     if(selectedTile != hit2.transform)
                     {
                         if(selectedTile != null)
                         {
                             selectedTile.position -= new Vector3(0, 1, 0);
                             selectedTile = null;
                         }

                         Debug.DrawRay(selected.localPosition, selected.TransformDirection(new Vector3(0, 0, -1)) * 1000, Color.yellow);

                         //getting the square script of the selected tile
                         m_currentsquare = hit2.transform.gameObject.GetComponent<square>();
                         if (hit.transform.gameObject.CompareTag(pawnTag))
                             pawn.pawn();


                         Debug.Log(m_currentsquare);

                         if (hit2.transform.gameObject.CompareTag(highlightTag))
                         {
                             //raising the selected tile
                             Debug.DrawRay(selected.localPosition, selected.TransformDirection(new Vector3(0, 0, -1)) * 1000, Color.yellow);
                             hit2.transform.position += new Vector3(0, 1, 0);

                             //getting the square script of the selected tile
                             m_currentsquare = hit2.transform.gameObject.GetComponent<square>();
                             //if(hit2.transform.gameObject == )
                             Debug.Log(m_currentsquare);
                         }

                     }

                }
                selectedTile = hit2.transform;
*/