using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Player Info")]
    public int level = 1;
    public int power = 0;
    [SerializeField]
    private int experience = 0;
    [SerializeField]
    private int maxExp = 10;

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
    private int spentDiamonds = 0;

    [Header("Game Info")]
    [SerializeField]
    private int stage = 1;
    [SerializeField]
    private int numNinjas = 0;

    private void Awake()
    {
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
        if (price >= gold)
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
        if (price >= gold)
        {
            gold -= price;
            Debug.Log("GameManager, ConsumeGold(); Player spent " + price + " gold.");
        }
    }

    public void AddDiamonds(int add)
    {
        diamonds += add;
        Debug.Log("GameManager, AddDiamonds(); Player received " + add + " diamonds.");
    }

    public bool CheckDiamonds(int price)
    {
        if (price >= diamonds)
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
        if (price >= diamonds)
        {
            diamonds -= price;
            spentDiamonds += price;
            CheckVIP();
            Debug.Log("GameManager, ConsumeGold(); Player spent " + price + " diamonds.");
        }
    }

    // VIP
    private void CheckVIP()
    {
        if (spentDiamonds >= vipPrice[vip])
        {
            vip++;
            Debug.Log("GameManager, CheckVip(): Player increased their VIP level.");
        }
    }

    // Level & Experience
    public void AddExp(int exp)
    {
        experience += exp;
        if (experience >= maxExp)
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
        maxExp *= 2;
        Debug.Log("GameManager, LevelUp(): Player leveled up.");
    }
}
