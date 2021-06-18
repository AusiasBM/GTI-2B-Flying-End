using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class logicaVolumenSFX : MonoBehaviour
{
    public Slider sliderSFX;
    public float sliderValueSFX;
    AudioSource sfx;

    // Start is called before the first frame update
    void Start()
    {
        sliderSFX.value = PlayerPrefs.GetFloat("volumenEfectos", 0.5f);
        sfx = GetComponent<AudioSource>();
        sfx.volume = sliderSFX.value;

    }

    public void ChangeSlider(float valor)
    {
        sliderValueSFX = valor;
        PlayerPrefs.SetFloat("volumenEfectos", sliderValueSFX);
        sfx.volume = sliderSFX.value;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
