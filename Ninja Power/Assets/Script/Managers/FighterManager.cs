using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterManager : MonoBehaviour
{
    [Header("Lineup")]
    [SerializeField]
    private GameObject[] buttons;
    public CharacterStats[] lineupCharacter;

    [Header("Fighter Options")]
    [SerializeField]
    private GameObject[] options;
    [SerializeField]
    private CharacterStats[] fighterOptions;

}
