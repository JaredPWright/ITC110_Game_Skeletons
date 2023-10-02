using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollingobject : MonoBehaviour
{
    private Rigidbody2D rb;
    public float scrollspeed = -1.5f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2( 0.0f, scrollspeed);
    }
}
