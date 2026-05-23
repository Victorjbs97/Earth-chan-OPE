using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsCutscenes : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animcut;
    private int teladoboss;
    public float tempocontrole =3;
    void Start()
    {
        tempocontrole = 3;
        animcut = gameObject.GetComponent<Animator>();
        teladoboss = PlayerPrefs.GetInt("fase");
        if (teladoboss==4) 
        {
            animcut.SetTrigger("cenaporta");
            playermov2.pausar = true;
            StartCoroutine(tempodeload());
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator tempodeload() 
    {
        yield return new WaitForSeconds(tempocontrole);
        animcut.SetTrigger("voltarAcena");
        yield return new WaitForSeconds(2);
        playermov2.pausar = false;

    }
}
