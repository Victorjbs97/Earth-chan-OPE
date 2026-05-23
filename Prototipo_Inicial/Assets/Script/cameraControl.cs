using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform playerCam;
    public float Smoth = 0.125f;
    public float cameraDistancia = 50.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void Awake()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistancia);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerCam.position.x , playerCam.position.y , transform.position.z);
    }


}
