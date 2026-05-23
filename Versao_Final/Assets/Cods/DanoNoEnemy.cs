using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoNoEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public GameObject deathEffect;

    private SpriteRenderer spriteEnemy;
    private bool cordeDano;
    private audioManager audioini;
    public AudioClip[] tomohit;
    void Start()
    {
        currentHealth = maxHealth;
        spriteEnemy = GetComponent<SpriteRenderer>();
        audioini =GetComponent<audioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cordeDano == true)
        {
            spriteEnemy.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(9 * Time.time, 0.3f));
        }
    }

    public void TakeDamage(int damage)
    {
        audioini.PlayAudio(tomohit[Random.Range(0,tomohit.Length)],0.5f);
        currentHealth -= damage;
        DanoCor();
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void DanoCor()
    {
        cordeDano = true;
        StartCoroutine(liberarCor());
    }
    IEnumerator liberarCor()
    {
        yield return new WaitForSeconds(0.5f);
        cordeDano = false;
        spriteEnemy.color = new Color(1, 1, 1, 1);
    }
}
