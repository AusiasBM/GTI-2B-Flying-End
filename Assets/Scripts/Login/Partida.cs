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

    public Text nick;
    public Text aviso;

    public bool estaSinConexion = false;

    public bool recordRoto = false;

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
        saveLoad.Load("usuarios", ref user);
        //cargarRanking();
        //cargarUsuario();
    }

    void cargarUsuario()
    {
        if (user.nombre != "")
        {
            partidas.text = user.nombre;
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
        user.nombre = usuario.text.ToString();
        fileSaveLoad.Save(FILENAME, user);
        fileSaveLoad.Load(FILENAME, ref user);
        CargarPartida();
    }

    public void eliminarPartida()
    {
        fileSaveLoad.Clear(FILENAME);
        user.nombre = "";
        user.monedas = 0;
        user.diamantes = 0;
        vaciarCamposTexto();
        cargarUsuario();
    }

    public void CargarPartida()
    {
        if (user.nombre != "")
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
                    existe = true;
                }
            }
            if (!existe)
            {
                user.nombre = nick.text;
                user.monedas = 0;
                user.diamantes = 0;
                user.distanciaMaxima = 0;
                saveLoad.Save("usuarios", user);
                delay(5);
                SceneManager.LoadScene("Loading");
            }
            else
            {
                aviso.text = "Este Nick ya existe, apreta ENTRAR";
            }


        }
    }

    public void actualizarBbdd()
    {
        saveLoad.Save("update", user);

    }

    IEnumerator delay(int seconds)
    {
        yield return new WaitForSeconds(seconds);
    }

}