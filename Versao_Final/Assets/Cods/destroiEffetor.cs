using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroiEffetor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("destroicomponente");
    }

    // Update is called once per frame
    IEnumerator destroicomponente() 
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
