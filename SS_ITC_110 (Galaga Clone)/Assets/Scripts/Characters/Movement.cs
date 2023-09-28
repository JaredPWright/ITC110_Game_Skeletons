using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 0.5f;
    private bool facingRight = false;

    public bool FacingRight
    {
        get { return facingRight; }
    }

    void FixedUpdate()
    {
        transform.Translate((Input.GetAxis("Horizontal")* movementSpeed * Time.deltaTime), 0.0f, 0.0f);
        transform.Translate(0.0f, (Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime), 0.0f);
    }
}
