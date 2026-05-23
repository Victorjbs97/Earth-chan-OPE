using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creditosVoltaMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(tempespera());
    }
    IEnumerator tempespera()
    {
        yield return new WaitForSeconds(40f);
        SceneManager.LoadScene("Menu");
    }
}
