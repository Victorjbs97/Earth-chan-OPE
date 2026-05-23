using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxTeste : MonoBehaviour
{

    private float length, starpos, fixey;
    public GameObject cam;
    public float parallaxEffect;



    // Start is called before the first frame update
    void Start()
    {
        starpos = transform.position.x;
        fixey = this.transform.position.y;
        //length = GetComponent<SpriteRenderer>().bounds.size.x;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = (cam.transform.position.x * (1 - parallaxEffect));
        float dist = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(starpos + dist,fixey, transform.position.z);

       /* if (temp > starpos + length) starpos += length;
        else if (temp < starpos - length) starpos -= length; */
    }
}
