using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ComecoStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
        Debug.Log("Começou");
    }

    public void Sair()
    {
   
        Application.Quit();
        Debug.Log("Sair");

    }

    public static void Telamorte() 
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("telamorte");

    }
}
