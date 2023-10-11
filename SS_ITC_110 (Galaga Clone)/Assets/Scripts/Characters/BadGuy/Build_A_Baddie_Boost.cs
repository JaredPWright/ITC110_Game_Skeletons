using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_A_Baddie_Boost : MonoBehaviour
{
    //Put your own functions here!
    public BadGuyBrain badGuyBrain;

    public GameObject objectToSpawn;
    public Vector3 origin;
    public float radius = 10;

    bool Debounce = false;

    private void Start()
    {
        badGuyBrain = GetComponent<BadGuyBrain>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet") && !Debounce)
        {
            Debounce = true;
            GiveBoost();
        }
    }

    public void GiveBoost()
    {
        origin = this.transform.position;
        Vector3 randomPosition = origin + Random.insideUnitSphere * radius;
        Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
    }
}
