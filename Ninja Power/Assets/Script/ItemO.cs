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
    public ItemType Type;
    [TextArea(10,15)]
    public string description;

}
