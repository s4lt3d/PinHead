using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSwing : MonoBehaviour
{

    public bool swinging = false;
    public float explosiveForce = 5.5f;
    public Transform tip;

    List<GameObject> pinBallObjects = new List<GameObject>();

    void Update()
    {

        if (swinging)
        {
            List<GameObject> removes = new List<GameObject>();
            
            foreach (GameObject o in pinBallObjects)
            {
                o.GetComponent<Rigidbody2D>().AddExplosionForce(explosiveForce, tip.position, 6.5f);
                // mark for removal as we can't remove within the loop. 
                removes.Add(o);
            }

            foreach (GameObject o in removes)
                pinBallObjects.Remove(o);
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pinball"))
        {
            pinBallObjects.Add(other.gameObject);
            
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        pinBallObjects.Remove(collision.gameObject);
    }
}
