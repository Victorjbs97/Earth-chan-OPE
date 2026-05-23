using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoBoss2 : MonoBehaviour
{
    public int maxHealth2 = 100;
    public static int  currentHealth2;
    public static int hitAnim2;
    void Start()
    {
        currentHealth2 = maxHealth2;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        currentHealth2 -= damage;
        hitAnim2 = 1;
        if (currentHealth2 <= 0)
        {
            currentHealth2 = 0;
        }
    }
}
