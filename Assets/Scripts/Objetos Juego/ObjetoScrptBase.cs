using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjetoBase", menuName = "Objeto", order = 1)]
public class ObjetoScrptBase : ScriptableObject
{

    //Velocidad de desplazamiento
    public float velocidad = 0f;

    //Coordenada (X o Y segun su tipo de movimiento) a la que se destruir?
    public float destruir = 0f;

    //Direcci?n del objeto
    public bool isVertical = false;
    public bool moveUpToDown = false;
    public bool moveLeftToRight = false;

    //Tipo de objeto
    public Tipo tipoObjeto;

    //En caso de crear un nuevo tipo de objeto, a?adir al enum
    public enum Tipo
    {
        PiezaAvion,
        Pajaro,
        Moneda,
        Diamante,
        BoostInmunidad,
        BoostIman,
        BoostTiempo,
        BoostVida,
        RocaVolcanica
    }
}