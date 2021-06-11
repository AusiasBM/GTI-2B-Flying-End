using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionBoostVida : MonoBehaviour
{

    ControlSalud controlSalud;

    void Start()
    {
        controlSalud = ControlSalud.Instance;
    }


    private void OnCollisionEnter(Collision collision)
    {
        controlSalud.ganarVida(2);
        gameObject.SetActive(false);
    }

}
