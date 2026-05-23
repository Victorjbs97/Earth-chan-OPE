using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class morreuScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(esperatela());


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator esperatela() 
    {
        yield return new WaitForSeconds(2.5f);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
