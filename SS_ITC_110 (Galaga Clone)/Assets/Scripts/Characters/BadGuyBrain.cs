using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyBrain : MonoBehaviour
{
    public GameObject player;

    public bool seekingPlayer = false;

    public float moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerShip");
    }

    // Update is called once per frame
    void Update()
    {
        if(!seekingPlayer)
        {
            transform.Translate(0.0f, moveSpeed, 0.0f);
        }else{
            Vector3.MoveTowards(this.transform.position, player.transform.position, moveSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Despawn();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("BadGuyTrigger"))
        {
            seekingPlayer = true;
        }else if(other.gameObject.CompareTag("Despawner"))
        {
            Despawn();
        }
    }

    void Despawn()
    {
        Destroy(this.gameObject);
    }
}
