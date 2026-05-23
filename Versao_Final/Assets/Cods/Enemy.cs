using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed= -2;
    private float startSpeed = -5, atualvel;

    private float dazedTime, disPlayer;
    public float startDazedTime;
    private Rigidbody2D rb;

    private bool colisao, facePositiva,primeiracolisao;
    private GameObject player;
    public GameObject enemy;
    private float veldobrada, veldobradoPositiva, speedstart, temporizar;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
        veldobrada = (speed)*2;
        veldobradoPositiva = (speed) * -2;
        speedstart = speed;
        anim = gameObject.GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        temporizar += Time.deltaTime;
        disPlayer = UnityEngine.Vector2.Distance(enemy.transform.position, player.transform.position);
        if (!primeiracolisao) 
        {
            rb.velocity = new UnityEngine.Vector2(speed, rb.velocity.y);
        }
        if (temporizar >5) 
        {
            mov();
            temporizar = 0;
        }
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            colisao = true;
            if (!facePositiva)
            {
                facePositiva = true;
                primeiracolisao = true;
                temporizar = 0;        
            }
            else if (facePositiva)
            {
                facePositiva = false;
                primeiracolisao = true;
                temporizar =0;                
            }
            StartCoroutine(animacaoTime());

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Chao"))
        {
            colisao = false;

        }
    }
    public void TakeDamage(int damage) 
    {
        dazedTime = startDazedTime;
    }
    void flip() 
    {
        transform.Rotate(0f, 180, 0);
        colisao = false;
    }
    void mov() 
    {

        if (disPlayer <= 8)
        {
            if (!facePositiva)
            {
                speed = (veldobrada);
            }
            if (facePositiva)
            {
                speed = (veldobradoPositiva);
            }

        }
        if (disPlayer > 8)
        {
            if (!facePositiva)
            {
                speed = (speedstart);
            }
            if (facePositiva)
            {
                speed = (-speedstart);
            }

        }

        atualvel = speed;
        rb.velocity = new UnityEngine.Vector2(speed, rb.velocity.y);
        if (dazedTime <= 0)
        {
            speed = atualvel;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (colisao)
        {
            flip();
        }
    }
    IEnumerator animacaoTime() 
    {
        anim.SetBool("rolar",false);
        yield return new WaitForSeconds(0.583f);
        anim.SetBool("rolar", true);
        mov();
    }
}
