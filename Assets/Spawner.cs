using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public float time = 1f;
    public float killAfterSeconds = 1f;
    

    private IEnumerator SpawnNewObject()
    {
        yield return new WaitForSeconds(time);
        GameObject g = Instantiate(spawn, transform.position, transform.rotation);
        g.GetComponent<DestroyAfterTime>().secondsToKill = killAfterSeconds;
        g.GetComponent<DestroyAfterTime>().isEnabled = true;

        StartCoroutine(SpawnNewObject());

    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewObject());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
