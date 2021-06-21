using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class sonidoMoneda : MonoBehaviour
{
    private AudioSource sn;
    public AudioClip clips;
    void Awake()
    {
        sn = GetComponent<AudioSource>();
    }
    public void emitir()
    {
        AudioMixer a = Resources.Load<AudioMixer>("NewAudioMixer");
        AudioMixerGroup[] aGroup = a.FindMatchingGroups("Master/SFX/moneda");
        sn.outputAudioMixerGroup = aGroup[0];
        sn.clip = clips;
        sn.Play(0);
       // sn.PlayOneShot();
    }
}
