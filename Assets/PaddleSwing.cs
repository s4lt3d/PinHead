using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSwing : MonoBehaviour
{

    public bool swinging = false;
    public float explosiveForce = 5.5f;
    public Transform tip;

    List<GameObject> pinBallObjects = new List<GameObject>();

    void FixedUpdate()
    {

        if (swinging)
        {
            foreach (GameObject o in pinBallObjects)
            {
                Debug.Log("Hit!");
                o.GetComponent<Rigidbody2D>().AddExplosionForce(explosiveForce, tip.position, 6.5f);
            }
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            pinBallObjects.Add(other.gameObject);
            
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        pinBallObjects.Remove(collision.gameObject);
    }
}
