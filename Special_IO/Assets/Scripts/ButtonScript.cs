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
        Debug.Log("Pressed");
        button_renderer.material.color = Pressedcolor;
        FindObjectOfType<SoundManagerScript>().PlayButtonSFX(pos);
        
    }
    public void OnRelease()
    {
        Debug.Log("Released");
        button_renderer.material.color = NormalColor;
    }

}