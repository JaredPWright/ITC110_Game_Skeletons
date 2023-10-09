using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public Movement playerMovement;
    public float speedInc = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerMovement.movementSpeed += speedInc;
            Destroy(gameObject);
        }
    }
}
