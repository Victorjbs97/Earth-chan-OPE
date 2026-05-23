using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cenaFinalScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ircenafinal()
    {
        StartCoroutine(tempespera());
    }
    IEnumerator tempespera() 
    {
        yield return new WaitForSeconds(3.2f);
        SceneManager.LoadScene("creditos");
    }

}
