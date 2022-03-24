using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    public Leap.Unity.Interaction.InteractionSlider UI_Slider;
    public GameObject Desktop_rig;
   
    void Update()
    {
        if (Desktop_rig != null)
        {
            Desktop_rig.transform.rotation = Quaternion.Euler(Desktop_rig.transform.rotation.x, UI_Slider.HorizontalSliderValue, Desktop_rig.transform.rotation.z);
            Desktop_rig.transform.position = new Vector3((UI_Slider.HorizontalSliderValue / 260), Desktop_rig.transform.position.y, -(UI_Slider.HorizontalSliderValue / 260) + 0.9f);
        }
        
    }
}
