using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    int maxHealth = 3;
    int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void makeDead()
    {
        Destroy(gameObject);
    }


    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            makeDead();
        }
    }
}
