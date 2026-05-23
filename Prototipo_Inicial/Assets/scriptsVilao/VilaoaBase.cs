using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class InfosBaseVilao 
{
    [HideInInspector]
    public Vector3 posInicio, alvo, dir;
    public float raioVisao, raioAtaque, speed, fov;
    public LayerMask layerinimigo;
    public GameObject mc;
    public Rigidbody2D rb2D;
    public bool liberaR = false;
    public Animator vilaoanim;

    public Rigidbody2D bala;



    




}

public enum TipoVilao
{
    Canudo = 0,
    Sacola = 1
}

public abstract class VilaoaBase : MonoBehaviour
{
    public InfosBaseVilao infvb;
    public TipoVilao tvilao;

    [SerializeField]
     WaitForSeconds tempo = new WaitForSeconds(1.33f);
    private bool ataque;

    IEnumerator Tiros() 
    {
        ataque = true;
        Instantiate(infvb.bala, transform.position, Quaternion.identity);
        yield return tempo;
        ataque = false;
    }


    protected virtual void MostraBarvilao() 
    {
    }



    public virtual void Start()
    {
        infvb.mc = GameObject.FindWithTag("Player");
        infvb.posInicio = transform.position;
        infvb.rb2D = GetComponent<Rigidbody2D>();
        infvb.alvo = infvb.posInicio;

        
    }
    public virtual void Update() 
    {
        /*if (infvb.dir.x != 0 || infvb.dir.y !=0) 
        {
            infvb.vilaoanim.SetFloat("X", infvb.dir.x);
            infvb.vilaoanim.SetFloat("Y", infvb.dir.y);
        }*/
    }



    private Vector3 DirFAngulo(float anDeg)
    {
        anDeg -= transform.eulerAngles.z;
        return new Vector3(Mathf.Sin(anDeg * Mathf.Deg2Rad), Mathf.Cos(anDeg * Mathf.Deg2Rad), 0);
    }


    protected void RaioMC()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,
            infvb.mc.transform.position - transform.position, infvb.raioVisao, infvb.layerinimigo);
        Vector3 temp = infvb.mc.transform.position - transform.position;
        Debug.DrawRay(transform.position, temp, Color.red);


        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player" || hit.collider.tag == "espadaHeroi" || hit.collider.tag == "inimigo")
            {
                infvb.alvo = infvb.mc.transform.position;
                infvb.liberaR = true;
            }

            else
            {
                infvb.alvo = infvb.posInicio;
            }
        }
        else
        {
            infvb.alvo = infvb.posInicio;
            infvb.liberaR = false;
        }

        float disTemp = Vector3.Distance(infvb.alvo, transform.position);
        infvb.dir = (infvb.alvo - transform.position).normalized;

        if (infvb.alvo != infvb.posInicio && disTemp < infvb.raioAtaque)
        {
            if (!ataque) 
            {
                StartCoroutine("Tiros");
            }

        }
        else
        {
            infvb.rb2D.MovePosition(transform.position + infvb.dir * infvb.speed * Time.deltaTime);
            //vilaoanim.SetBool("ataque", false);
        }

        Debug.DrawLine(transform.position, infvb.alvo, Color.green);

        if (infvb.liberaR)
        {
            transform.up = (infvb.mc.transform.position - transform.position) * -1;
            if (disTemp > infvb.raioAtaque)
            {
                infvb.rb2D.MovePosition(transform.position + infvb.dir * infvb.speed * Time.deltaTime);
            }
        }
        else
        {
            transform.up = (infvb.posInicio - transform.position) * -1;
        }
    }


    protected void Voltar()
    {
        infvb.dir = (infvb.alvo - transform.position).normalized;
        float distanciaTemp = Vector3.Distance(infvb.alvo, transform.position);
        if (infvb.alvo == infvb.posInicio && distanciaTemp < 0.2f)
        {
            transform.position = infvb.posInicio;
            //vilaoanim.SetFloat("X", 0);
            //vilaoanim.SetFloat("Y", 0);
            transform.up = Vector3.zero;


        }
        if (transform.position != infvb.posInicio)
        {
            infvb.rb2D.MovePosition(transform.position + infvb.dir * infvb.speed * Time.deltaTime);
        }
        else
        {
            infvb.dir.x = 0;
            infvb.dir.y = 0;
        }
    }


}
