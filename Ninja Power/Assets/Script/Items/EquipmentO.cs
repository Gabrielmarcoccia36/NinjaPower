using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equipment Object", menuName = "Iventory System/Items/Equipment")]

public class EquipmentO : ItemO
{
    public float atkBonus;
    public float defBonus;
    public float lvl;

    public void Awake()
    {
        Type = ItemType.Equipment;
    }

    public override ItemO GetCopy()
    {
        return Instantiate(this);
    }

    public override void Desroy()
    {
        Destroy(this);
    }

}
