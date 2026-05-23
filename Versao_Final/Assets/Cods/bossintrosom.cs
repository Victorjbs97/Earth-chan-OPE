using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossintrosom : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip entrado;
    private audioManager audimanage;
    void Start()
    {
        audimanage = GetComponent<audioManager>();
    }

    // Update is called once per frame
    public void entradoboss()
    {
        audimanage.PlayAudio(entrado, 0.3f);
    }
}
