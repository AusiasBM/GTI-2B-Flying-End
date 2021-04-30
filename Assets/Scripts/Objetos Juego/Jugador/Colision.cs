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
    public GameObject jugador;
    public Image UIImageBoost;
    public Image UIImageBoostVida;

    public Image barraSalud;

    public float fuerzaImpactoPajaro = 3f;
    public float fuerzaImpactoPieza = 2f;

    private bool isInmune = false;

    private bool tiempoRalentizado = false;
    private bool controlRalentizacion = false;

    GameObject[] piezas;
    GameObject[] pajaros;
    GameObject[] spawnLateral;

    [Range(0, 1)]
    [SerializeField]
    private float salud = 1f;

    private TiemblaCamara tiemblaCamara;
    public float Salud
    {
        get
        {
            return salud;
        }

        set
        {
            salud = Mathf.Clamp01(value);
            if (salud == 0)
            {
                Destroy(gameObject);
                SceneManager.LoadScene("GameOver");
            }
            barraSalud.fillAmount = salud;
        }
    }

    Rigidbody rb;
    private bool tiembla;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        UIImageBoost = GameObject.Find("ImgBoost").GetComponent<Image>();
        UIImageBoostVida = GameObject.Find("barraVidaBoost").GetComponent<Image>();
    }


    void Update()
    {

        if (tiempoRalentizado)
        {
            ralentizarTiempo("Pieza", true);
            ralentizarTiempo("Pajaro", true);
            ralentizarTiempo("Lateral", true);
            ralentizarTiempo("Superior", true);
        }

        if (controlRalentizacion)
        {
            controlRalentizacion = false;

            ralentizarTiempo("Pieza", false);
            ralentizarTiempo("Pajaro", false);
            ralentizarTiempo("Lateral", false);
            ralentizarTiempo("Superior", false);
        }//*/
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<ObjetoJuego>() != null)
        {
            ObjetoJuego oj = collision.gameObject.GetComponent<ObjetoJuego>();
            ObjetoJuego.Tipo value = oj.tipoObjeto;
            Debug.Log(value);

            switch (oj.tipoObjeto)
            {
                case ObjetoJuego.Tipo.PiezaAvion:
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

                case ObjetoJuego.Tipo.Pajaro:
                    if (!isInmune)
                    {
                        Salud -= 0.1f;
                    }

                    GameObject p2 = generarParticulas(particulasPajaro, oj.transform);
                    if (oj.moveLeftToRight)
                    {
                        rb.AddForce(transform.right * fuerzaImpactoPajaro, ForceMode.Impulse);
                    }
                    else
                    {
                        rb.AddForce(transform.right * -fuerzaImpactoPajaro, ForceMode.Impulse);
                    }

                    Destroy(collision.gameObject);
                    StartCoroutine(delay(p2, 1));
                    break;

                case ObjetoJuego.Tipo.Moneda:
                    GameObject p3 = generarParticulas(particulasMoneda, oj.transform);
                    GameController.Score += puntuacion;
                    Destroy(collision.gameObject);
                    StartCoroutine(delay(p3, 1));
                    break;

                case ObjetoJuego.Tipo.Diamante:
                    GameObject p4 = generarParticulas(particulasDiamante, oj.transform);
                    GameController.ScoreDiamante += puntuacionDiamante;
                    Destroy(collision.gameObject);
                    StartCoroutine(delay(p4, 1));
                    break;

                case ObjetoJuego.Tipo.BoostIman:
                    Debug.Log("IMAN!!");
                    Destroy(collision.gameObject);
                    UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/iman");
                    UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/barra");
                    StartCoroutine(delayImgBoost(5));
                    break;

                case ObjetoJuego.Tipo.BoostInmunidad:
                    isInmune = true;
                    StartCoroutine(delayInmunidad(10));
                    Debug.Log("INMUNIDAD!!");
                    Destroy(collision.gameObject);
                    UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/inmunidad");
                    UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/barra");
                    StartCoroutine(delayImgBoost(10));
                    break;

                case ObjetoJuego.Tipo.BoostTiempo:
                    Destroy(collision.gameObject);
                    tiempoRalentizado = true;
                    StartCoroutine(delayTiempo(10));
                    break;

                default:
                    Debug.Log("Nada!!");
                    break;
            }

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
        isInmune = false;
        Debug.Log("NO INMUNEEEE!!");
    }


    IEnumerator delayTiempo(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        tiempoRalentizado = false;
        controlRalentizacion = true;

    }

    private GameObject generarParticulas(GameObject tipoParticulas, Transform objeto)
    {
        Vector3 pos = new Vector3(objeto.transform.position.x, objeto.transform.position.y, 0);
        return Instantiate(tipoParticulas, pos, Quaternion.identity);
    }

    private void ralentizarTiempo(string tag, bool isRalentizado)
    {
        GameObject[] lista = GameObject.FindGameObjectsWithTag(tag);
        if (lista.Length != 0)
        {
            foreach (GameObject g in lista)
            {
                if (tag == "Pieza" || tag == "Pajaro")
                {
                    g.GetComponent<ObjetoJuego>().ralentizar = isRalentizado;
                }
                else if(tag == "Lateral")
                {
                    g.GetComponent<CrearPajaros>().ralentizar = isRalentizado;
                }
                else
                {
                    g.GetComponent<CrearPiezas>().ralentizar = isRalentizado;
                }

            }
        }
    }


}



