using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;
    public float time = 1;

    private IEnumerator SpawnNewObject()
    {
        yield return new WaitForSeconds(time);
        Instantiate(spawn, transform.position, transform.rotation);
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
