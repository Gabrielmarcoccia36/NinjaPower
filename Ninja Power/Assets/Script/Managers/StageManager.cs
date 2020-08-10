using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    private StageNotice notice;
    private MainCanvas mainCanvas;

    System.Random random = new System.Random();

    public bool ready = false;
    private bool noticeOn = false;
    private float timer;
    private float dissapear = .5f;
    private int num;
    private int maxFight = 3;
    private int curFight = 0;

    private void Awake()
    {
        mainCanvas = FindObjectOfType<MainCanvas>();
        notice = FindObjectOfType<StageNotice>();
        notice.gameObject.SetActive(false);
        num = random.Next(2, 6);
        mainCanvas.SPText.text = curFight + "/" + maxFight;
    }

    private void Update()
    {
        if (!ready)
        {
            timer += Time.deltaTime;

            if (noticeOn && timer >= dissapear)
            {
                notice.gameObject.SetActive(false);
            }

            if (timer >= num)
            {
                notice.gameObject.SetActive(true);
                noticeOn = true;
                curFight++;
                mainCanvas.SPText.text = curFight + "/" + maxFight;
                num = random.Next(2, 6);
                timer = 0;
            }

            if (curFight == maxFight)
            {
                ready = true;
                mainCanvas.SetFightButton(true);
                notice.gameObject.SetActive(false);
            }
        }
    }
}
