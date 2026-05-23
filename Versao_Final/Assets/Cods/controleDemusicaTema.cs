using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controleDemusicaTema : MonoBehaviour
{
    // Start is called before the first frame update
    audioManager audiotema;
    public AudioClip musicatela;
    public float voldomusica;
    private int verificaTela;
    void Start()
    {
        audiotema = GetComponent<audioManager>();
    }
    private void Awake()
    {
        StartCoroutine(tempDelay());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void telamusica() 
    {
        audiotema.PlayAudio(musicatela, voldomusica);
        
    }
    IEnumerator tempDelay() 
    {
        yield return new WaitForSeconds(1f);
        telamusica();
    }
    
}
