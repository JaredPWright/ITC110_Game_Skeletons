using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject PlayerShip;
    public float speed;
    public float distanceBetween;

    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //distance = Vector2.Distance(transform.position, PlayerShip.transform.position);
       // Vector2 direction = PlayerShip.transform.position - transform.position;
       // direction.Normalize();

        transform.position = Vector2.MoveTowards(this.transform.position, PlayerShip.transform.position, speed * Time.deltaTime);
       
    }
}
