using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class atkScript : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public LayerMask enemyLayers, bossMask, bossMask2;

    public float attackRange = 0.5f;
    public float attackRange2 = 0.5f;
    public int attackDamage = 40;

    public float attackRate = 1f;
    float NextAttackTime = 0;
    public bool atkTrue;
    public bool pPause;

    public AudioClip atkperto;
    private audioManager audimanage;
    [Range(0f, 1f)]
    public float volRange;



    private void Start()
    {
        audimanage = GetComponent<audioManager>();
    }

    private void Update()
    {
        atkTrue = PauseScript.GameIsPaused2;
        pPause = playermov2.PerderControle;

        if (!atkTrue || !pPause) 
        {
            if (Time.time >= NextAttackTime)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0) && playermov2.chaooutro || Input.GetKeyDown(KeyCode.F) && playermov2.chaooutro)
                {
                    StartCoroutine(Atk());
                    audimanage.PlayAudio(atkperto,0.25f);
                    NextAttackTime = Time.time + 1 / attackRate;
                } 
            }
        }


    }
 
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        //Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        //Gizmos.color = Color.red;
        Gizmos.DrawWireCube(attackPoint.position, (new Vector2( attackRange,attackRange2)));

    }

    IEnumerator Atk() 
    {
        yield return 0;
        anim.SetTrigger("atk1");
        Collider2D[] hitEnemies = Physics2D.OverlapBoxAll(attackPoint.position, (new Vector2(attackRange, attackRange2)),0, enemyLayers);
        Collider2D[] hitboss = Physics2D.OverlapBoxAll(attackPoint.position, (new Vector2(attackRange, attackRange2)), 0, bossMask);
        Collider2D[] hitboss2 = Physics2D.OverlapBoxAll(attackPoint.position, (new Vector2(attackRange, attackRange2)), 0, bossMask2);
        //Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            yield return new WaitForSeconds(0.25f);
            enemy.GetComponent<DanoNoEnemy>().TakeDamage(attackDamage);
            congela();

        }
        foreach (Collider2D boss in hitboss) 
        {
            yield return new WaitForSeconds(0.25f);
            boss.GetComponent<DanoBoss1>().TakeDamage(attackDamage);
            congela();
        }
        foreach (Collider2D boss2 in hitboss2)
        {
            yield return new WaitForSeconds(0.25f);
            boss2.GetComponent<DanoBoss2>().TakeDamage(attackDamage);
            congela();
        }
    }

    public void congela()
    {
        StartCoroutine(freeze());
    }
    IEnumerator freeze()
    {
        Time.timeScale = 0.1f;
        yield return new WaitForSeconds(0.01f);
        Time.timeScale = 1;
    }



}
