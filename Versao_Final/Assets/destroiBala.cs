using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroiBala : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(tempDestroi());
    }

    IEnumerator tempDestroi() 
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
