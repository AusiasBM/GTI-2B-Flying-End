using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Partida : MonoBehaviour
{
    public User user;
    [System.NonSerialized]
    public Distancia distancia;

    public Text nick;
    public Text aviso;

    public bool estaSinConexion = false;

    public bool recordRoto = false;

    [System.NonSerialized]
    public WebSaveLoad saveLoad;

    const string KEYNAME = "ranking";

    public InputField partidas;

    List<User> users = new List<User>();
    public static Partida instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        user = new User();
        distancia = new Distancia();
        saveLoad = GetComponent<WebSaveLoad>();
        saveLoad.Load("usuarios", ref user);
        limpiarUser();
        //cargarRanking();
        //cargarUsuario();
    }

    public void limpiarUser()
    {
        user.nombre = "";
        user.monedas = 0;
        user.diamantes = 0;
        user.distanciaMaxima = 0;
        user.paracaidas = 0;
    }


    public void guardarDistancia()
    {
        Debug.Log(JsonUtility.ToJson(distancia));
        saveLoad.Save(KEYNAME, distancia);
    }

    public void cargarRanking()
    {
        saveLoad.Load(KEYNAME, ref distancia);
    }

    public void WebError()
    {
        Debug.LogWarning(saveLoad.Error);
    }

    public void cargarJugador()
    {
        saveLoad.Load("usuarios", ref user);
        delay(5);
        if (nick.text != "")
        {
            
            for (int i = 0; i < saveLoad.user.Length; i++)
            {
                if (saveLoad.user[i].nombre == nick.text)
                {
                    user.nombre = saveLoad.user[i].nombre;
                    user.monedas = saveLoad.user[i].monedas;
                    user.diamantes = saveLoad.user[i].diamantes;
                    user.distanciaMaxima = saveLoad.user[i].distanciaMaxima;
                    user.paracaidas = saveLoad.user[i].paracaidas;
                    SceneManager.LoadScene("Loading");
                }
            }
            aviso.text = "El nombre de usuario introducido no existe o no es correcto";
        }
        else
        {
            aviso.text = "El campo de texto está vacio";
        }
        
    }

    public void partidaSinConexion() {

        if (nick.text == "")
        {
            aviso.text = "El campo de texto está vacio";
        }
        else
        {
            estaSinConexion = true;
            user.nombre = nick.text;
            user.monedas = 0;
            user.diamantes = 0;
            user.distanciaMaxima = 0;
            user.paracaidas = 0;
            SceneManager.LoadScene("Loading");
        }
        
    }

    public void crearNick()
    {
        if (nick.text == "")
        {
            aviso.text = "El campo de texto está vacio";
        }
        else
        {
            saveLoad.Load("usuarios", ref user);
            delay(5);
            bool existe = false;

            for (int i = 0; i < saveLoad.user.Length; i++)
            {
                if (saveLoad.user[i].nombre == nick.text)
                {
                    user.nombre = saveLoad.user[i].nombre;
                    user.monedas = saveLoad.user[i].monedas;
                    user.diamantes = saveLoad.user[i].diamantes;
                    user.distanciaMaxima = saveLoad.user[i].distanciaMaxima;
                    user.paracaidas = saveLoad.user[i].paracaidas;
                    existe = true;
                }
            }
            if (!existe)
            {
                user.nombre = nick.text;
                user.monedas = 0;
                user.diamantes = 0;
                user.distanciaMaxima = 0;
                user.paracaidas = 0;
                saveLoad.Save("usuarios", user);
                delay(5);
                SceneManager.LoadScene("Loading");
            }
            else
            {
                aviso.text = "Este Nick ya existe";
            }


        }
    }

    public void actualizarBbdd()
    {
        saveLoad.Save("update", user);

    }

    public IEnumerator delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}