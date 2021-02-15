using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundBumper : MonoBehaviour
{

    public float explosiveForce = 1000;
    public float scale = 1.5f;
    public float speed = 1;

    private float _scale = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scale = Mathf.Lerp(_scale, 1, Time.deltaTime * speed);
        transform.localScale = new Vector3(_scale, _scale, _scale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _scale = 1.5f;
        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddExplosionForce(explosiveForce, transform.position, 3);
        }
    }

}
