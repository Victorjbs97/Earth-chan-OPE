using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vasoC : MonoBehaviour
{

    [SerializeField]
    private Animator vasoAnim;

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("espadaHeroi"))
        {
            vasoAnim.Play("vasoquebra");
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
        }
    }
}
