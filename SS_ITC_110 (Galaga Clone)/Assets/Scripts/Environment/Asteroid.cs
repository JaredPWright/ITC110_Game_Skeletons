using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 0.5f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0.0f, -moveSpeed, 0.0f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<CharacterBrain>().health--;
            Despawn();
        }else if(other.gameObject.CompareTag("Bullet"))
        {
            Despawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Despawner")
        {
            Despawn();
        }
    }

    void Despawn()
    {
        Destroy(this.gameObject);
    }
}
