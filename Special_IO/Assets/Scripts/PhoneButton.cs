using UnityEngine;
using System.Collections;
using System;

public class PhoneButton : MonoBehaviour
{
    public Color Pressedcolor;
    public Color NormalColor;
    public GameObject button;
    private Phone_Script Phone_Script;
    private Renderer button_renderer;

    void Start()
    {
        button_renderer = button.GetComponent<Renderer>();
        button_renderer.material.color = NormalColor;
        Phone_Script = FindObjectOfType<Phone_Script>();
    }

    public void OnPress(int pos)
    {
        button_renderer.material.color = Pressedcolor;
        FindObjectOfType<SoundManagerScript>().PlaySFX(pos);
        Phone_Script.ResetPosition();
        Phone_Script.soundmanager.HangUp();
        Phone_Script.isplaying = false;


    }
    public void OnRelease()
    {
        button_renderer.material.color = NormalColor;
    }

}