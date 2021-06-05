using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionTiempo : MonoBehaviour
{

    /*public Image UIImageBoost;
    public Image UIImageBoostVida;*/

    RalentizadorVelocidad ralentizador;

    public GameObject estructuraBarraVidaBoost;
    public GameObject barraVidaBoost;
    public GameObject imgBoost;
    public Sprite[] imagenesBoost;

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

    public IEnumerator delayTiempo(int seconds)
    {

        estructuraBarraVidaBoost.GetComponent<Image>().enabled = true;
        barraVidaBoost.GetComponent<Image>().enabled = true;
        imgBoost.GetComponent<Image>().sprite = imagenesBoost[1];
        float fragmentado = 1 / seconds;

        for (float i = seconds; i >= 0; i = i - fragmentado)
        {
            yield return new WaitForSeconds(fragmentado);
            barraVidaBoost.GetComponent<Image>().fillAmount = i;
        }

        estructuraBarraVidaBoost.GetComponent<Image>().enabled = false;
        barraVidaBoost.GetComponent<Image>().enabled = false;
        imgBoost.GetComponent<Image>().sprite = imagenesBoost[0];

        ralentizador.ralentizarObjetos(false);
    }

}
