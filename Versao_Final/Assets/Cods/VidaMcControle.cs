using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaMcControle : MonoBehaviour
{
    private SpriteRenderer spritePlayer;
    private bool cordeDano;
    public int vidaMc = 100;
    Animator anima;
    public AudioClip sfxmorreu;
    public AudioClip[] hittomou;
    private audioManager audioman;
    public GameObject SomAudio;
    


    private bool semDano, controle;
    void Start()
    {
        controle = false;
        anima = gameObject.GetComponent<Animator>();
        spritePlayer = GetComponent<SpriteRenderer>();
        audioman = GetComponent<audioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cordeDano == true)
        {
            spritePlayer.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(9 * Time.time, 0.3f));
        }
        if (vidaMc <=0 && !controle) 
        {
            Destroy(SomAudio);
            controle = true;
            playermov2.pausar = true;
            anima.SetTrigger("morteAnim");
            audioman.PlayAudio(sfxmorreu,1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DanoCor();
            audioman.PlayAudio(hittomou[UnityEngine.Random.Range(0, hittomou.Length)], 0.5f);
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            DanoCor();
        }
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
        spritePlayer.color = new Color(1, 1, 1, 1);
    }
    public void TakeDamagePlayer(int damage)
    {
        vidaMc -= damage;
    }

}
