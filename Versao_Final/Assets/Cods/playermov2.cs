using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
[DefaultExecutionOrder(-10)]

public class playermov2 : MonoBehaviour
{

    private Rigidbody2D rb; // pegar o Rigidbody do Player.
    public float speed; // Velocidade do jogador
    public float forcapulo; // Velocidade do pulo
    private bool ladodomc = true; // verifica o lado do jogador
    private bool pulo = false; // para evitar double pulo
    private Animator anim; // pegar o animator do jogador
    [SerializeField]
    private bool nochao; // verificar se personagem esta no chão.
    private Transform chaocheck; // tambem verifica se ele esta no chão.
    public float dashSpeed; //Velocidade do Dash
    private float dashTime; //Tempo de execução do dash
    public float startDashTime; //Onde começa
    private int direction; //Direção, direita ou esquerda
    public bool isSwinging;
    public Vector2 ropeHook;
    public float swingForce = 4f;
    private float h; // pegar horizontal
    private float v; // pegar a Vertical
    private bool bugDeAndarCorrecao = true;
    [Header("Tempo de voltar o controle pós hook")]
    [SerializeField]
    private float tem = 1;
    private bool verificadash;
    public Transform tiStart;
    public GameObject bolaDefogoPreb;
    private bool podeAtirar = true;
    public float tempodedelay;
    public bool abrirporta;
    public int moeda;
    public static bool pausar, atkfogoverifica;
    private bool garantiaPassagem;
    public AudioClip jumpsfx;
    public AudioClip sfxBoladeFogo;    
    public AudioClip sfxdash;
    public AudioClip[] passos;
    private audioManager audimanage;
    //
    //

    [HideInInspector]public int dashsDados;
    public int dashQuant =3;

    //
    private SpriteRenderer spritePlayer;
    private bool cordeDano;

    public static bool PerderControle, chaooutro;
    public static float BolaUI;
    public static int moedaUI;

    float DoubletapTime;
    KeyCode lastKeycode;
    // // // // // /// /// //
    private float Coyote =0.1f;
    private float TimeDoCoyote;  


    void Start()
    {
        audimanage = GetComponent<audioManager>();
        Time.timeScale = 1f;
        chaocheck = gameObject.transform.Find("chaocheck");
        pausar = false;      
        garantiaPassagem = false;
        moeda = 0;
        moedaUI =0;
    } 

    void Awake()
    {
        pausar = false;
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        dashQuant = 3;
        dashsDados = dashQuant;
        dashTime = startDashTime;
        spritePlayer = GetComponent<SpriteRenderer>();
        garantiaPassagem = false;
        moeda = 0;
        moedaUI = 0;

    }

    // Update is called once per frame 
    void Update() 
    {

        PerderControle = PauseScript.GameIsPaused2;
        garantiaPassagem = transicaoScript.mudatela;
        if (garantiaPassagem)
        {
            anim.SetTrigger("passarporta");
        }

        if (PerderControle || pausar)
            {
                rb.velocity = Vector2.zero;
                PerderControle = true;
                anim.SetFloat("vel", 0);
             }
             
        if (!PerderControle) 
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            atkfogoverifica = podeAtirar;

            if (h ==0 && nochao) 
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }


            if (h > 0 && !ladodomc)
            {
                flip();
            }
            else if (h < 0 && ladodomc)
            {
                flip();
            }
            
            nochao = Physics2D.Linecast(transform.position, chaocheck.position, 1 << LayerMask.NameToLayer("Chao"));
            chaooutro = nochao;
            if (!nochao)
            {
                anim.SetBool("pouso", false);

            }
            if (nochao)
            {
                dashsDados = dashQuant;
                anim.SetBool("pouso", true);
                anim.SetFloat("vel", Mathf.Abs(h));
                TimeDoCoyote = Time.time + Coyote;
            }
            if (Input.GetButtonDown("Jump") && (nochao ||TimeDoCoyote >Time.time ) || Input.GetKeyDown(KeyCode.W) && (nochao || TimeDoCoyote > Time.time))
            {
                pulo = true;

            }

            

            if (direction == 0)
            {

                if (Input.GetKeyDown(KeyCode.LeftShift) && !isSwinging && dashsDados > 0)
                 {
                     dashsDados--;
                     if (h < 0)
                     {
                         direction = 1;
                         verificadash = true;
                         StartCoroutine(TempoVerificadash());
                         anim.SetTrigger("frenteDash"); 
                         audimanage.PlayAudio(sfxdash, 0.4f);
                     }
                     else if (h > 0)
                     {
                         direction = 2;
                         verificadash = true;
                         StartCoroutine(TempoVerificadash());
                         anim.SetTrigger("frenteDash");
                         audimanage.PlayAudio(sfxdash, 0.4f);
                     }
                     else if (v > 0)
                     {
                         direction = 3;
                         verificadash = true;
                         StartCoroutine(TempoVerificadash());
                         anim.SetTrigger("cimaDash");
                         audimanage.PlayAudio(sfxdash, 0.4f);
                     }

                 }
                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                if (Input.GetKeyDown(KeyCode.A))
                {
                    if (DoubletapTime > Time.time && lastKeycode == KeyCode.A && !isSwinging && dashsDados > 0)
                    {
                        direction = 1;
                        verificadash = true;
                        StartCoroutine(TempoVerificadash());
                        anim.SetTrigger("frenteDash");
                        audimanage.PlayAudio(sfxdash, 0.4f);
                        dashsDados--;
                    }
                    else
                    {
                        DoubletapTime = Time.time + 0.3f;
                    }
                    lastKeycode = KeyCode.A;
                }
                if (Input.GetKeyDown(KeyCode.D))
                {
                    if (DoubletapTime > Time.time && lastKeycode == KeyCode.D && !isSwinging && dashsDados > 0)
                    {
                        direction = 2;
                        verificadash = true;
                        StartCoroutine(TempoVerificadash()); 
                        anim.SetTrigger("frenteDash");
                        audimanage.PlayAudio(sfxdash, 0.4f);
                        dashsDados--;
                    }
                    else
                    {
                        DoubletapTime = Time.time + 0.3f;
                    }
                    lastKeycode = KeyCode.D;
                }
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (DoubletapTime > Time.time && lastKeycode == KeyCode.W && !isSwinging && dashsDados > 0)
                    {
                        direction = 3;
                        verificadash = true;
                        StartCoroutine(TempoVerificadash());
                        anim.SetTrigger("cimaDash");
                        audimanage.PlayAudio(sfxdash, 0.4f);
                        dashsDados--;
                    }
                    else
                    {
                        DoubletapTime = Time.time + 0.3f;
                    }
                    lastKeycode = KeyCode.W;
                }
            }
            else
            {
                if (dashTime <= 0)
                {
                    direction = 0;
                    dashTime = startDashTime;
                    rb.velocity = Vector2.zero;
                }
                else
                {
                    dashTime -= Time.deltaTime ;
                    if (direction == 1)
                    {
                        rb.velocity = Vector2.left * dashSpeed;
                    }
                    else if (direction == 2)
                    {
                        rb.velocity = Vector2.right * dashSpeed;

                    }
                    else if (direction == 3)
                    {
                        rb.velocity = Vector2.up * dashSpeed;

                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Q) && podeAtirar && !isSwinging)
            {
                podeAtirar = false;
                anim.SetTrigger("BdFogo");
                audimanage.PlayAudio(sfxBoladeFogo,0.3f); 
                StartCoroutine(shoottemp());
            }
            if (cordeDano == true)
            {
                spritePlayer.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(9 * Time.time, 0.3f));
            }
        }
    }

    private void FixedUpdate()
    {
        if (!PerderControle) 
        {
            if (h < 0f || h > 0f)
            {
                if (isSwinging)
                {
                    bugDeAndarCorrecao = false;
                    anim.SetBool("animHook", true);
                    dashsDados = dashQuant;
                    var playerToHookDirection = (ropeHook - (Vector2)transform.position).normalized;
                    Vector2 perpendicularDirection;
                    if (h < 0)
                    {
                        perpendicularDirection = new Vector2(-playerToHookDirection.y, playerToHookDirection.x);
                        var leftPerpPos = (Vector2)transform.position - perpendicularDirection * -2f;
                        Debug.DrawLine(transform.position, leftPerpPos, Color.green, 0f);
                    }
                    else
                    {
                        perpendicularDirection = new Vector2(playerToHookDirection.y, -playerToHookDirection.x);
                        var rightPerpPos = (Vector2)transform.position + perpendicularDirection * 2f;
                        Debug.DrawLine(transform.position, rightPerpPos, Color.green, 0f);
                    }
                    var force = perpendicularDirection * swingForce;
                    rb.AddForce(force, ForceMode2D.Force);
                }
                else
                {
                    if (bugDeAndarCorrecao && !verificadash || nochao && !verificadash)
                    {
                        anim.SetFloat("vel", Mathf.Abs(rb.velocity.x));
                        AppMovimento();
                    }
                }
            }
            else 
            {
                anim.SetFloat("vel", 0f);
            }
            if (!isSwinging)
            {
                anim.SetBool("animHook", false);
                anim.SetFloat("VelY", rb.velocity.y);
                //if (!nochao || TimeDoCoyote > Time.time) return;
                if (pulo)
                {
                    audimanage.PlayAudio(jumpsfx,1f);
                    rb.AddForce(new Vector2((speed * h) * speed, forcapulo));
                    pulo = false;
                }
            }

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("moeda")) 
        {
            moeda++;
            moedaUI = moeda;
        }
   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chaoPorta"))
        {
            Debug.Log("Abriu");
            abrirporta = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        abrirporta = false;
    }

    void flip()
    {
        ladodomc = !ladodomc;
        transform.Rotate(0f, 180, 0);
    }
    public void AppMovimento() 
    {
        rb.velocity = (new Vector2(speed* h,rb.velocity.y));     
    }
    public void SoPraUsarNoOutro() 
    {
        StartCoroutine(TempoVerifica());
    }
    IEnumerator TempoVerifica() 
    {
        yield return new WaitForSeconds(tem);
        bugDeAndarCorrecao = true;
    }

    IEnumerator TempoVerificadash() 
    {
        yield return new WaitForSeconds(0.3f);
        verificadash = false;
    }
    void Shoot() 
    {
        Instantiate(bolaDefogoPreb, tiStart.position, tiStart.rotation);
    }
    IEnumerator shoottemp() 
    {
        yield return new WaitForSeconds(0.4f);
        Shoot();
        yield return new WaitForSeconds(tempodedelay);
        podeAtirar = true;
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
        spritePlayer.color = new Color(1,1,1,1);
    }

    public int QDashsPUi() 
    {
        return dashsDados;
    }
    public void passossfx() 
    {
        audimanage.PlayAudio(passos[UnityEngine.Random.Range(0,passos.Length)],1);
    }
}
