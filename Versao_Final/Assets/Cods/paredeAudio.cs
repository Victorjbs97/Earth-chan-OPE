using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paredeAudio : MonoBehaviour
{
    // Start is called before the first frame update
    audioManager audiotema;
    public AudioClip musicatela;
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
        audiotema.PlayAudio(musicatela, 1f);

    }
    IEnumerator tempDelay()
    {
        yield return new WaitForSeconds(3.5f);
        telamusica();
    }
}
