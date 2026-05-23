using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroiInimigo : MonoBehaviour
{
    public enum NivelDoInimigo 
    {
        nivel1 =1,
        nivel2 = 2,
        nivel3 =3,
        nivel4 = 4,
        nivel5 = 5,
        NivelBoss
    }
    public NivelDoInimigo selecao;

    public float vidainimigo1 = 100;
    public static float vidainimigonaBarra;
    public float danoDoMc = 20;
    private SpriteRenderer enemyR;
    public bool corred = false;
    public float danoNoPlayerShow;
    public static float danoNoPlayer;
    private float mostrarLevel=0;
    public Image barravida;

    // Start is called before the first frame update
    void Start()
    {
        EscolhaDeLEvel();
        enemyR = GetComponent<SpriteRenderer>();
        vidainimigonaBarra = vidainimigo1;

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
            vidainimigo1 = vidainimigo1 - (danoDoMc + BuffDano.maisDano) /2;
            yield return 0;
        }

        if (vidainimigo1 <= 0)
        {
            Destroy(gameObject);
        }
        
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

    public void EscolhaDeLEvel() 
    {
        switch (selecao) 
        {
            case NivelDoInimigo.nivel1:
                vidainimigo1 = 100;
                danoDoMc = 50;
                danoNoPlayerShow = 40;
                danoNoPlayer = danoNoPlayerShow;
                mostrarLevel = 1;
                break;
            case NivelDoInimigo.nivel2:
                vidainimigo1 = 150;
                danoDoMc = 45;
                danoNoPlayerShow = 40;
                danoNoPlayer = danoNoPlayerShow;
                mostrarLevel = 2;
                break;
            case NivelDoInimigo.nivel3:
                vidainimigo1 = 170;
                danoDoMc = 40;
                danoNoPlayerShow = 60;
                danoNoPlayer = danoNoPlayerShow;
                mostrarLevel = 3;
                break;
            case NivelDoInimigo.nivel4:
                vidainimigo1 = 170;
                danoDoMc = 40;
                danoNoPlayerShow = 70;
                danoNoPlayer = danoNoPlayerShow;
                mostrarLevel = 4;
                break;
            case NivelDoInimigo.nivel5:
                vidainimigo1 = 200;
                danoDoMc = 35;
                danoNoPlayerShow = 85;
                danoNoPlayer = danoNoPlayerShow;
                mostrarLevel = 5;
                break;

            case NivelDoInimigo.NivelBoss:
                vidainimigo1 = 500;
                danoDoMc = 40;
                danoNoPlayerShow = 100;
                danoNoPlayer = danoNoPlayerShow;
                mostrarLevel = 10;
                break;

        }
    }

    
}
