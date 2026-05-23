using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DublePassar : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transicaoScript.mudatela) 
        {
            anim.SetTrigger("passar");
        }
    }
}
