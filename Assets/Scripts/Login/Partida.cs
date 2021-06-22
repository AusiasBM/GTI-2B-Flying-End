using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Partida : MonoBehaviour
{
    public User user;
    public Usuario usuario;
    [System.NonSerialized]
    public Distancia distancia;

    [System.NonSerialized]
    public WebSaveLoad saveLoad;
    IDataSaveLoad fileSaveLoad;

    const string KEYNAME = "ranking";
    const string FILENAME = "users";

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
        fileSaveLoad = new FileSaveLoad();
        user = new User();
        usuario = new Usuario();
        distancia = new Distancia();
        saveLoad = GetComponent<WebSaveLoad>();
        cargarRanking();
        fileSaveLoad.Load(FILENAME, ref user);
        cargarUsuario();
    }

    void cargarUsuario()
    {
        if (user.username != "")
        {
            partidas.text = user.username;
            partidas.enabled = false;
        }
        else
        {
            partidas.text = "";
            partidas.enabled = true;
        }

    }


    /*void cargarUsuarios()
    {
        users = db.getAllUsers();
        
        for(int i = 0; i < users.Count; i++)
        {
            Debug.Log(users[i].username);
            partidas[i].text = users[i].username;
            partidas[i].enabled = false;
        }
    }*/

    public void crearPartida(Text usuario)
    {
        user.username = usuario.text.ToString();
        fileSaveLoad.Save(FILENAME, user);
        fileSaveLoad.Load(FILENAME, ref user);
        CargarPartida();
    }

    public void eliminarPartida()
    {
        fileSaveLoad.Clear(FILENAME);
        user.username = "";
        user.monedas = 0;
        user.diamantes = 0;
        vaciarCamposTexto();
        cargarUsuario();
    }

    public void CargarPartida()
    {
        if (user.username != "")
        {
            SceneManager.LoadScene("Loading");

        }
        else
        {

            Debug.Log("No hay ninguna partida creada");
        }

    }

    /*public void CrearPartida(Text usuario)
    {
        user = db.getUser(usuario.text.ToString());
        if(user.username == "")
        {
            user.username = usuario.text.ToString();
            db.addUser(user);
            CargarPartida();
        }
        else
        {
            Debug.Log("Usuario ya creado");
        }
    }

    

    public void EliminarPartida(Text usuario)
    {
        db.deleteUser(usuario.text.ToString());
        vaciarCamposTexto();
        cargarUsuarios();
    }*/

    void vaciarCamposTexto()
    {

        partidas.text = "";
        partidas.enabled = true;
        
    }

    /*public void actualizarDatosPartida()
    {
        db.updateUser(user);

    }*/

    public void actualizarDatosPartida()
    {
        fileSaveLoad.Save(FILENAME, user);
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
        saveLoad.Load("usuarios", ref usuario);
    }

}