using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int moeda;
    public int vidaPlayer;
    int dashsUi;
    playermov2 pm2;
    VidaMcControle conDeVida;
    public Image DashBar;
    public Image barraDeVida;
    public Image imgboladefogo;
    public float UIBoladeFogo, segundoveficador;
    public Text md;
    private int coins,necessario, moedasQuantidade;
    void Awake()
    {
    }
    void Start()
    {
        GameObject Player = GameObject.FindWithTag("Player");
        conDeVida = Player.GetComponent<VidaMcControle>();
        pm2 = Player.GetComponent<playermov2>();
        transicaoMorteScript.vmorte = false;
        necessario = portaCod.necessario;
        moedasQuantidade = 0;

    }
    
    // Update is called once per frame
    void Update()
    {
        moedasQuantidade = necessario - coins;
        coins = playermov2.moedaUI;
        if (moedasQuantidade <=0)
        {
            moedasQuantidade = 0;
        }
        if (playermov2.atkfogoverifica) 
        {
            UIBoladeFogo = 3.4f;
            segundoveficador = 0;
        }
        if (!playermov2.atkfogoverifica) 
        {
            if (segundoveficador == 0) 
            {
                segundoveficador += Time.deltaTime;
                UIBoladeFogo = 0;
            }

            UIBoladeFogo += Time.deltaTime;
        }
        imgboladefogo.fillAmount = (float)UIBoladeFogo / 3.4f;
        md.text = moedasQuantidade.ToString();
    }
    private void FixedUpdate()
    {
        vidaPlayer = conDeVida.vidaMc;
        dashsUi = pm2.dashsDados;
        MostrarDashBarra();
        VidaBarra();
        if (vidaPlayer <= 0) 
        {
            transicaoMorteScript.vmorte = true;
            StartCoroutine(tempodeload());
        }

    }

    public void MostrarDashBarra() 
    {
        DashBar.fillAmount = (float)dashsUi/3;
    }
    public void VidaBarra() 
    {
        barraDeVida.fillAmount = (float)vidaPlayer / 100;
    }
    void telaMorte()
    {
        SceneManager.LoadScene("TelaMorte");
    }
    IEnumerator tempodeload() 
    {
        yield return new WaitForSeconds(1f);
        telaMorte();
    }
}

