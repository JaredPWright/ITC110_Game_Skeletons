using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class repeatingbackground : MonoBehaviour
{
    private BoxCollider2D coll2D;
    [SerializeField]private float verticalLength;
    // Start is called before the first frame update
    void Start()
    {
        coll2D = GetComponent<BoxCollider2D>();
        verticalLength = coll2D.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < - verticalLength)
        {
            RepoGround();
        }
    }

    private void RepoGround()
    {
        Vector2 groundoffset = new Vector2(0f, verticalLength * 2.0f);
        transform.position = (Vector2)transform.position + groundoffset;
    }
}
