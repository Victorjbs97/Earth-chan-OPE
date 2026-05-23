using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
[DefaultExecutionOrder(-10)]
public class Bosscod : MonoBehaviour
{
    public Transform atkPoint1, atkPoint2;
    public LayerMask maskPlayer;
    public float rangeAtk = 1, rangeAtk2 = 1, speed = 0, atkbaixo,atkcima;
    bool verifica;
    private Animator anim;
    public int vidaMask1, vidaMask2, vidaGeral=1;
    public static int VidaGeralBoss;

    public static bool portaUltimaAnim;

    // Start is called before the first frame update
    void Start()
    {
        portaUltimaAnim = false;
        StartCoroutine(ataqueloop());
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        vidaMask1 = DanoBoss1.currentHealth;
        vidaMask2 = DanoBoss2.currentHealth2;
        vidaGeral = vidaMask1 + vidaMask2;
        VidaGeralBoss = vidaGeral;
        if (verifica) 
        {
            //testeAtk();

        }
        // if (Input.GetKeyDown(KeyCode.U)) 
        //{
        //    testeAtk();
        //}

        if (vidaGeral<=0) 
        {

            cutscenefinal();

            portaUltimaAnim = true;
        }

        transform.Translate(UnityEngine.Vector2.left * speed * Time.deltaTime);
        if (vidaMask1 <=0) 
        {
            anim.SetTrigger("morreuCima"); 
        }
        if (vidaMask2 <= 0)
        {
            anim.SetTrigger("morreuBaixo");
        }
        if (DanoBoss1.hitAnim ==1 && vidaMask1 >0) 
        {
            anim.SetTrigger("hit");
            DanoBoss1.hitAnim = 0;
        }
        if (DanoBoss2.hitAnim2 ==1 && vidaMask2 >0) 
        {
            anim.SetTrigger("hit");
            DanoBoss2.hitAnim2 = 0;
        }
    }

    void testeAtk() 
    {
        Collider2D[] hitpoint1 = Physics2D.OverlapBoxAll(atkPoint1.position, (new Vector2(rangeAtk, rangeAtk2)),0, maskPlayer);
        Collider2D[] hitpoint2 = Physics2D.OverlapBoxAll(atkPoint2.position, (new Vector2(rangeAtk, rangeAtk2)),0, maskPlayer);

        foreach (Collider2D jogador in hitpoint1) 
        {
            if (vidaMask2 >0) 
            {
                atkcima = atkcima+1;
                atkbaixo = 0;
                Debug.Log("Hitpoint1 " + jogador.name);
                anim.SetTrigger("AtkCima");
                AtkCima();
            }

            
        }
        foreach (Collider2D jogador2 in hitpoint2)
        {
            if (vidaMask1>0) 
            {
                atkbaixo = atkbaixo+1;
                atkcima = 0;
                AtkBaixo();
                Debug.Log("Hitpoint2 " + jogador2.name);
                anim.SetTrigger("AtkBaixo");
                //Debug.Log("Hitpoint2 " + jogador2.name);
                //jogador2.attachedRigidbody.AddForce(new Vector2(jogador2.transform.position.x * -250, jogador2.transform.position.y), ForceMode2D.Force);
            }

        }
        if (atkcima <3 && atkbaixo <3) 
        {
            if (vidaMask1 > 0 && vidaMask2 > 0)
            {
                StartCoroutine(ataqueloop());
            }
            if (vidaMask1 <= 0 || vidaMask2 <= 0)
            {
                StartCoroutine(ataqueloop2());
                //
            }
        }

        if (atkcima>=3 || atkbaixo>=3) 
        {
            Debug.Log("modulo3");
            StartCoroutine(TpAtck3());
            atkbaixo = 0;
            atkcima = 0;

        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireCube(atkPoint1.position, (new Vector2(rangeAtk, rangeAtk2)));
        Gizmos.DrawWireCube(atkPoint2.position, (new Vector2(rangeAtk, rangeAtk2)));
    }

    IEnumerator tempoVerificador() 
    {
        yield return new WaitForSeconds(1f);
        verifica = true;
        yield return new WaitForSeconds(0.01f);
        verifica = false;


    }

    void AtkCima() 
    {
        StartCoroutine(Tempodeespera());
        StartCoroutine(TempoDeATK());
    }
    void AtkBaixo() 
    {
        StartCoroutine(Tempodeespera());
        StartCoroutine(TempoDeATK());

    }
    IEnumerator TempoDeATK() 
    {
        yield return new WaitForSeconds(3f);
        speed = 0;
        yield return new WaitForSeconds(0.18f); 
        flip();
    }
    IEnumerator Tempodeespera() 
    {
        yield return new WaitForSeconds(0.88f);
        speed = 10; 
    }
    void flip()
    {
        transform.Rotate(0f, 180, 0);
    }
    IEnumerator ataqueloop() 
    {
        yield return new WaitForSeconds(6f);
        testeAtk();
    }
    IEnumerator ataqueloop2()
    {
        yield return new WaitForSeconds(4f);
        testeAtk();
    }
    IEnumerator TpAtck3() 
    {
        yield return new WaitForSeconds(10f);
        testeAtk();
    }
    IEnumerator bosAnnimTime() 
    {
        yield return new WaitForSeconds(4);
        StartCoroutine(ataqueloop());
    }

    public void cutscenefinal ()
    {
        StartCoroutine(cutfinal());
    }

    IEnumerator cutfinal()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("CenaFinal");

    }
}
