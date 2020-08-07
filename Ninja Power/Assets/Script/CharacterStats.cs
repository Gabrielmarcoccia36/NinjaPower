using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat atk;
    public Stat def;
    public Stat Tai;
    public Stat Nin;
    public Stat Spd;
    public Stat Agl;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage (int atk)
    {
        atk -= def.GetValue();
        atk = Mathf.Clamp(atk, 0, int.MaxValue);

        currentHealth -= atk;
        Debug.Log("CharacterStats, TakeDamage(); takes " + atk + " damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
        Debug.Log(" CharacterStats, Die(); died");
    }
}
