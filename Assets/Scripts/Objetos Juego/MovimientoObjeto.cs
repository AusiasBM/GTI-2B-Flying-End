using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Define en que eje y a que velocidad se mueven los diferentes tipos de objetos a partir 
 * de unos parámetros definidos de cada objeto de la clase ObjetoScrptBase
 */
public class MovimientoObjeto : MonoBehaviour
{
    public ObjetoScrptBase objetoBase;

    RalentizadorVelocidad ralentizador;

    // Start is called before the first frame update
    void Start()
    {
        ralentizador = RalentizadorVelocidad.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (objetoBase.isVertical)
        {
            movimientoVertical(objetoBase.moveUpToDown, objetoBase.velocidad, objetoBase.destruir);
        }
        else
        {
            movimientoHorizontal(objetoBase.moveLeftToRight, objetoBase.velocidad, objetoBase.destruir);
        }
    }

    //Describir el movimiento horizontal de determinados objetos (pajaros)
    private void movimientoHorizontal(bool isLeftToRight, float velocidad, float destruir)
    {
        if (isLeftToRight)
        {
            if (ralentizador.ralentizar && (objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.PiezaAvion || objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.Pajaro))
            {
                transform.position += transform.right * ralentizador.velocidadRalentizada * Time.deltaTime;
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
            if (ralentizador.ralentizar && (objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.PiezaAvion || objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.Pajaro))
            {
                transform.position -= transform.right * ralentizador.velocidadRalentizada * Time.deltaTime;
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

    //Describir el movimiento de tipo vertical para determinados objetos (piezas avión, monedas...)
    private void movimientoVertical(bool isUpToDown, float velocidad, float destruir)
    {
        if (isUpToDown)
        {
            if (ralentizador.ralentizar && (objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.PiezaAvion || objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.Pajaro))
            {
                transform.position -= transform.up * ralentizador.velocidadRalentizada * Time.deltaTime;
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
            if (ralentizador.ralentizar && (objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.PiezaAvion || objetoBase.tipoObjeto == ObjetoScrptBase.Tipo.Pajaro))
            {
                transform.position += transform.up * ralentizador.velocidadRalentizada * Time.deltaTime;
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
