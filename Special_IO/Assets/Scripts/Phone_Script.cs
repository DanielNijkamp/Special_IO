using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;
using Leap.Unity.Interaction;

public class Phone_Script : MonoBehaviour
{
    bool isplaying;
    Vector3 startingpos;
    Quaternion startingrot;
    public GameObject phone;
    private InteractionBehaviour behaviour;
    SoundManagerScript soundmanager;
    public bool nearbase;
    public bool isgrasped;

    float vol;
    private void Start()
    {
        soundmanager = FindObjectOfType<SoundManagerScript>();
        startingrot = transform.rotation;
        startingpos = transform.position;
        behaviour = phone.GetComponent<InteractionBehaviour>();
        vol = soundmanager.SFXVolume;
        soundmanager.phonesource.volume = vol;
        InvokeRepeating("WaitForPhone", 0, 3);
    }
    private void Update()
    {
        if (behaviour.isGrasped)
        {
            soundmanager.phonesource.volume = vol;
            if (!isplaying)
            {
                PlaySFX();
            }
        }
        else
        {
            soundmanager.phonesource.volume = 25f;
        }
        
        
        
    }
    
    void PlaySFX()
    {
        if (behaviour.isGrasped)
        {
            isplaying = true;
            soundmanager.PickUp();
        }
        
        
        
    }
    public void WaitForPhone()
    {
        if (!nearbase && !behaviour.isGrasped)
        {
            transform.position = startingpos;
            transform.rotation = startingrot;
            if (isplaying)
            {
                soundmanager.HangUp();
                isplaying = false;
            }
            
        }
        
        
    }
}
