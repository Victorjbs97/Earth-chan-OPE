using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredeDano : MonoBehaviour
{
    public int Damagemc = 25;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        VidaMcControle player = collision.gameObject.GetComponent<VidaMcControle>();
        if (collision.gameObject.CompareTag("Player"))
        {
            congela();
            player.TakeDamagePlayer(Damagemc);
        }
    }
   
    public void congela()
    {
        StartCoroutine(freeze());
    }
    IEnumerator freeze()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 1;
    }
}
