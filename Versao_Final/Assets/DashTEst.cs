using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashTEst : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    float DoubletapTime;
    KeyCode lastKeycode;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (DoubletapTime > Time.time && lastKeycode == KeyCode.A)
            {
                Debug.Log("Double A");
            }
            else 
            {
                DoubletapTime = Time.time + 0.3f;
            }
            lastKeycode = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (DoubletapTime > Time.time && lastKeycode == KeyCode.D)
            {
                Debug.Log("Double D");
            }
            else
            {
                DoubletapTime = Time.time + 0.3f;
            }
            lastKeycode = KeyCode.D;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (DoubletapTime > Time.time && lastKeycode == KeyCode.W)
            {
                Debug.Log("Double W");
            }
            else
            {
                DoubletapTime = Time.time + 0.3f;
            }
            lastKeycode = KeyCode.W;
        }
    }
}
