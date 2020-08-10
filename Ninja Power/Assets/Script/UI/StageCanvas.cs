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
    private float timer;

    [SerializeField]
    private int goldToAdd = 300;
    [SerializeField]
    private int expToAdd = 50;

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
        GameManager.Instance.AddGold(goldToAdd);
        GameManager.Instance.AddExp(expToAdd);
        GameManager.Instance.BeatStage();
        winText.SetActive(true);
        infoText.SetActive(true);
        infoText.GetComponent<TextMeshProUGUI>().text = "+" + goldToAdd + " Gold\n+" + expToAdd + " Exp";
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
