using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoDestruirSom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tempdes());
    }

    // Update is called once per frame
    IEnumerator tempdes() 
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
