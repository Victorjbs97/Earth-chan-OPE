using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canudo : CanudoController
{
    public GameObject tiro;
    public Transform tiropoint;
    private float tempVerificador;
    public AudioClip cndAtksfx;
    private audioManager audimanage;

    void Start()
    {
        health = 20;
        audimanage = GetComponent<audioManager>();

    }

    
    void Update()
    {

        float distance = PlayerDistance();
        isMoving = (distance <= distanceAttack);

        if (isMoving)
        {
            if (player.position.x > transform.position.x && !face)
            {
                Flip();
            }
            else if (player.position.x < transform.position.x && face)
            {
                Flip();
            }
            tempVerificador += Time.deltaTime;
            if (tempVerificador > 3)
            {
                StartCoroutine(tempshot());
                tempVerificador = 0;
            }

        }
    }

    void FixedUpdate()
    {
        if (isMoving) {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
    }

    void ShootCanudo()
    {
        Instantiate(tiro, tiropoint.position, tiropoint.rotation);
    }
    IEnumerator tempshot() 
    {
        anim.SetTrigger("et1");
        yield return new WaitForSeconds(1.083f);
        anim.SetTrigger("et2");
        yield return new WaitForSeconds(0.001f);
        ShootCanudo();
        yield return new WaitForSeconds(0.167f);
        anim.SetTrigger("et3");
    }
    public void atkcanudosom() 
    {
        audimanage.PlayAudio(cndAtksfx,0.2f);
    }

}
