using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingFrameDiag : MonoBehaviour
{
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float deltaX, deltaY;
    void Update()
    {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(deltaX, deltaY) * Time.deltaTime, rawImage.uvRect.size);
    }
}
