using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class preparaTiro : MonoBehaviour
{


    [SerializeField]
    GameObject bullet;

    [SerializeField]
    GameObject Boca;

    float fireRate;
    float nextFire;



    void Start()
    {
        fireRate = 1.33f;
        nextFire = Time.time;
    }


    void Update()
    {
        CheckIfTimeToFire();
    }
    
    void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
