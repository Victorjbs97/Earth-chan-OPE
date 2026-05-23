using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ajusteOrdem : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ajustePos;
    [SerializeField]
    private SpriteRenderer mc;
    void Start()
    {
        mc = GetComponent<SpriteRenderer>();
        mc.sortingLayerName = "ajustePosY";
        mc.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ajustePos) 
        {
            mc.sortingOrder = Mathf.RoundToInt(-transform.position.y * 100);

        }
        
    }
}
