using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDefesa : MonoBehaviour
{
    public static float maisDef;
    private bool pegouBuff = false;
    void Start()
    {
        maisDef = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            pegouBuff = true;
            pegar();
            Destroy(gameObject);
        }
    }

    public void pegar()
    {
        if (pegouBuff == true)
        {
            maisDef = -10;

        }
    }
}
