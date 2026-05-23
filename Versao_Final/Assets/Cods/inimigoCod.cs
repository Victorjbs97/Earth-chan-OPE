using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoCod : InimigoSacola
{
    public float chamaAtk;
    public float rangeAtk = 1, rangeAtk2 = 1;
    public Transform atkPoint1;
    public LayerMask maskPlayer;
    private audioManager audioini;
    public AudioClip atksacolaVerdesfx;
    private void Start()
    {
        audioini = GetComponent<audioManager>();
    }

    private void Update()
    {
        float distance = PlayerDistance();
        chamaAtk += Time.deltaTime;
        isMoving = (distance <= distanceAttack);

        if (isMoving)
        {

            if ((player.position.x > transform.position.x && sprite.flipX) ||
              (player.position.x < transform.position.x && !sprite.flipX))
            {

                Flip();
            }
            Collider2D[] hitpoint1 = Physics2D.OverlapBoxAll(atkPoint1.position, (new Vector2(rangeAtk, rangeAtk2)), 0, maskPlayer);
            foreach (Collider2D jogador in hitpoint1)
            {
                if (chamaAtk >= 2)
                {
                    StartCoroutine(tempAtkSacolaVerde());
                    chamaAtk = 0;
                }

            }
        }
    }

    private void FixedUpdate()
    {
        if (isMoving)
        {
           // rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
        }

    }
    IEnumerator tempAtkSacolaVerde() 
    {
        anim.SetTrigger("t1");
        yield return new WaitForSeconds(0.417f);
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        anim.SetTrigger("t2");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(atkPoint1.position, (new Vector2(rangeAtk, rangeAtk2)));
    }

    public void somdaSacolaVerde() 
    {
        audioini.PlayAudio(atksacolaVerdesfx,0.5f);
    }

}
