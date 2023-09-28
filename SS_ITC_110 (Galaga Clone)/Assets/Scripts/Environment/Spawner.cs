using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float moveSpeed = .75f;
    public float spawnTimer = 5.0f;

    public Vector3 maxPosLeft;
    public Vector3 maxPosRight;

    public GameObject thingPrefab;

    void Start()
    {
        StartCoroutine("SetTimer");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveSpeed, 0.0f, 0.0f);
        
        if(transform.position == maxPosLeft || transform.position == maxPosRight)
        {
            moveSpeed = -moveSpeed;
        }
    }

    IEnumerator SetTimer()
    {
        spawnTimer = Random.Range(0.25f, 1.0f);

        yield return new WaitForSeconds(spawnTimer);

        Spawn();
        StartCoroutine("SetTimer");
    }

    void Spawn()
    {
        Instantiate(thingPrefab, transform.position, transform.rotation);
    }
}
