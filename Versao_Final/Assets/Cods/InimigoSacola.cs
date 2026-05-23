using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSacola : MonoBehaviour
{

    public int health;
    public float speed;
    public float distanceAttack;

    protected bool isMoving = false;

    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();

    }



    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);


    }

    protected void Flip()
    {
        sprite.flipX = !sprite.flipX;
        speed *= -1;
    }


}