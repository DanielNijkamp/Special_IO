using UnityEngine;
using System.Collections;
using System;

public class ButtonScript : MonoBehaviour
{
    public Color Pressedcolor;
    public Color NormalColor;
    public GameObject button;

    private Renderer button_renderer;

    void Start()
    {
        button_renderer = button.GetComponent<Renderer>();
        button_renderer.material.color = NormalColor;
    }

    public void OnPress(int pos)
    {
        button_renderer.material.color = Pressedcolor;
        FindObjectOfType<SoundManagerScript>().PlaySFX(pos);
        
    }
    public void OnRelease()
    {
        button_renderer.material.color = NormalColor;
    }

}