using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movebalaV : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D bala;
    private float vel;
    private Transform alvo;
    private Vector2 dir;
    private float angulo;

    public float danoNoPlayerShow = 5;
    public static float danoNoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        danoNoPlayer = danoNoPlayerShow;
        bala = GetComponent<Rigidbody2D>();
        alvo = GameObject.FindWithTag("Player").GetComponent<Transform>();
        vel = 4;
        dir = alvo.position - transform.position;

        angulo = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angulo, Vector3.forward);
        StartCoroutine(tempodestroi());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bala.velocity = dir.normalized * vel;  
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) 
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator tempodestroi() 
    {
        yield return new WaitForSeconds(4.0f);
        Destroy(gameObject);

    }
}
