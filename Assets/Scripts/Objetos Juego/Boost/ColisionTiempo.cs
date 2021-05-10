using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColisionTiempo : MonoBehaviour
{

    /*public Image UIImageBoost;
    public Image UIImageBoostVida;*/

    RalentizadorVelocidad ralentizador;

    public GameObject barraVidaBoost;
    public GameObject imgBoost;

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

        //imgBoost.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Hud/imgBoost/reloj");
        int nombreVidaBoost = 5;
        for (int i = 0; i <= seconds; i = i + 2)
        {
            //barraVidaBoost.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Hud/VidaBoost/boost" + nombreVidaBoost);
            yield return new WaitForSeconds(seconds / 5);
            nombreVidaBoost--;
        }

        //barraVidaBoost.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/base");
        //imgBoost.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/base");
        ralentizador.ralentizarObjetos(false);
    }

}
