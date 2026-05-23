using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoNoMc : MonoBehaviour
{
    public int Damagemc = 25;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        VidaMcControle player = other.GetComponent<VidaMcControle>();
        if (other.gameObject.CompareTag("Player"))
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
