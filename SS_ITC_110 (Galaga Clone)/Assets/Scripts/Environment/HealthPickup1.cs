using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthpickup1 : MonoBehaviour
{
    public CharacterBrain characterBrain;

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.gameObject.CompareTag("Player"))
        {
            characterBrain.health++;
            Destroy(this.gameObject);
        }
    }
}
