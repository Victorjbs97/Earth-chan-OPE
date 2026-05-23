using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredeinvisivelVisivel : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    int pegarVidaBoss;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Bosscod.portaUltimaAnim = false;
    }

    private void FixedUpdate()
    {
        pegarVidaBoss = Bosscod.VidaGeralBoss;
        if (pegarVidaBoss > 500 && pegarVidaBoss <= 750)
        {
            anim.SetTrigger("p2");
        }
        else if (pegarVidaBoss > 250 && pegarVidaBoss <= 500)
        {
            anim.SetTrigger("p3");
        }
        else if (pegarVidaBoss >= 50 && pegarVidaBoss <= 250)
        {
            anim.SetTrigger("p4");
        }
        else if (pegarVidaBoss == 0 && Bosscod.portaUltimaAnim)
        {
            StartCoroutine(utima());
            playermov2.pausar = true;
        }
    }

    IEnumerator utima() 
    {
        //eu sei que ultima ta errado
        yield return new WaitForSeconds(1);
        anim.SetTrigger("p5");
    }
}
