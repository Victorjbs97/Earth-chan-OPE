using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoLixo : MonoBehaviour
{
    public int Damagemc = 1;
    // Start is called before the first frame update

    private void OnTriggerStay2D(Collider2D other)
    {
        VidaMcControle player = other.GetComponent<VidaMcControle>();
        if (other.gameObject.CompareTag("Player"))
        {
            player.TakeDamagePlayer(Damagemc);
        }
    }

}
