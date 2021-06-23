using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstSoleado : EstadoFSM
{
    //Contador del estado
    float contador;

    protected override void Awake()
    {
        base.Awake();
        Nombre = "Soleado";
        maquina.nombreEstados.Add(Nombre);
    }

    protected override void OnEnable()
    {
        if (Inicial)
        {
            maquina.estaFondo1 = true;
        }
        else
        {
            StartCoroutine(maquina.efectos.cambiarParametros(100f, 5f, 0f));
        }

        enableDisableObjectsSoleado();
        maquina.nombreEstadoActual = Nombre;

        

        contador = 0f;
    }

    protected override void OnDisable()
    { 
        Inicial = false;
        maquina.transicionFondo = false;
    }

    // Update is called once per frame
    void Update()
    {
        contador += maquina.Velocidad * Time.deltaTime;

        // Contador de metros 
        maquina.gameController.ScoreMetros += maquina.Velocidad * Time.deltaTime;

        maquina.cambiarFondos(contador, maquina.listSpritesFondos[0], maquina.listSpritesFondos[0], "Niebla");
        if (contador > 130f)
        {
            maquina.CarrilDown.GetComponent<CrearNiebla>().activo = true;
            maquina.CarrilDown.GetComponent<CrearNiebla>().enabled = true;
        }
    }

    void enableDisableObjectsSoleado()
    {
        //Piezas
        maquina.CarrilUp.GetComponent<CrearPiezas>().activo = true;
        maquina.CarrilUp.GetComponent<CrearPiezas>().enabled = true;
        //pajaros
        maquina.CarrilIzda1.GetComponent<CrearPajaros>().activo = true;
        maquina.CarrilIzda1.GetComponent<CrearPajaros>().enabled = true;
        maquina.CarrilDrcha1.GetComponent<CrearPajaros>().activo = true;
        maquina.CarrilDrcha1.GetComponent<CrearPajaros>().enabled = true;
        //Nubes
        maquina.CarrilDown.GetComponent<CrearNubes>().activo = true;
        maquina.CarrilDown.GetComponent<CrearNubes>().enabled = true;
        //Nubes fondo
        maquina.CarrilDown.GetComponent<CrearNubesFondo>().activo = true;
        maquina.CarrilDown.GetComponent<CrearNubesFondo>().enabled = true;
        //Nubes Electricas
        maquina.CarrilDown.GetComponent<CrerNubeElectrica>().activo = false;
        maquina.CarrilDown.GetComponent<CrerNubeElectrica>().enabled = false;
        //Lluvia
        maquina.CarrilUp.GetComponent<CrearLluvia>().activo = false;
        maquina.CarrilUp.GetComponent<CrearLluvia>().enabled = false;
        //Niebla
        maquina.CarrilDown.GetComponent<CrearNiebla>().activo = false;
        maquina.CarrilDown.GetComponent<CrearNiebla>().enabled = false;
        //Rocas
        maquina.CarrilDown.GetComponent<CrearRocas>().activo = false;
        maquina.CarrilDown.GetComponent<CrearRocas>().enabled = false;
    }

}
