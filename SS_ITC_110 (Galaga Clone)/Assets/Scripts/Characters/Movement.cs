using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 0.5f;

    void FixedUpdate()
    {
        if(Input.GetButton("left"))
        {
            transform.Translate(-movementSpeed, 0.0f, 0.0f);
        }else if(Input.GetButton("right"))
        {
            transform.Translate(movementSpeed, 0.0f, 0.0f);
        }

        if(Input.GetButton("up"))
        {
            transform.Translate(0.0f, movementSpeed, 0.0f);
        }else if(Input.GetButton("down"))
        {
            transform.Translate(0.0f, -movementSpeed, 0.0f);
        }
    }
}
