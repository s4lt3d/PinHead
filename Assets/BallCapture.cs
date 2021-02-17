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
    public Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Pinball"))
        {
            GameObject.Destroy(other.gameObject);
            GameObject.Instantiate(captureObject, transform);
            particles.enableEmission = false;
            pointLight.color = captureColor;
            collider.enabled = false;



        }
        
    }
}
