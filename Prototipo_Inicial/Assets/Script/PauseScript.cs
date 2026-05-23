using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update

    public static bool gamePause = false;
    public bool ativacod;

    public GameObject MenuPause;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                VoltarGame();
            }
            else
            {
                Pausa();
            }
        }
    }

    public void VoltarGame()
    {
        MenuPause.SetActive(false);
        Time.timeScale = 1f;
        gamePause = false;
    }

    public void Pausa()
    {
        MenuPause.SetActive(true);
        Time.timeScale = 0f;
        gamePause = true;
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void VoltarMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
