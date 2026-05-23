using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barravida : MonoBehaviour
{
    // Start is called before the first frame update

    Image vidabarra;
    float vidaMC = 250f;
    public static float vidaPlayer;

    void Start()
    {
        vidabarra = GetComponent<Image>();
        vidaPlayer = vidaMC;

    }

    // Update is called once per frame
    void Update()
    {
        vidabarra.fillAmount = vidaPlayer  / vidaMC;
    }
}
