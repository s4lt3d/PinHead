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
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
