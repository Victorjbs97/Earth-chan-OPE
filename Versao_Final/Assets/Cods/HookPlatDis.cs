using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPlatDis : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    public GameObject platformHook;
    private float playerDistance;
    private Animator platAnim;
    public AudioClip somabrir;
    private audioManager audioMan;
    [SerializeField]
    private bool tatocando =true;
    private bool isFrist = true;
    void Awake()
    {
        audioMan = GetComponent<audioManager>();
        player = GameObject.FindWithTag("Player");
        platAnim = gameObject.GetComponent<Animator>();
        StartCoroutine("primeira");

    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector2.Distance(platformHook.transform.position, player.transform.position);
    }

    private void FixedUpdate()
    {
        if (playerDistance <= 5)
        {
            platAnim.SetBool("areahook", true);
            if (!tatocando && !isFrist)
            {
                audioMan.PlayAudio(somabrir,1);
                tatocando = true;
            }


        }
        else 
        {

            platAnim.SetBool("areahook", false);
            tatocando = false;
        }


    }

    IEnumerator primeira() 
    {
        yield return new WaitForSeconds(0.5f);
        isFrist = false;
    }




}
