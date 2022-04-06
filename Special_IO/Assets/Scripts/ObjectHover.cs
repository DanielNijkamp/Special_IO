using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHover : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 0f, 0f);
    public float movementFactor;
    public Leap.Unity.Interaction.InteractionBehaviour cube;

    [SerializeField] float period = 4;
    private bool wasgrabbed = false;
    Vector3 currentposition;

    // Start is called before the first frame update
    void Start()
    {
        currentposition = transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!wasgrabbed)
        {
            if (cube.isGrasped)
            {
                this.gameObject.SetActive(false);
                wasgrabbed = true;
            }
        }
        
        if (period <= 0f) { return; }

        float cycles = Time.time / period;
        const float tau = Mathf.PI * 2;
        float RawSineWave = Mathf.Sin(cycles * tau);

        movementFactor = RawSineWave / 2f + 0.5f;

        Vector3 offset = movementVector * movementFactor;
        transform.position = currentposition + offset;
        transform.Rotate(0, 1, 0);
    }
}