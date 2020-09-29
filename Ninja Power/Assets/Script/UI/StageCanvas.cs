using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StageCanvas : MonoBehaviour
{
    [SerializeField]
    private GameObject winText, loseText, infoText;

    private bool leave = false;
    private bool diamonds = false;
    private float timer;
    private int curStage;

    [SerializeField]
    private int goldToAdd = 100;
    [SerializeField]
    private int expToAdd = 10;

    private void Awake()
    {
        curStage = GameManager.Instance.GetStage();
        diamonds = curStage % 10 == 0;
    }

    private void Update()
    {
        if (leave)
        {
            timer += Time.deltaTime;

            if (timer>= 3)
            {
                OnContinue();
            }
        }
    }

    public void OnWinClick()
    {
        if (!diamonds)
        {
            GameManager.Instance.AddGold(goldToAdd * curStage);
            GameManager.Instance.AddExp(expToAdd * curStage);
            GameManager.Instance.BeatStage();
            winText.SetActive(true);
            infoText.SetActive(true);
            infoText.GetComponent<TextMeshProUGUI>().text = "+" + goldToAdd + " Gold\n+" + expToAdd + " Exp";
        }
        else
        {
            GameManager.Instance.AddGold(goldToAdd * curStage);
            GameManager.Instance.AddExp(expToAdd * curStage);
            GameManager.Instance.AddDiamonds(50, false);
            GameManager.Instance.BeatStage();
            winText.SetActive(true);
            infoText.SetActive(true);
            infoText.GetComponent<TextMeshProUGUI>().text = "+" + goldToAdd + " Gold\n+" + expToAdd + " Exp\n+50 Diamonds";
        }
        
        leave = true;
    }
    public void OnLoseClick()
    {
        loseText.SetActive(true);
        leave = true;
    }
    public void OnContinue()
    {
        SceneManager.LoadScene(0);
    }
}
