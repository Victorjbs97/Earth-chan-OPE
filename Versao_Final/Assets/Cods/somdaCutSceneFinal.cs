using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class somdaCutSceneFinal : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] passos;
    private audioManager audimanage;
    void Start()
    {
        audimanage = GetComponent<audioManager>();
    }

    // Update is called once per frame
    public void passossfx()
    {
        audimanage.PlayAudio(passos[Random.Range(0, passos.Length)], 1);
    }
}
