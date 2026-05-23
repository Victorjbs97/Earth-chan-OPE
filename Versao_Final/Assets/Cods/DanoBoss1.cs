using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoBoss1 : MonoBehaviour
{
    public int maxHealth = 100;
    [SerializeField]
    public static int currentHealth;
    public static int hitAnim;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hitAnim = 1;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

}
