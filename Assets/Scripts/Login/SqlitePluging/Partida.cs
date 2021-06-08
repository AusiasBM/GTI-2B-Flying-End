using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Partida : MonoBehaviour
{
    public User user;
    BaseDatos db;

    public InputField[] partidas;

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
        db = BaseDatos.instance;
        user = new User();
        cargarUsuarios();
    }


    void cargarUsuarios()
    {
        users = db.getAllUsers();
        
        for(int i = 0; i < users.Count; i++)
        {
            Debug.Log(users[i].username);
            partidas[i].text = users[i].username;
            partidas[i].enabled = false;
        }
    } 

    public void CargarPartida(Text usuario)
    {
        user = db.getUser(usuario.text.ToString());
        if (user.username != "")
        {
            SceneManager.LoadScene("Loading");
            
        }
        else
        {

            Debug.Log("No hay ninguna partida creada");
        }
        
    }

    public void CrearPartida(Text usuario)
    {
        user = db.getUser(usuario.text.ToString());
        if(user.username == "")
        {
            user.username = usuario.text.ToString();
            db.addUser(user);
            CargarPartida(usuario);
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
    }

    void vaciarCamposTexto()
    {
        for(int i = 0; i < 5; i++)
        {
            partidas[i].text = "";
            partidas[i].enabled = true;
        }
    }


    public void actualizarDatosPartida()
    {
        db.updateUser(user);

    }


}
