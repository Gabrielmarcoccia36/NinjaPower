using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    [Header("Character Info")]
    public int ID;
    public new string name;
    [Tooltip("0 fire\n1 Wind\n2 Lightning\n3 Earth\n4 Water")]
    public int Nature;

    [Header("Base Stats")]
    public float MaxHealth;
    public float Tai;
    public float Nin;
    public float TaiDef;
    public float NinDef;
    public float Spd;
    public float Dod;

    [Header("Evolution Sprites")]
    public Sprite[] EvolSprites;
}
