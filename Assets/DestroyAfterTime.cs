using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [Header("Time")]
    public float secondsToKill = 0;
    public bool isEnabled = false;

    IEnumerator DestroyAfterSeconds()
    {
        yield return new WaitForSeconds(secondsToKill);
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(enabled && secondsToKill > 0)
        {
            StartCoroutine(DestroyAfterSeconds());
        }
    }

}
