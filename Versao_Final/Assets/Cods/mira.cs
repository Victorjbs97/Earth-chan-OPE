using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mira : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D curosrSprite;

    void Start()
    {
        //Cursor.visible = false;
        Cursor.SetCursor(curosrSprite,Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
