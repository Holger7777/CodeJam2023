using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=mYmgBRdWPr4&ab_channel=Rs_Comp

public class Popup : MonoBehaviour
{
    public Canvas canvas;

    private void Start()
    {
        // Hide the popup panel on start
        canvas.enabled = false;
    }

    public void popup()
    {
        if (canvas.enabled == false)
        {
            
            canvas.enabled = true;
        }else if (canvas.enabled == true)
        {
           
            canvas.enabled = false;
        }
    }
}
