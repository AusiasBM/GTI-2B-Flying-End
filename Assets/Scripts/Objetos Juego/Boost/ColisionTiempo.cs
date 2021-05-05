using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionTiempo : MonoBehaviour
{

    /*public Image UIImageBoost;
    public Image UIImageBoostVida;*/

    RalentizadorVelocidad ralentizador;

    // Start is called before the first frame update
    void Start()
    {
        ralentizador = RalentizadorVelocidad.Instance;

        /*UIImageBoost = GameObject.Find("ImgBoost").GetComponent<Image>();
        UIImageBoostVida = GameObject.Find("barraVidaBoost").GetComponent<Image>();*/
    }
    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        ralentizador.ralentizarObjetos(true);
        StartCoroutine(delayTiempo(10));
        Destroy(gameObject);
    }

    IEnumerator delayTiempo(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ralentizador.ralentizarObjetos(false);
    }
}
