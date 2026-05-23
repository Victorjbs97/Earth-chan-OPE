using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class portaDoboss : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public int pegarVidaBoss;
    public AudioClip fechaAbre;
    private audioManager audimanage;


    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audimanage = GetComponent<audioManager>();
        Bosscod.portaUltimaAnim = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        pegarVidaBoss = Bosscod.VidaGeralBoss;
        if (pegarVidaBoss > 500 && pegarVidaBoss <= 750)
        {
            anim.SetTrigger("por2");
        }
        else if (pegarVidaBoss > 250 && pegarVidaBoss <= 500)
        {
            anim.SetTrigger("por3");
        }
        else if (pegarVidaBoss >= 50 && pegarVidaBoss <= 250)
        {
            anim.SetTrigger("por4");
        }
        else if (pegarVidaBoss == 0 && Bosscod.portaUltimaAnim)
        {
            StartCoroutine(utimaporta());
            anim.SetTrigger("por5");
        }
    }
    public void somdaPorta() 
    {
        audimanage.PlayAudio(fechaAbre,0.2f);

    }
    IEnumerator utimaporta() 
    {
        yield return new WaitForSeconds(1f);
        anim.SetTrigger("por5");
    }

}
