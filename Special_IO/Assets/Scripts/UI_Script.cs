using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class UI_Script : MonoBehaviour
{
    public Leap.Unity.Interaction.InteractionSlider UI_Slider;
    public GameObject Desktop_rig;
    private bool ButtonPressed;

    private void Start()
    {
        ButtonPressed = false;
    }
    void Update()
    {
        if (Desktop_rig != null)
        {
            Desktop_rig.transform.rotation = Quaternion.Euler(Desktop_rig.transform.rotation.x, UI_Slider.HorizontalSliderValue, Desktop_rig.transform.rotation.z);
            Desktop_rig.transform.position = new Vector3((UI_Slider.HorizontalSliderValue / 260), Desktop_rig.transform.position.y, -(UI_Slider.HorizontalSliderValue / 260) + 0.9f);
        }
        var hand = Hands.Right;
        if (hand != null)
        {
            if (ButtonPressed)
            {
                Debug.DrawRay(hand.Fingers[1].TipPosition.ToVector3(), hand.Fingers[1].Direction.ToVector3(), Color.red);
                Debug.Log(hand.Fingers[1].TipPosition.ToVector3());
            }
            
        }
    }
    
    void Activate_Finger_Point()
    {
        Debug.Log("Activated");
    }
    void Deactivate_Finger_Point()
    {
        Debug.Log("Deactivated");
    }
    public void DetectButtonInput()
    {
        if (!ButtonPressed)
        {
            Activate_Finger_Point();
            ButtonPressed = true;
        }
        else if (ButtonPressed)
        {
            Deactivate_Finger_Point();
            ButtonPressed = false;
        }
    }
}
