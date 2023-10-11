using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPickup : MonoBehaviour
{
    public Movement characterMovement;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            characterMovement.movementSpeed += 3;
            Destroy(this.gameObject);
        }
    }
}