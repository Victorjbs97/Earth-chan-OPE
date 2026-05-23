using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

[DefaultExecutionOrder(-50)]
public class portaCod : MonoBehaviour
{
    playermov2 abir;
    public bool VerificaAbrir;
    public int moedap;
    public int moedaNec;
    public static int necessario;
    private Animator anim;
    private audioManager audiosom;
    public AudioClip somdaporta;
    public GameObject destoisomfase;
    public bool meuverificador;
    // Start is called before the first frame update
    void Start()
    {
        meuverificador = false;
        transicaoScript.mudatela = false;
        GameObject Player = GameObject.FindWithTag("Player");
        abir = Player.GetComponent<playermov2>();
        anim = gameObject.GetComponent<Animator>();
        audiosom = GetComponent<audioManager>();
        necessario = moedaNec;

    }
    private void Awake()
    {
        transicaoScript.mudatela = false;
        meuverificador = false;
    }

    // Update is called once per frame
    void Update()
    {
        VerificaAbrir = abir.abrirporta;
        moedap = abir.moeda;
        if (VerificaAbrir && moedap >=moedaNec && !meuverificador) 
        {
            meuverificador = true;
            playermov2.pausar = true;
            anim.SetTrigger("abrir");
            mudarATela();
            Destroy(destoisomfase);
        }
    }

    void mudarATela() 
    {
        transicaoScript.mudatela = true;
        StartCoroutine(tempespera());
    }

    public void machaAudioPorta() 
    {
        audiosom.PlayAudio(somdaporta, 0.3f);
    }
    IEnumerator tempespera() 
    {
        yield return new WaitForSeconds(1.5f);
        transicaoScript.mudatela = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
