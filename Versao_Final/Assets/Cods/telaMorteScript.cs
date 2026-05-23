using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class telaMorteScript : MonoBehaviour
{
    int carregarfase;
    bool podepassar;
    // Start is called before the first frame update
    void Start()
    {
        podepassar = false;
       carregarfase =  PlayerPrefs.GetInt("fase");
        StartCoroutine(loadBack());
        StartCoroutine(tempdeespera());

    }
    private void FixedUpdate()
    {
        if (podepassar) 
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                pessButton();
            }
        }
        
    }
    IEnumerator loadBack() 
    {
        yield return new WaitForSeconds(9f);
        if (carregarfase ==1) 
        {
            SceneManager.LoadScene("Fase 1");
        }
        if (carregarfase ==2) 
        {
            SceneManager.LoadScene("Fase 2");
        }
        if (carregarfase==3) 
        {
            SceneManager.LoadScene("Fase 3");
        }
        if (carregarfase == 4) 
        {
            SceneManager.LoadScene("telaBoss");
        }

    }

    void pessButton()
    {
        if (carregarfase == 1)
        {
            SceneManager.LoadScene("Fase 1");
        }
        if (carregarfase == 2)
        {
            SceneManager.LoadScene("Fase 2");
        }
        if (carregarfase == 3)
        {
            SceneManager.LoadScene("Fase 3");
        }
        if (carregarfase == 4)
        {
            SceneManager.LoadScene("telaBoss");
        }
    }
    IEnumerator tempdeespera() 
    {
        yield return new WaitForSeconds(1f);
        podepassar = true;
    }
}
