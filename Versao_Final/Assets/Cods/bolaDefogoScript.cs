using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bolaDefogoScript : MonoBehaviour
{
    public float bolaVelocidade = 10;
    public int qDedano;
    public Rigidbody2D rbBola;
    public GameObject destroieffect;
    public LayerMask dano;

    // Start is called before the first frame update

    void Start()
    {
        rbBola.velocity = transform.right * bolaVelocidade;
    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D other)
    {
        DanoNoEnemy enemy = other.GetComponent<DanoNoEnemy>();
        DanoBoss1 boss = other.GetComponent<DanoBoss1>();
        DanoBoss2 boss2 = other.GetComponent<DanoBoss2>();
        if (other.gameObject.CompareTag("Enemy")) 
        {
            enemy.TakeDamage(qDedano);
        }
        if (other.gameObject.CompareTag("Boss")) 
        {
            boss.TakeDamage(qDedano);
        }
        if (other.gameObject.CompareTag("BossCima"))
        {
            boss2.TakeDamage(qDedano);
        }
        if (!other.gameObject.CompareTag("moeda")) 
        {
            Instantiate(destroieffect, transform.position,transform.rotation);
            Destroy(gameObject);
        }

    }

}
