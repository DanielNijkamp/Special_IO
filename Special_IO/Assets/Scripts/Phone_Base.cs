using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone_Base : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Phone"))
        {
            other.GetComponent<Phone_Script>().nearbase = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Phone"))
        {
            other.GetComponent<Phone_Script>().nearbase = false;
        }
    }
}
