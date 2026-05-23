using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danoVisualEfeito : MonoBehaviour
{
    public SpriteRenderer enemyR;
    public bool corred = false;
    void Start()
    {
        enemyR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (corred == true)
        {
            enemyR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(8 * Time.time, 0.5f));
        }

    }

    private IEnumerator OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("espadaHeroi"))
        {
            DanoCor();
            yield return 0;
        }

        void DanoCor()
        {
            corred = true;
            StartCoroutine(LiberarRed());

        }

        IEnumerator LiberarRed()
        {
            yield return new WaitForSeconds(0.5f);
            corred = false;
            enemyR.color = new Color(1, 1, 1, 1);

        }

    }
}
