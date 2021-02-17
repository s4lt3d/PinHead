using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialKick : MonoBehaviour
{

    [Header("Initial Velocity along Red Vector X")]
    [Range(0, 50f)] public float initialVelocity = 10f;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.left * initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
