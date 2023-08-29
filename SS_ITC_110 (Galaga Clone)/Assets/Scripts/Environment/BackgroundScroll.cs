using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    public float scrollSpeed = 1.0f; //This is how quickly the background will scroll, making the illusion of movement. 
    public Vector3 topLocation;    //When our background reaches this point, teleport it back to the bottomLocation.
    public Vector3 bottomLocation; //This is where our backgrounds start their journey.

    void FixedUpdate()
    {
        //This moves our background
        transform.Translate(0.0f, scrollSpeed, 0.0f);
        
        //When the background leaves the camera, move it back to the bottom, so it can keep scrolling
        if(transform.position.y == topLocation.y)
        {
            transform.position = bottomLocation;
        }
    }
}
