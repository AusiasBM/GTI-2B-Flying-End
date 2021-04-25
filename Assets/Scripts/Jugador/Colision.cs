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

    public Image barraSalud;

    public float fuerzaImpactoPajaro = 3f;
    public float fuerzaImpactoPieza = 2f;

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
    }

    private void OnCollisionEnter(Collision collision)
    {
        Moneda moneda = collision.gameObject.GetComponent<Moneda>();
        Diamante diamante = collision.gameObject.GetComponent<Diamante>();
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

        if (pieza != null)
        {
            Salud -= 0.2f;
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
            Salud -= 0.1f;
            Vector3 pos = new Vector3(pD.transform.position.x, pD.transform.position.y, 0);
            GameObject particulas = Instantiate(ParticulasPajaro, pos, Quaternion.identity);
            Debug.Log("PajaroDcha!!");
            rb.AddForce(transform.right * -fuerzaImpactoPajaro, ForceMode.Impulse);
            Destroy(collision.gameObject);
            StartCoroutine(delay(particulas, 1));
        }

        if (pI != null)
        {
            Salud -= 0.1f;
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


}



