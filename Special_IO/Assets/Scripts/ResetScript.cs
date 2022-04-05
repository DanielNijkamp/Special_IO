using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetScript : MonoBehaviour
{
    Vector3 startingpos;
    Quaternion startingrot;
    // Start is called before the first frame update
    void Start()
    {
        startingrot = transform.rotation;
        startingpos = transform.position;
    }

    public void This_Reset_Position()
    {
        this.transform.position = startingpos;
        this.transform.rotation = startingrot;
    }
}
