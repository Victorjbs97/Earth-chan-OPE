using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool GameIsPaused2 = false;
    public GameObject pauseMenuUI;
    void Start()
    {
        Time.timeScale = 1f;
        GameIsPaused2 = false;

    }
    private void Awake()
    {
        GameIsPaused2 = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused2)
            {
                retorno();
            }
            else 
            {
                pause();
            }
        }
    }

    public void retorno() 
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused2 = false;
    }
    void pause() 
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused2 = true;
    }
    public void VoltaMenu() 
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void sair() 
    {
        Application.Quit();
    }
}
