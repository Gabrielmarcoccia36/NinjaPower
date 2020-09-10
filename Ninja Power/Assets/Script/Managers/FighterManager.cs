using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FighterManager : MonoBehaviour
{
    [Header("Power Level UI")]
    [SerializeField]
    private TextMeshProUGUI powerLevelUI;

    [Header("Lineup")]
    [SerializeField]
    private TextMeshProUGUI[] buttons;
    public CharacterStats[] lineupCharacter;

    [Header("Fighter Options")]
    [SerializeField]
    private GameObject[] options;
    [SerializeField]
    private CharacterStats[] fighterOptions;

    private bool lineupBtnClicked = false;
    private int clickedBtn;

    private int lineupPower = 0;

    private void Awake()
    {
        for (int i = 0; i < lineupCharacter.Length; i++)
        {
            fighterOptions[i].CalculatePowerLevel();
        }    
    }

    private void Start()
    {
        lineupCharacter = GameManager.Instance.Lineup;
        powerLevelUI.text = "Power: " + GameManager.Instance.power;
        lineupPower = GameManager.Instance.power;
        SetDefaults();
    }

    public void SetPowerLevel(CharacterStats character, bool adding)
    {
        if (adding)
        {
            lineupPower += character.PowerLevel;
        }
        else
        {
            lineupPower -= character.PowerLevel;
        }

        powerLevelUI.text = "Power: " + lineupPower;
        GameManager.Instance.SetPowerLevel(lineupPower);
        GameManager.Instance.Lineup = lineupCharacter;
    }

    public void SetDefaults()
    {
        for (int i = 0; i < lineupCharacter.Length; i++)
        {
            if (lineupCharacter[i] != null)
            {
                for (int f = 0; f < lineupCharacter.Length; f++)
                {
                    if(lineupCharacter[i].ID == f)
                    {
                        buttons[i].text = f.ToString();
                    }
                }
            }
        }
    }

    #region Button Functions
    // Lineup Buttons Clicked
    public void OnButtonOneClicked()
    {
        if (lineupBtnClicked)
            return;

        if (lineupCharacter[0] != null)
        {
            SetPowerLevel(lineupCharacter[0], false);
            lineupCharacter[0] = null;
            buttons[0].text = "X";
        }
        else
        {
            lineupBtnClicked = true;
            clickedBtn = 0;
            buttons[0].text = " ";
        }
    }
    public void OnButtonTwoClicked()
    {
        if (lineupBtnClicked)
            return;

        if (lineupCharacter[1] != null)
        {
            SetPowerLevel(lineupCharacter[1], false);
            lineupCharacter[1] = null;
            buttons[1].text = "X";
        }
        else
        {
            lineupBtnClicked = true;
            clickedBtn = 1;
            buttons[1].text = " ";
        }
    }
    public void OnButtonThreeClicked()
    {
        if (lineupBtnClicked)
            return;

        if (lineupCharacter[2] != null)
        {
            SetPowerLevel(lineupCharacter[2], false);
            lineupCharacter[2] = null;
            buttons[2].text = "X";
        }
        else
        {
            lineupBtnClicked = true;
            clickedBtn = 2;
            buttons[2].text = " ";
        }
    }
    public void OnButtonFourClicked()
    {
        if (lineupBtnClicked)
            return;

        if (lineupCharacter[3] != null)
        {
            SetPowerLevel(lineupCharacter[3], false);
            lineupCharacter[3] = null;
            buttons[3].text = "X";
        }
        else
        {
            lineupBtnClicked = true;
            clickedBtn = 3;
            buttons[3].text = " ";
        }
    }
    public void OnButtonFiveClicked()
    {
        if (lineupBtnClicked)
            return;

        if (lineupCharacter[4] != null)
        {
            SetPowerLevel(lineupCharacter[4], false);
            lineupCharacter[4] = null;
            buttons[4].text = "X";
        }
        else
        {
            lineupBtnClicked = true;
            clickedBtn = 4;
            buttons[4].text = " ";
        }
    }
    public void OnButtonSixClicked()
    {
        if (lineupBtnClicked)
            return;

        if (lineupCharacter[5] != null)
        {
            SetPowerLevel(lineupCharacter[5], false);
            lineupCharacter[5] = null;
            buttons[5].text = "X";
        }
        else
        {
            lineupBtnClicked = true;
            clickedBtn = 5;
            buttons[5].text = " ";
        }
    }

    // Options Buttons Clicked
    public void OnOptionOneClicked()
    {
        if (!lineupBtnClicked)
            return;

        buttons[clickedBtn].text = "0";
        lineupCharacter[clickedBtn] = fighterOptions[0];
        SetPowerLevel(lineupCharacter[clickedBtn], true);
        lineupBtnClicked = false;
    }
    public void OnOptionTwoClicked()
    {
        if (!lineupBtnClicked)
            return;

        buttons[clickedBtn].text = "1";
        lineupCharacter[clickedBtn] = fighterOptions[1];
        SetPowerLevel(lineupCharacter[clickedBtn], true);
        lineupBtnClicked = false;
    }
    public void OnOptionThreeClicked()
    {
        if (!lineupBtnClicked)
            return;

        buttons[clickedBtn].text = "2";
        lineupCharacter[clickedBtn] = fighterOptions[2];
        SetPowerLevel(lineupCharacter[clickedBtn], true);
        lineupBtnClicked = false;
    }
    public void OnOptionFourClicked()
    {
        if (!lineupBtnClicked)
            return;

        buttons[clickedBtn].text = "3";
        lineupCharacter[clickedBtn] = fighterOptions[3];
        SetPowerLevel(lineupCharacter[clickedBtn], true);
        lineupBtnClicked = false;
    }
    public void OnOptionFiveClicked()
    {
        if (!lineupBtnClicked)
            return;

        buttons[clickedBtn].text = "4";
        lineupCharacter[clickedBtn] = fighterOptions[4];
        SetPowerLevel(lineupCharacter[clickedBtn], true);
        lineupBtnClicked = false;
    }
    public void OnOptionSixClicked()
    {
        if (!lineupBtnClicked)
            return;

        buttons[clickedBtn].text = "5";
        lineupCharacter[clickedBtn] = fighterOptions[5];
        SetPowerLevel(lineupCharacter[clickedBtn], true);
        lineupBtnClicked = false;
    }
    #endregion
}
