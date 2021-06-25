using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[DefaultExecutionOrder(-100)]
public class MaquinaFSM : MonoBehaviour
{
    public GameObject CarrilDown;
    public GameObject CarrilUp;
    public GameObject CarrilIzda1;
    public GameObject CarrilDrcha1;
    public GameObject fondo1;
    public GameObject fondo2;

    public float Velocidad = 3f;
    public float PosRecolocar = -43f;

    public bool estaFondo2 = false;
    public bool estaFondo1 = false;

    public bool transicionFondo = false;

    [System.NonSerialized]
    public Jugador jugador;
    [System.NonSerialized]
    public GameController gameController;
    [System.NonSerialized]
    public EfectosColorGrading efectos;

    public Sprite[] listSpritesFondos;

    EstadoFSM[] estados;

    EstadoFSM currentEstado;

    [System.NonSerialized]
    public List<string> nombreEstados = new List<string>();
    public bool desactivarObjetos = false;
    public string nombreEstadoActual;

    private static MaquinaFSM instance;
    public static MaquinaFSM Instance { get => instance; }

    public EstadoFSM CurrentEstado
    {
        get => currentEstado;
        set
        {
            if (currentEstado == value) return;
            currentEstado = value;
            foreach (EstadoFSM estado in estados)
            {
                estado.enabled = (estado == currentEstado);
            }
            desactivarObjetos = false;
        }
    }

    protected virtual void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }

        estados = GetComponents<EstadoFSM>();
        foreach (EstadoFSM estado in estados)
        {
            if (estado.Inicial) CurrentEstado = estado;
        }
        if (CurrentEstado == null) CurrentEstado = estados[0];
    }

    void Start()
    {
        jugador = Jugador.Instance;
        gameController = GameController.Instance;
        efectos = EfectosColorGrading.Instance;
        StartCoroutine(efectos.cambiarParametros(100f, 5f, 0f));
    }

    public void cambiarFondos(float contador, Sprite fondo, Sprite fondoTransicion, string nuevoEstado)
    {
        fondo1.transform.Translate(fondo1.transform.up * Velocidad * Time.deltaTime); // Hace que la img del fondo 1 se desplaze arriba
        fondo2.transform.Translate(fondo2.transform.up * Velocidad * Time.deltaTime);

        if (fondo2.transform.position.y >= 0 && !estaFondo2)
        {
            fondo1.GetComponent<SpriteRenderer>().sprite = fondo;
            fondo1.transform.position = new Vector3(0, PosRecolocar, fondo1.transform.position.z);
            estaFondo2 = true;
            estaFondo1 = false;
            if (!transicionFondo && contador > 125f)
            {
                fondo1.GetComponent<SpriteRenderer>().sprite = fondoTransicion;
                transicionFondo = true;
            }
            else if (transicionFondo && contador > 125f)
            {
                cambioEstado(nuevoEstado);
            }
        }
        else if (fondo1.transform.position.y >= 0 && !estaFondo1)
        {
            fondo2.GetComponent<SpriteRenderer>().sprite = fondo;
            fondo2.transform.position = new Vector3(0, PosRecolocar, fondo2.transform.position.z);
            estaFondo1 = true;
            estaFondo2 = false;
            if (!transicionFondo && contador > 125f)
            {
                fondo2.GetComponent<SpriteRenderer>().sprite = fondoTransicion;
                transicionFondo = true;
            }
            else if (transicionFondo && contador > 125f)
            {
                cambioEstado(nuevoEstado);
            }
        }
    }

    public void cambioEstado(string nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case "Soleado":
                CurrentEstado = GetComponent<EstSoleado>();
                break;

            case "Niebla":
                CurrentEstado = GetComponent<EstNiebla>();
                break;

            case "Noche":
                CurrentEstado = GetComponent<EstNoche>();
                break;

            case "Lluvia":
                CurrentEstado = GetComponent<EstLluvia>();
                break;

            case "Volcan":
                CurrentEstado = GetComponent<EstVolcan>();
                break;

            default:
                break;
        }
    }

}
