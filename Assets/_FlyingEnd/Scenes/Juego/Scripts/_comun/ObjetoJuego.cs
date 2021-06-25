using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Clase para crear todo tipo de objetos a partir de unos parámetros
 */
public class ObjetoJuego : MonoBehaviour
{
    public float velocidad = 0f;
    public float destruir = 0f;

    //Para efecto de ralentizar tiempo (boost)
    public bool ralentizar = false;
    public float velocidadRanetizado = 0f;

    //Dirección del objeto
    public bool isVertical = false;
    public bool moveUpToDown = false;
    public bool moveLeftToRight = false;

    //Tipo de objeto
    public Tipo tipoObjeto;

    //En caso de crear un nuevo tipo de objeto, añadir al enum
    public enum Tipo
    {
        PiezaAvion,
        Pajaro,
        Moneda,
        Diamante,
        BoostInmunidad,
        BoostIman,
        BoostTiempo
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (isVertical)
        {
            movimientoVertical(ralentizar, moveUpToDown);
        }
        else
        {
            movimientoHorizontal(ralentizar, moveLeftToRight);
        }
    }

    private void movimientoHorizontal(bool ralentizado, bool isLeftToRigth)
    {
        if (isLeftToRigth)
        {
            if (ralentizado)
            {
                transform.position += transform.right * velocidadRanetizado * Time.deltaTime;
            }
            else
            {
                // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
                transform.position += transform.right * velocidad * Time.deltaTime;
            }

            if (transform.position.x > destruir)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (ralentizado)
            {
                transform.position -= transform.right * velocidadRanetizado * Time.deltaTime;
            }
            else
            {
                // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
                transform.position -= transform.right * velocidad * Time.deltaTime;
            }

            if (transform.position.x < destruir)
            {
                Destroy(gameObject);
            }
        }
    }

    private void movimientoVertical(bool ralentizado, bool isUpToDown)
    {
        if (isUpToDown)
        {
            if (ralentizado)
            {
                transform.position -= transform.up * velocidadRanetizado * Time.deltaTime;
            }
            else
            {
                // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
                transform.position -= transform.up * velocidad * Time.deltaTime;
            }

            if (transform.position.y < destruir)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (ralentizado)
            {
                transform.position += transform.up * velocidadRanetizado * Time.deltaTime;
            }
            else
            {
                // En menos(-=) desplazamiento hacia abajo; en mas (+=) hacia arriba
                transform.position += transform.up * velocidad * Time.deltaTime;
            }

            if (transform.position.y > destruir)
            {
                Destroy(gameObject);
            }
        }
    }

}
