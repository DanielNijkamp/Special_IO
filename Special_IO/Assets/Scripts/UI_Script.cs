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
    public bool IsShooting;

    public GameObject ShootButton;
    public Camera cam2;

    public LayerMask layer;
    public GameObject TargetEffect;

    Vector3[] positions = new Vector3[2] ;
    public LineRenderer laser;

    public float buttonZ_Offset;
    public float buttonX_Offset;
    public float buttonY_Offset;

    public PC_Manager pc_manager;

    private void Start()
    {
        pc_manager = FindObjectOfType<PC_Manager>();
        ButtonPressed = false;
        IsShooting = false;
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
            if (ShootButton != null)
            {
                //ShootButton.transform.position = hand.PalmPosition.ToVector3() - new Vector3(buttonX_Offset, buttonY_Offset, buttonZ_Offset);
                //ShootButton.transform.position = hand.PalmPosition.ToVector3();
                //ShootButton.transform.rotation = Quaternion.FromToRotation(Vector3.up, hand.PalmNormal.ToVector3());
            }
            if (ButtonPressed)
            {
                RaycastHit hit;
                if (Physics.Raycast(hand.Fingers[1].TipPosition.ToVector3(), hand.Fingers[1].Direction.ToVector3(), out hit, 50))
                {
                    positions[0] = hand.Fingers[1].TipPosition.ToVector3();
                    positions[1] = hit.point;
                    laser.SetPositions(positions);
                }   
                
              
                
            }
            if (IsShooting)
            {
                RaycastHit hit;
                if (Physics.Raycast(hand.Fingers[1].TipPosition.ToVector3(), hand.Fingers[1].Direction.ToVector3(), out hit, Mathf.Infinity, layer))
                {
                    var localPoint = hit.textureCoord;
                    Ray portalRay = cam2.ScreenPointToRay(new Vector2(localPoint.x * cam2.pixelWidth, localPoint.y * cam2.pixelHeight));
                    RaycastHit _hit;
                    if (Physics.Raycast(portalRay.origin, portalRay.direction, out _hit, 100))
                    {
                        if (!pc_manager.GameEnded)
                        {
                            StartCoroutine(SpawnEffect(_hit));
                            if (_hit.transform.gameObject.CompareTag("Target"))
                            {
                                pc_manager.targets.Remove(_hit.transform.gameObject);
                                Destroy(_hit.transform.gameObject);
                            }
                        }
                        else
                        {
                            if (_hit.transform.gameObject.CompareTag("PlayButton"))
                            {
                                pc_manager.RestartGame();
                            }
                            else if (_hit.transform.gameObject.CompareTag("QuitButton"))
                            {
                                pc_manager.Deactivate_Game();
                                laser.gameObject.SetActive(false);
                            }
                        }
                        
                    }
                }
            }   
        }
    }
    public void DetectButtonInput()
    {
        if (!ButtonPressed)
        {
            pc_manager.Activate_Game(); 
            ShootButton.SetActive(true);
            laser.gameObject.SetActive(true);
            ButtonPressed = true;
        }
        else if (ButtonPressed)
        {
            pc_manager.Deactivate_Game();
            ShootButton.SetActive(false);
            laser.gameObject.SetActive(false);
            ButtonPressed = false;
        }
    }
    public void Shoot()
    {
        StartCoroutine(ShootBool());
    }
    IEnumerator ShootBool()
    {
        IsShooting = true;
        yield return new WaitForSeconds(0.0001f);
        IsShooting = false;
    }
    IEnumerator SpawnEffect(RaycastHit _hit)
    {
        GameObject new_effect = Instantiate(TargetEffect);
        new_effect.transform.position = _hit.point;
        yield return new WaitForSecondsRealtime(0.25f);
        Destroy(new_effect);
    }
    public void ResetObjects()
    {
        ResetScript[] resetScripts = FindObjectsOfType<ResetScript>();
        foreach (ResetScript script in resetScripts)
        {
            script.This_Reset_Position();
        }
    }
    
}
