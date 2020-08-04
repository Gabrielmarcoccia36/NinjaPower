using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private TextMeshProUGUI levelUI, experienceUI, vipUI, powerUI, goldUI, diamondsUI;
    private int[] data;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        data = gameManager.GetData();
        UpdateUI();
    }

    private void UpdateUI()
    {
        levelUI.text = "Level " + data[0];
        experienceUI.text = "Experience " + data[1];
        vipUI.text = "VIP " + data[2];
        powerUI.text = "Power " + data[3];
        goldUI.text = "Gold " + data[4];
        diamondsUI.text = "Diamonds " + data[5];
    }
}
