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
    public AudioSource phonesource;



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
    public void PlaySFX(int position)
    {
        sfxSource.clip = SFX[position];
        sfxSource.volume = SFXVolume;
        sfxSource.PlayOneShot(sfxSource.clip);
    }
    public void HangUp()
    {
        StartCoroutine(StopSoundEffects(4));
    }
    public void PickUp()
    {
        StartCoroutine(PickUpSFX(2, 3));
    }
    IEnumerator StopSoundEffects(int position)
    {
        phonesource.Stop();
        phonesource.clip = SFX[position];
        phonesource.PlayOneShot(phonesource.clip);
        yield return new WaitForSecondsRealtime(phonesource.clip.length);
    }
    IEnumerator PickUpSFX(int a, int b)
    {
        phonesource.clip = SFX[a];
        phonesource.PlayOneShot(phonesource.clip);
        yield return new WaitForSecondsRealtime(phonesource.clip.length);
        phonesource.clip = SFX[b];
        phonesource.PlayOneShot(phonesource.clip);
    }

}