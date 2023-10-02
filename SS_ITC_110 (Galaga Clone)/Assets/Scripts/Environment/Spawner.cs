using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public float boundMin;
    public float boundMax;
    public float sizeOfObject = 0.0f;
    public Vector3 stepMin = new Vector3(0.0f,0.0f,0.0f);
    
    public bool horizontal = true;
    
    public GameObject objectToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnAndMove(GenerateTime()));
    }

    float GenerateTime()
    {
        return Random.Range(2.0f, 5.0f);
    }

    Vector3 GenerateNewPos()
    {
        Vector3 newPos = new Vector3();
        float absPosVal = Mathf.Abs(newPos.x) + Mathf.Abs(newPos.y) + Mathf.Abs(newPos.z);
        
        if (horizontal)
        {
            sizeOfObject = objectToSpawn.GetComponent<Collider2D>().bounds.size.x;
            while (absPosVal <= sizeOfObject)
            {
                newPos = new Vector3(Random.Range(boundMin, boundMax), transform.position.y, 0.0f);
                absPosVal = Mathf.Abs(newPos.x) + Mathf.Abs(newPos.y) + Mathf.Abs(newPos.z);
            }
        }
        else
        {
            sizeOfObject = objectToSpawn.GetComponent<Collider2D>().bounds.size.y;
            while (absPosVal <= sizeOfObject)
            {
                newPos = new Vector3(transform.position.x, Random.Range(boundMin, boundMax), 0.0f);
                absPosVal = Mathf.Abs(newPos.x) + Mathf.Abs(newPos.y) + Mathf.Abs(newPos.z);
            }
        }
        
        return newPos;
    }

    IEnumerator SpawnAndMove(float timeBetweenSpawns)
    {
        transform.position = GenerateNewPos();
        Instantiate(objectToSpawn, transform.position, quaternion.identity);
        yield return new WaitForSeconds(timeBetweenSpawns);
        StartCoroutine(SpawnAndMove(GenerateTime()));
    }
}
