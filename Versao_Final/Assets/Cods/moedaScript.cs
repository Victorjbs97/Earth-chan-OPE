using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moedaScript : MonoBehaviour
{
    public GameObject oudioPegarMoeda;
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player")) 
        {
            Instantiate(oudioPegarMoeda, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
