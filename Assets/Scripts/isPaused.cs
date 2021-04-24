using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isPaused : MonoBehaviour
{
    // Start is called before the first frame update
    bool pausado = false;
    public void pausedGame() {
        if (pausado)
        {
            Time.timeScale = 1;
            pausado = false;

        }
        else
        {
            Time.timeScale = 0;
            pausado = true;
        }
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
