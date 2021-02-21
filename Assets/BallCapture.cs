using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCapture : MonoBehaviour
{

    [Header("An object to show when captured")]
    public GameObject captureObject;
    public ParticleSystem particles;
    public Light pointLight;
    public Color captureColor;
    public Collider2D collider2d;
    public bool ballDestory = false;

    [Header("Ball Count Object")]
    public FloatVariable ballcount;


    [System.Obsolete]
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            GameObject.Destroy(other.gameObject);
            
            
            // update the total number of balls captured. 
            if (ballDestory == false)
            {
                particles.enableEmission = false;
                pointLight.color = captureColor;
                collider2d.enabled = false;
                GameObject.Instantiate(captureObject, transform);
                ballcount.Value += 1;
            }
        }
    }

}
