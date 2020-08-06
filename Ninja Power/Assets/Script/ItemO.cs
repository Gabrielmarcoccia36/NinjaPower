using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Equipment,
    ZetsuP,
    Fragments,
    Bonds,
}
public abstract class ItemO : ScriptableObject
{
    public Sprite sprite;
    public GameObject prefab;
    public ItemType Type;
    [TextArea(15,20)]
    public string description;
}
