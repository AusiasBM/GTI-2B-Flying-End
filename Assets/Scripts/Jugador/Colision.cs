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
    public GameObject ParticulasAvion;
    public GameObject ParticulasPajaro;
    public GameObject Jugador;
    public Image UIImageBoost;
    public Image UIImageBoostVida;

    public Image barraSalud;

    public float fuerzaImpactoPajaro = 3f;
    public float fuerzaImpactoPieza = 2f;

    private bool isInmune = false;

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

    private void OnCollisionEnter(Collision collision)
    {
        Moneda moneda = collision.gameObject.GetComponent<Moneda>();
        Diamante diamante = collision.gameObject.GetComponent<Diamante>();
        Iman iman = collision.gameObject.GetComponent<Iman>();
        Inmunidad inmunidad = collision.gameObject.GetComponent<Inmunidad>();
        PiezaAvion pieza = collision.gameObject.GetComponent<PiezaAvion>();
        PajaroDcha pD = collision.gameObject.GetComponent<PajaroDcha>();
        PajaroIzda pI = collision.gameObject.GetComponent<PajaroIzda>();

        if (moneda != null)
        {
            Vector3 pos = new Vector3(moneda.transform.position.x, moneda.transform.position.y, 0);
            GameObject particulas = Instantiate(particulasMoneda, pos, Quaternion.identity);
            GameController.Score += puntuacion;
            Debug.Log("MONEDA!!");
            Destroy(collision.gameObject);
            StartCoroutine(delay(particulas, 1));
        }

        if (diamante != null)
        {
            Vector3 pos = new Vector3(diamante.transform.position.x, diamante.transform.position.y, 0);
            GameObject particulas = Instantiate(particulasDiamante, pos, Quaternion.identity);
            GameController.ScoreDiamante += puntuacionDiamante;
            Debug.Log("DIAMANTE!!");
            Destroy(collision.gameObject);
            StartCoroutine(delay(particulas, 1));
        }

        if (iman != null)
        {
            //Vector3 pos = new Vector3(iman.transform.position.x, iman.transform.position.y, 0);
            //GameObject particulas = Instantiate(particulasDiamante, pos, Quaternion.identity);
            //GameController.ScoreDiamante += puntuacionDiamante;
            //StartCoroutine(delay(particulas, 1));

            Debug.Log("IMAN!!");
            Destroy(collision.gameObject);
            UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/iman");
            UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/barra");
            StartCoroutine(delayImgBoost(5));

        }

        if (inmunidad != null)
        {
            //Efecto particulas
            //Vector3 pos = new Vector3(inmunidad.transform.position.x, inmunidad.transform.position.y, 0);
            //GameObject particulas = Instantiate(particulasDiamante, pos, Quaternion.identity);
            //GameController.ScoreDiamante += puntuacionDiamante;
            //StartCoroutine(delay(particulas, 1));

            isInmune = true;
            StartCoroutine(delayInmunidad(10));
            Debug.Log("INMUNIDAD!!");
            Destroy(collision.gameObject);
            UIImageBoost.sprite = Resources.Load<Sprite>("Sprites/inmunidad");
            UIImageBoostVida.sprite = Resources.Load<Sprite>("Sprites/barra");
            StartCoroutine(delayImgBoost(10));
        }

        if (pieza != null)
        {
            if (!isInmune)
            {
                Salud -= 0.2f;
            }
            Vector3 pos = new Vector3(Jugador.transform.position.x, Jugador.transform.position.y+1f, 0);
            GameObject particulas = Instantiate(ParticulasAvion, pos, Quaternion.identity);
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

        }

        if (pD != null)
        {
            if (!isInmune)
            {
                Salud -= 0.1f;
            }
            Vector3 pos = new Vector3(pD.transform.position.x, pD.transform.position.y, 0);
            GameObject particulas = Instantiate(ParticulasPajaro, pos, Quaternion.identity);
            Debug.Log("PajaroDcha!!");
            rb.AddForce(transform.right * -fuerzaImpactoPajaro, ForceMode.Impulse);
            Destroy(collision.gameObject);
            StartCoroutine(delay(particulas, 1));
        }

        if (pI != null)
        {
            if (!isInmune)
            {
                Salud -= 0.1f;
            }
            Vector3 pos = new Vector3(pI.transform.position.x, pI.transform.position.y, 0);
            GameObject particulas = Instantiate(ParticulasPajaro, pos, Quaternion.identity);

            Debug.Log("PajaroIzda!!");
            rb.AddForce(transform.right* fuerzaImpactoPajaro, ForceMode.Impulse);
            Destroy(collision.gameObject);
            StartCoroutine(delay(particulas, 1));
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


}



