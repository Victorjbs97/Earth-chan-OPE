using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class playermov : MonoBehaviour
{
	// Start is called before the first frame update

	public float Velocidade; // variavel da velociadade do mc.

	public Rigidbody2D playerRB;  // RigidBody do player
	private Vector2 movimento; // serve para guardar a a posição do player e mover.

	public Animator anim; // animator do player

	public float vidaPlayer = 250; // vida do player

	private Vector2 direcaoDoPlayer; // para fazer o KnockBack 

	private SpriteRenderer playerR;
	private bool corred = false;

	public CircleCollider2D areaAtaque ;
	private bool ataqueverifica;
	public float dash = 60;
	public bool dashVerifica;
	public bool dashCoolDown;

	void Start()
	{
		dashVerifica = false;
		dashCoolDown = true;
		AtaqueEnab();
		movimento = Vector2.zero;
		playerRB = GetComponent<Rigidbody2D>();
		playerR = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{
		MovPersonagem();
		if (movimento.x != 0 || movimento.y != 0 )
		{
			AnimMc(movimento);
		}
		else
		{
			anim.SetLayerWeight(1, 0);
		}

		if (corred == true)
		{
			playerR.color = Color.Lerp(Color.white, Color.red, Mathf.PingPong(8 * Time.time, 0.5f));
			
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			anim.SetTrigger("ataque");
			areaAtaque.enabled = true;
			ataqueverifica = true;
			StartCoroutine(ataqueliberar());
		}

		if (Input.GetKeyDown(KeyCode.LeftShift) && dashCoolDown == true) 
		{
			StartCoroutine(dashIE());
		}
	}

	private void FixedUpdate()
	{
		playerRB.MovePosition(playerRB.position + movimento * Velocidade * Time.deltaTime);
		if (barravida.vidaPlayer <= 0)
		{
			PlayerDeath();
		}

		if (movimento != Vector2.zero)
		{
			areaAtaque.offset = new Vector2(movimento.x / 2, movimento.y / 2);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("inimigo") && ataqueverifica == false && dashVerifica == false)
		{
			StartCoroutine(LentidaoDano(0.5f, 1f));
			DanoCor();
			DanoMC();
		}
	}

	void PlayerDeath()
	{
		MenuScript.Telamorte();
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		
	}


	public IEnumerator KnockBack(float duracao, float poder, Vector2 direcao)
	{
		float tempo = 0;

		playerRB.velocity = Vector2.zero;		
		while (duracao > tempo)
		{
			tempo += Time.deltaTime;
			playerRB.AddForce(new Vector2(direcao.x * -poder, direcao.y * -poder), ForceMode2D.Force);
			yield return null;
		}

		yield return 0;
	}

	void MovPersonagem()
	{
		movimento = Vector2.zero;

		if (Input.GetKey(KeyCode.W))
		{
			movimento += Vector2.up;
			direcaoDoPlayer = movimento;
		}
		if (Input.GetKey(KeyCode.S))
		{
			movimento += Vector2.down;
			direcaoDoPlayer = movimento;
		}
		if (Input.GetKey(KeyCode.A))
		{
			movimento += Vector2.left;
			direcaoDoPlayer = movimento;
		}
		if (Input.GetKey(KeyCode.D))
		{
			movimento += Vector2.right;
			direcaoDoPlayer = movimento;
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
		playerR.color = new Color(1, 1, 1, 1);
	}

	public void AnimMc(Vector2 dir)
	{
		anim.SetLayerWeight(1,1);
		anim.SetFloat("X", dir.x);
		anim.SetFloat("Y", dir.y);
	}

	public void DanoMC()
	{
		barravida.vidaPlayer -= (DestroiInimigo.danoNoPlayer - BuffDefesa.maisDef)/4;
		barravida.vidaPlayer -= (movebalaV.danoNoPlayer - BuffDefesa.maisDef)/4;
		vidaPlayer -= (DestroiInimigo.danoNoPlayer - BuffDefesa.maisDef)/4;
		vidaPlayer -= (movebalaV.danoNoPlayer - BuffDefesa.maisDef)/4;
	}

	public void AtaqueEnab()
	{
		areaAtaque.enabled = false;
		ataqueverifica = false;
	}

	IEnumerator ataqueliberar()
	{
		yield return new WaitForSeconds(0.25f);
		areaAtaque.enabled = false;
		ataqueverifica = false;
	}

	IEnumerator dashIE() 
	{
		Velocidade = 12f;
		dashVerifica = true;
		dashCoolDown = false;
	
		yield return new WaitForSeconds(0.2f);

		Velocidade = 2f;
		dashVerifica = false;

		yield return new WaitForSeconds(1.5f);
		dashCoolDown = true;
	}
	public IEnumerator LentidaoDano(float duracao, float velocidadeReduzida)
	{
		float velociadadePadrao = 2f;

		Velocidade = velocidadeReduzida;

		yield return new WaitForSeconds(duracao);

		if(dashVerifica == false)
		{
			Velocidade = velociadadePadrao;
		}
	}
}

