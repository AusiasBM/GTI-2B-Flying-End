using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaController : MonoBehaviour
{

    string nombreNivel;
    public AudioSource audio;
    public AudioClip[] musica;
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


}
