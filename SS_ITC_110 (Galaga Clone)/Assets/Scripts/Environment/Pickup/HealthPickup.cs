using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public CharacterBrain character;
    public int healthInc = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            character.health += healthInc;
            Destroy(gameObject);
        }
    }
}
