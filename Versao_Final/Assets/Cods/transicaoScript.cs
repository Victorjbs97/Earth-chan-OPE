using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[DefaultExecutionOrder(-30)]

public class transicaoScript : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animTran;
    public static bool mudatela;
    private bool tela,espera;
    void Start()
    {
        tela = false;
        espera = false;
        animTran=gameObject.GetComponent<Animator>();
    }
    private void Awake()
    {
        tela = false;
        espera = false;
    }

    // Update is called once per frame
    void Update()
    {
        tela = mudatela;
        if (tela &&!espera) 
        {

             mudarATela();
              
        }
    }

    void mudarATela()
    {
        espera = true;
        StartCoroutine(tempAnim());

    }
    IEnumerator tempAnim()
    {
        yield return new WaitForSeconds(0.8f);
        animTran.SetTrigger("End");

        
    }
}
