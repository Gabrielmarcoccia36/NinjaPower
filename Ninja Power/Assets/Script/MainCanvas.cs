﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainCanvas : MonoBehaviour
{
    private GameManager gameManager;

    // Data
    [Header("Data")]
    [SerializeField]
    private TextMeshProUGUI levelUI;
    [SerializeField]
    private TextMeshProUGUI experienceUI;
    [SerializeField]
    private TextMeshProUGUI vipUI;
    [SerializeField]
    private TextMeshProUGUI powerUI;
    [SerializeField]
    private TextMeshProUGUI goldUI;
    [SerializeField]
    private TextMeshProUGUI diamondsUI;

    private int[] data;

    // Panels
    [Header("Panels")]
    [SerializeField]
    private GameObject MainPanel;
    [SerializeField]
    private GameObject BagPanel;
    [SerializeField]
    private GameObject VillagePanel;
    [SerializeField]
    private GameObject NinjaPanel;
    [SerializeField]
    private GameObject ClonePanel;

    private GameObject curPanel;

    [Header("Buttons")]
    [SerializeField]
    private GameObject fightButton;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        curPanel = MainPanel;
        fightButton.SetActive(false);

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

    public void SetFightButton(bool ready)
    {
        if (ready)
        {
            fightButton.SetActive(true);
        }
        else
        {
            fightButton.SetActive(false);
        }
    }

    #region ButtonFunctions
    public void OnBagClicked()
    {
        curPanel.SetActive(false);
        BagPanel.SetActive(true);
        curPanel = BagPanel;
    }

    public void OnVillageClicked()
    {
        curPanel.SetActive(false);
        VillagePanel.SetActive(true);
        curPanel = VillagePanel;
    }

    public void OnNinjaClicked()
    {
        curPanel.SetActive(false);
        NinjaPanel.SetActive(true);
        curPanel = NinjaPanel;
    }

    public void OnCloneClicked()
    {
        MainPanel.SetActive(false);
        ClonePanel.SetActive(true);
        curPanel = ClonePanel;
    }

    public void OnBackClicked()
    {
        curPanel.SetActive(false);
        MainPanel.SetActive(true);
        curPanel = MainPanel;
    }

    public void OnFightClicked()
    {

    }
    #endregion
}
