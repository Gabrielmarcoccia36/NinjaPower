using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get { return _instance; } }
    private static GameManager _instance;

    [Header("Player Info")]
    public int level = 1;
    public int power = 0;
    [SerializeField]
    private float experience = 0;
    [SerializeField]
    private float maxExp = 10;

    [Header("VIP / VIP Level Costs")]
    public int vip = 0;
    private int maxVip;
    [SerializeField]
    private int[] vipPrice;

    [Header("Player Resources")]
    [SerializeField]
    private int gold = 0;
    [SerializeField]
    private int diamonds = 0;
    [SerializeField]
    private int boughtDiamonds = 0;
    [SerializeField]
    private int spentDiamonds = 0;

    [Header("Game Info")]
    [SerializeField]
    private int stage = 1;
    [SerializeField]
    private int numNinjas = 0;

    private void Awake()
    {
        if (_instance != null && _instance != this)
            Destroy(gameObject);
        else
        {
            _instance = this;

            DontDestroyOnLoad(gameObject);
        }

        maxVip = vipPrice.Length;
    }

    // Currency
    public void AddGold(int add)
    {
        gold += add;
        Debug.Log("GameManager, AddGold(); Player received " + add + " gold.");
    }

    public bool CheckGold(int price)
    {
        if (gold >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ConsumeGold(int price)
    {
        if (gold >= price)
        {
            gold -= price;
            Debug.Log("GameManager, ConsumeGold(); Player spent " + price + " gold.");
        }
    }

    public void AddDiamonds(int add, bool bought)
    {
        diamonds += add;

        if (bought)
        {
            boughtDiamonds += add;
            CheckVIP();
            Debug.Log("GameManager, AddDiamonds(); Player bought " + add + " diamonds.");
        }
        else
        {
            Debug.Log("GameManager, AddDiamonds(); Player received " + add + " diamonds.");
        }
    }

    public bool CheckDiamonds(int price)
    {
        if (diamonds >= price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ConsumeDiamonds(int price)
    {
        if (diamonds >= price)
        {
            diamonds -= price;
            spentDiamonds += price;
            Debug.Log("GameManager, ConsumeGold(); Player spent " + price + " diamonds.");
        }
    }

    // VIP
    private void CheckVIP()
    {
        if (vip != vipPrice.Length)
        {
            for (int i = vip; i < vipPrice.Length; i++)
            {
                if (boughtDiamonds >= vipPrice[i])
                {
                    vip++;
                    Debug.Log("GameManager, CheckVip(): Player increased their VIP level to " + vip);
                }
            }
        }
    }

    // Level & Experience
    public void AddExp(int exp)
    {
        experience += exp;
        while (experience >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        level++;
        if (experience == maxExp)
        {
            experience = 0;
        }
        else
        {
            experience = experience - maxExp;
        }
        maxExp *= 1.05f;
        Debug.Log("GameManager, LevelUp(): Player leveled up.");
    }

    public int[] GetData()
    {
        return new int[] { level, (int)experience, vip, power, gold, diamonds };
    }
}
