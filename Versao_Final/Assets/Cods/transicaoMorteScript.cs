using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transicaoMorteScript : MonoBehaviour
{
    public static bool vmorte;
    bool verificador, vericadordamorte;
    Animator anima;
    void Start()
    {
        anima = gameObject.GetComponent<Animator>();
        verificador = false;
        vericadordamorte = false;
    }
    private void Awake()
    {
        verificador = false;
        vericadordamorte = false;
    }

    // Update is called once per frame
    void Update()
    {
        vericadordamorte = vmorte;
        if (vericadordamorte && !verificador)
        {
            verificador = true;
            exeAnim();
        }
    }
    void exeAnim() 
    {
        anima.SetTrigger("cmmorreu");
    }
}
