using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Chess Men Data", menuName = "Create Chess Men Data/Chess Men")]
public class Chess_Men_Data : ScriptableObject
{
    public GameObject _currentTile;
    public int _maxTiles;
    public List<GameObject> _pathTiles;
}
