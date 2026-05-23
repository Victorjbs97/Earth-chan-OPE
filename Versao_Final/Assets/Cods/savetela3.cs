using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-100)]
public class savetela3 : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("fase", 3);
    }
}
