using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float velocidadJugador = 6f;
    public Transform LimiteDerecha;
    public Transform LimiteIzquierda;
    public Transform LimiteUp;
    public Transform LimiteDown;

    public bool isInmune = false;
    public bool isMagnetic = false;

    private static Jugador instance;
    public static Jugador Instance { get => instance; }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate(){

        float newX = velocidadJugador * Input.GetAxis(GameConstants.AXE_H) * Time.deltaTime;
        float newY = velocidadJugador * Input.GetAxis(GameConstants.AXE_V) * Time.deltaTime;

        //Limitar movimientos en el eje X
        if (transform.position.x + newX > LimiteIzquierda.position.x
            && transform.position.x + newX < LimiteDerecha.position.x)
        {
            transform.Translate(newX, 0, 0);
        }


        //Limitar movimientos eje Y
        if (transform.position.y + newY > LimiteDown.position.y
            && transform.position.y + newY < LimiteUp.position.y)
        {
            transform.Translate(0, newY, 0);
        }


        //Evitar que salga de los l�mites por posibles colisiones
        //Eje x
        if (transform.position.x > LimiteDerecha.position.x)
        {
            transform.position = new Vector3(LimiteDerecha.position.x, transform.position.y, 0);
        }else if(transform.position.x < LimiteIzquierda.position.x)
        {
            transform.position = new Vector3(LimiteIzquierda.position.x, transform.position.y, 0);
        }

        //Eje y
        if (transform.position.y > LimiteUp.position.y)
        {
            transform.position = new Vector3(transform.position.x, LimiteUp.position.y, 0);
        }
        else if (transform.position.y < LimiteDown.position.y)
        {
            transform.position = new Vector3(transform.position.x, LimiteDown.position.y, 0);
        }

    }

    public void efectoTemporal(int seconds)
    {
        StartCoroutine(delay(10));
    }

    public IEnumerator delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        isInmune = false;
        isMagnetic = false;
    }

    public void generarParticulas(GameObject tipoParticulas, Transform objeto)
    {
        Vector3 pos = new Vector3(objeto.transform.position.x, objeto.transform.position.y, 0);
        GameObject particulas = Instantiate(tipoParticulas, pos, Quaternion.identity);
        StartCoroutine(delay(particulas, 1));
    }

    IEnumerator delay(GameObject particulas, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(particulas);
    }

}

public class GameConstants
{
    public const string AXE_H = "Horizontal";
    public const string AXE_V = "Vertical";

}

