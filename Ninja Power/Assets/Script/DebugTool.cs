using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTool : MonoBehaviour
{
    private GameManager gameManager;

    public string current;
    public int amount = 0;
    private int index = 0;
    private string[] functions = new string[] { "Add Gold", "Consume Gold", "Add Diamonds", "Buy Diamonds", "Consume Diamonds", "Add Exp" };

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        current = functions[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            index -= 1;

            if (index < 0)
            {
                index = functions.Length - 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            index += 1;

            if(index > functions.Length - 1)
            {
                index = 0;
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            RunFunction();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (amount > 0)
            {
                amount -= 5;
            }
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            amount += 5;
        }



        ChangeFunction();

    }

    private void ChangeFunction()
    {
        current = functions[index];
    }

    private void RunFunction()
    {
        if (index == 0)
        {
            gameManager.AddGold(amount);
        }
        else if (index == 1)
        {
            gameManager.ConsumeGold(amount);
        }
        else if (index == 2)
        {
            gameManager.AddDiamonds(amount, false);
        }
        else if (index == 3)
        {
            gameManager.AddDiamonds(amount, true);
        }
        else if (index == 4)
        {
            gameManager.ConsumeDiamonds(amount);
        }
        else if (index == 5)
        {
            gameManager.AddExp(amount);
        }
    }
}
