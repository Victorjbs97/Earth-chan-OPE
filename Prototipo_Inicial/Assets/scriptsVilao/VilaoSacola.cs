using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VilaoSacola : VilaoaBase
{
    [SerializeField]
    private CanvasGroup cGroup;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        cGroup = GetComponentInChildren<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }


    void FixedUpdate()
    {
        if ((Vector2.Angle(infvb.mc.transform.position - transform.position, -transform.up)) <= infvb.fov * 0.5f)
        {
            RaioMC();
        }
        else
        {
            Voltar();
        }
        MostraBarvilao();
    }

    protected override void MostraBarvilao()
    {
        if (Vector2.Distance(transform.position, infvb.mc.transform.position) < infvb.raioVisao && cGroup.alpha ==0)
        {
            cGroup.alpha = 0;
        }
        else if (Vector2.Distance(transform.position, infvb.mc.transform.position) > infvb.raioVisao && cGroup.alpha ==1) 
        {
            cGroup.alpha = 0;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, infvb.raioVisao);
        Gizmos.DrawWireSphere(transform.position, infvb.raioAtaque);
    }
}
