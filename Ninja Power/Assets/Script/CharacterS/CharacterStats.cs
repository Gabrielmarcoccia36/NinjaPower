using System;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int ID;
    public int maxHealth = 100;
    public int currentHealth { get; private set; }
        
    public Stat Tai;
    public Stat Nin;
    public Stat TaiDef;
    public Stat NinDef;
    public Stat Spd;
    public Stat Dod;

    public int PowerLevel;

    public int bondLevel = 1;
    [Tooltip("0 fire\n1 Wind\n2 Lightning\n3 Earth\n4 Water")]
    public int Nature;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10, false, Nature);
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            TakeDamage(10, true, Nature);
        }

        PowerLevel = maxHealth + Tai.GetValue() + Nin.GetValue() + TaiDef.GetValue() + NinDef.GetValue() + TaiDef.GetValue() + Spd.GetValue();
    }

    public void TakeDamage (int damage, bool ninjutsu, int nature)
    {
        if (ninjutsu)
        {
            damage -= NinDef.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);
        }
        else
        {
            damage -= TaiDef.GetValue();
            damage = Mathf.Clamp(damage, 0, int.MaxValue);            
        }

        damage = damage + (int)(damage * CheckNature(nature));

        currentHealth -= damage;
        Debug.Log("CharacterStats, TakeDamage(); takes " + damage + " damage");

        // This might dissapear later
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public float CheckNature(int nature)
    {
        int tempNature;
        int tempNatureTwo;

        if (Nature - 1 == -1)
        {
            tempNature = 4;
        }
        else
        {
            tempNature = nature - 1;
        }

        if (Nature + 1 == 5)
        {
            tempNatureTwo = 0;
        }
        else
        {
            tempNatureTwo = nature + 1;
        }

        if (nature == tempNature)
        {
            return .05f;
        }
        else if (nature == tempNatureTwo)
        {
            return -.05f;
        }
        else
        {
            return 0;
        }
    }

    public virtual void Die()
    {
        gameObject.SetActive(false);
        Debug.Log(" CharacterStats, Die(); died");
    }
}
