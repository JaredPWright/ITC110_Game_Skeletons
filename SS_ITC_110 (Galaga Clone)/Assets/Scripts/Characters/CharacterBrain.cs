using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBrain : MonoBehaviour
{
    public int health = 3;
    public Shoot shootScript;

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
            Time.timeScale = 0;
        }
    }

    void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))
        {
            shootScript.ShootObject();
        }
    }
}
