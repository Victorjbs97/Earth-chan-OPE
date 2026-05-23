using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vilaoVisao : MonoBehaviour
{

    public float raioVisao, raioAtaque, speed,fov;
    public LayerMask layerinimigo;

    [SerializeField]
    private GameObject mc;

    [SerializeField]
    private Vector3 posInicio;

    [SerializeField]
    private Rigidbody2D rb2D;

    [SerializeField]
    private Vector3 alvo;

    private bool liberaR = false;

    //public Animator vilaoanim;
    Vector3 dir;


    public Vector3 DirFAngulo(float anDeg) 
    {
        anDeg -= transform.eulerAngles.z;
        return new Vector3(Mathf.Sin(anDeg * Mathf.Deg2Rad), Mathf.Cos(anDeg * Mathf.Deg2Rad),0);
    }

    void Start()
    {
        mc = GameObject.FindWithTag("Player");
        posInicio = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
        alvo = posInicio;

    }

    private void Update()
    {
       /* if(dir.x !=0 && dir.y != 0)
        {
            vilaoanim.SetFloat("X", dir.x);
            vilaoanim.SetFloat("Y", dir.y);

        }*/
    }


    void FixedUpdate()
    {
        if ((Vector2.Angle(mc.transform.position - transform.position, -transform.up)) <= fov * 0.5f)
        {
            RaioMC();
        }
        else 
        {
            Voltar();
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raioVisao);
        Gizmos.DrawWireSphere(transform.position, raioAtaque);
    }

    void RaioMC() 
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            mc.transform.position - transform.position, raioVisao, layerinimigo);
        Vector3 temp = mc.transform.position - transform.position;
        Debug.DrawRay(transform.position, temp, Color.red);


        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "espadaHeroi" )
            {
                alvo = mc.transform.position;
                liberaR = true;
            } 

            else
            {
                alvo = posInicio;
            }
        }
        else 
        {
            alvo = posInicio;
            liberaR = false;
        }

        float disTemp = Vector3.Distance(alvo, transform.position);
        dir = (alvo - transform.position).normalized;

        if (alvo != posInicio && disTemp < raioAtaque)
        {
            //vilaoanim.SetBool("ataque", true);
            
        }
        else
        {
            rb2D.MovePosition(transform.position + dir * speed * Time.deltaTime);
            //vilaoanim.SetBool("ataque", false);
        }

        Debug.DrawLine(transform.position, alvo, Color.green);

        if (liberaR)
        {
            transform.up = (mc.transform.position - transform.position) * -1;
            if (disTemp > raioAtaque)
            {
                rb2D.MovePosition(transform.position + dir * speed * Time.deltaTime);
            }
        }
        else 
        {
            transform.up = (posInicio - transform.position) * -1;
        }
    }


    void Voltar() 
    {
        dir = (alvo - transform.position).normalized;
        float disTemp = Vector3.Distance(alvo, transform.position);
        if (alvo == posInicio && disTemp < 0.02f) 
        {
            transform.position = posInicio;
            //vilaoanim.SetFloat("X", 0);
            //vilaoanim.SetFloat("Y", 0);
            transform.up = Vector3.zero;


        }
        if (transform.position != posInicio)
        {
            rb2D.MovePosition(transform.position + dir * speed * Time.deltaTime);
        }

        
    }



}
