using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ZetsuP Object", menuName = "Iventory System/Items/ZetsuPiece")]


public class ZetsuPieceO : ItemO
{

    public void Awake()
    {
        Type = ItemType.ZetsuP;
    }


}
