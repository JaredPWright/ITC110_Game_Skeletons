using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_A_Baddie : MonoBehaviour
{
    //Put your own functions here!
    public BadGuyBrain badGuyBrain;

    private void Start()
    {
        badGuyBrain = GetComponent<BadGuyBrain>();
    }

    private void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, badGuyBrain.player.transform.position) <= 2.0f)
        {
            // Duplicate();
            Explode();
        }
    }

    public void Explode()
    {
        badGuyBrain.player.GetComponent<CharacterBrain>().health--;
        badGuyBrain.Despawn();
    }

    // public void Duplicate()
    // {
    //     //duplicate this object
    //     GameObject newBadGuy = Instantiate(this.gameObject);
    //     newBadGuy.transform.position = new Vector3(UnityEngine.Random.Range(-5.0f, 5.0f), 0.0f, UnityEngine.Random.Range(-5.0f, 5.0f));
    // }
}
