using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ControlSalud : MonoBehaviour
{

    public GameObject vida;
    private Image barraSalud;
    private int salud = 9;

    public void quitarVida(int vidaMenos)
    {

       salud = salud - vidaMenos;

        if (salud == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }

        barraSalud.sprite = Resources.Load<Sprite>("Sprites/Hud/Vida/vida" + salud);
    }

    private static ControlSalud instance;
    public static ControlSalud Instance { get => instance; }

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
    // Start is called before the first frame update
    void Start()
    {
        barraSalud = vida.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
