using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickup : MonoBehaviour
{
    public CharacterBrain characterBrain; // Add a semicolon to the declaration

    // Start is called before the first frame update
    void Start() // Add the missing "void" keyword and rename the method to "Start"
    {
        // Initialize characterBrain here if needed
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) // Fix the typo in "compareTag" to "CompareTag"
        {
            characterBrain.health++;
            Destroy(this.gameObject);
        }
    }
}
