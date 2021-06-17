using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicaController : MonoBehaviour
{

    string nombreNivel;
    public AudioSource audio;
    public AudioClip[] musica;
    public AudioClip m;
    public AudioClip m1;
    public static MusicaController instance;
    public MusicaController Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        else
        {
            instance = this;

        }

        DontDestroyOnLoad(gameObject);





    }

    // Start is called before the first frame update
    void Start()
    {

        audio = GetComponent<AudioSource>();

        musicaMenu();


    }


    public void musicaMenu()
    {
        audio.Stop();
        audio.clip = musica[0];
        audio.Play();


    }
    public void musicajuego()
    {
        audio.Stop();

        audio.clip = musica[1];
        audio.Play();

    }
    public void acordeInicio()
    {

        audio.PlayOneShot(musica[5], 0.7F);



    }
    public void musicaLluvia()
    {

        audio.PlayOneShot(musica[2], 0.7F);
        audio.loop = true;


    }

    public void musicaVolcan()
    {

        audio.PlayOneShot(musica[3], 0.7F);
        audio.loop = true;

    }
    public void musicaPajaros()
    {

        audio.PlayOneShot(musica[4], 0.7F);
        audio.loop = true;


    }

}
