using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour
{
    public AudioClip[] SFX;

    public float BGMVolume;
    public float SFXVolume;
    public bool GameStarted = false;

    public AudioSource sfxSource;
    public AudioSource bgmSource;




    void Update()
    {

    }
    public void StopMusic()
    {
        bgmSource.Stop();

    }


    public void ChangeSFXVolume(float value)
    {
        float newVolume = value * 0.01f;
        sfxSource.volume = newVolume;
        SFXVolume = value * 0.01f;
    }
    public void ChangeBGMVolume(float value)
    {
        float newVolume = value * 0.01f;
        bgmSource.volume = newVolume;
        BGMVolume = newVolume;
    }
    public void PlayButtonSFX()
    {
        sfxSource.clip = SFX[Random.Range(0, SFX.Length)];
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);
    }
    
}