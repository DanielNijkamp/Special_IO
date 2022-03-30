using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public GameObject BoundingBox;
    // Start is called before the first frame update
    void Start()
    {
        BoundingBox = GameObject.FindGameObjectWithTag("BoundingBox");
        Bounds bounds = GetComponent<Collider>().bounds;
        float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
        float offsetZ = Random.Range(-bounds.extents.z, bounds.extents.z);
        float rand = Random.Range(0, 360);

        this.transform.position = bounds.center + new Vector3(offsetX, -0.9f, offsetZ);

        var euler = transform.eulerAngles;
        euler.y = Random.Range(0f, 360f);
        transform.eulerAngles = euler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
