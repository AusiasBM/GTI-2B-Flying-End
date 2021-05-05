using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Colision : MonoBehaviour
{
    public int puntuacion = 20;
    public int puntuacionDiamante = 1;

    public GameObject particulasMoneda;
    public GameObject particulasDiamante;
    public GameObject particulasAvion;
    public GameObject particulasPajaro;
    public Image UIImageBoost;
    public Image UIImageBoostVida;

    public float fuerzaImpactoPajaro = 3f;
    public float fuerzaImpactoPieza = 2f;

    

    

    private TiemblaCamara tiemblaCamara;
    

    Rigidbody rb;
    private bool tiembla;

    RalentizadorVelocidad ralentizador;

    // Start is called before the first frame update
    void Start()
    {
        ralentizador = RalentizadorVelocidad.Instance;
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        UIImageBoost = GameObject.Find("ImgBoost").GetComponent<Image>();
        UIImageBoostVida = GameObject.Find("barraVidaBoost").GetComponent<Image>();
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<MovimientoObjeto>() != null)
        {
            MovimientoObjeto oj = collision.gameObject.GetComponent<MovimientoObjeto>();
            var value = oj.objetoBase.tipoObjeto;

            Debug.Log(value);

            switch (value)
            {
                /*case ObjetoScrptBase.Tipo.PiezaAvion:
                    if (!isInmune)
                    {
                        Salud -= 0.2f;
                    }

                    GameObject particulas = generarParticulas(particulasAvion, oj.transform);

                    Debug.Log("IMPACTO!!");
                    rb.AddForce(transform.up * -fuerzaImpactoPieza, ForceMode.Impulse);
                    Destroy(collision.gameObject);
                    tiemblaCamara = GameObject.FindGameObjectWithTag("Pantalla Tiembla").GetComponent<TiemblaCamara>();

                    if (!tiembla)
                    {
                        tiemblaCamara.CamTiembla();
                        tiembla = true;
                    }
                    tiemblaCamara.CamTiembla();
                    StartCoroutine(delay(particulas, 1));
                    break;

                case ObjetoScrptBase.Tipo.Pajaro:
                    if (!isInmune)
                    {
                        Salud -= 0.1f;
                    }

                    GameObject p2 = generarParticulas(particulasPajaro, oj.transform);
                    if (oj.objetoBase.moveLeftToRight)
                    {
                        rb.AddForce(transform.right * fuerzaImpactoPajaro, ForceMode.Impulse);
                    }
                    else
                    {
                        rb.AddForce(transform.right * -fuerzaImpactoPajaro, ForceMode.Impulse);
                    }

                    Destroy(collision.gameObject);
                    StartCoroutine(delay(p2, 1));
                    break;*/

                /*case ObjetoScrptBase.Tipo.Moneda:
                    GameObject p3 = generarParticulas(particulasMoneda, oj.transform);
                    GameController.Score += puntuacion;
                    Destroy(collision.gameObject);
                    StartCoroutine(delay(p3, 1));
                    break;*/

               /* case ObjetoScrptBase.Tipo.Diamante:
                    GameObject p4 = generarParticulas(particulasDiamante, oj.transform);
                    GameController.ScoreDiamante += puntuacionDiamante;
                    Destroy(collision.gameObject);
                    StartCoroutine(delay(p4, 1));
                    break;

                case ObjetoScrptBase.Tipo.BoostIman:
                    Destroy(collision.gameObject);
                    UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/iman");
                    UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/barra");
                    StartCoroutine(delayImgBoost(5));
                    break;

                /*case ObjetoScrptBase.Tipo.BoostInmunidad:
                    UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/inmunidad");
                    UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/barra");
                    StartCoroutine(delayImgBoost(10));
                    break;*/

                /*case ObjetoScrptBase.Tipo.BoostTiempo:
                    StartCoroutine(delayTiempo(10));
                    break;*/

                default:
                    Debug.Log("Nada!!");
                    break;
            }//*/

        }
    }


    IEnumerator delay(GameObject particulas, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(particulas);
    }

    IEnumerator delayImgBoost(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/base");
        UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/base");
    }

    IEnumerator delayInmunidad(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Debug.Log("NO INMUNEEEE!!");
    }

    private GameObject generarParticulas(GameObject tipoParticulas, Transform objeto)
    {
        Vector3 pos = new Vector3(objeto.transform.position.x, objeto.transform.position.y, 0);
        return Instantiate(tipoParticulas, pos, Quaternion.identity);
    }

    IEnumerator delayTiempo(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        ralentizador.ralentizarObjetos(false);
    }

}



