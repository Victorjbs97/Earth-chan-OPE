using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balaCanudo : MonoBehaviour
{
    private Rigidbody2D rb;
    public int velbola= 5;
    public int dano;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -velbola;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        VidaMcControle player = other.GetComponent<VidaMcControle>();
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamagePlayer(dano);
            Destroy(gameObject);
        }
        if (!other.gameObject.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
