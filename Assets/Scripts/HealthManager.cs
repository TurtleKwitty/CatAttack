using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void DeathDelegate(GameObject character);

public class HealthManager : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    public DeathDelegate DeathFunc = (GameObject character) => { Destroy(character); };
    
    public void Heal(float amount)
    {
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
    }

    public void Attack(float amount)
    {
        CurrentHealth -= amount;
        if(CurrentHealth <= 0)
        {
            DeathFunc(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
