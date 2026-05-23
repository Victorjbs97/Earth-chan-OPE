using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossAudioControle : MonoBehaviour
{
    // Start is called before the first frame update
    audioManager somboss;
    public AudioClip[] hits;
    public AudioClip atkcima, atkbaixo, morteboss;
    public GameObject themaTelaDestroi, somparede;

    void Start()
    {
        somboss = GetComponent<audioManager>();
    }

    public void atacandoEmCima ()
    {
        somboss.PlayAudio(atkcima, 0.7f);
    }

    public void atacandoEmBaixo()
    {
        somboss.PlayAudio(atkbaixo, 0.7f);
    }
    public void SomBossMorreu() 
    {
        somboss.PlayAudio(morteboss,0.5f);
    }
    public void BossTomouHit() 
    {
        somboss.PlayAudio(hits[UnityEngine.Random.Range(0, hits.Length)], 0.5f);
    }
    public void temadatela() 
    {
        Destroy(themaTelaDestroi);
        Destroy(somparede);
    }
}
