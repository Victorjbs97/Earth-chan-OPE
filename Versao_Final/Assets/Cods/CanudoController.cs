using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanudoController : MonoBehaviour
{
    protected int health;
    public float speed;
   public float distanceAttack;

    protected bool isMoving = false;

    protected Rigidbody2D rb2d;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;
    public bool face;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    protected float PlayerDistance()
    {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip()
    {
        face = !face;
        transform.Rotate(0f, 180, 0);
    }

}
