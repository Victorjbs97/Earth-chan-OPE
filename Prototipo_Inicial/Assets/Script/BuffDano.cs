using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffDano : MonoBehaviour
{

    private bool pegouBufff = false;
    public static float maisDano;
    // Start is called before the first frame update
    void Start()
    {
        maisDano = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            pegouBufff = true;
            pegar();
            Destroy(gameObject);
        }
    }

    public void pegar() 
    {
        if (pegouBufff == true) 
        {
            maisDano = 10;

        }
    }
}
