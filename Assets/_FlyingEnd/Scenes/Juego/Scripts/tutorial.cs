using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tutorial : MonoBehaviour
{
    private float tiempo = 5f;
    public Image Image;

    // Update is called once per frame
    void Update()
    {
        tiempo -= Time.deltaTime;

        if(tiempo <= 0)
        {
            Image.enabled = false;
        }
    }


}
