using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyBullet : MonoBehaviour
{
    bool Debounce = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject temp = other.gameObject;
        if ((temp.CompareTag("Player")) && (!Debounce))
        {
            Debounce = true;
            temp.GetComponent<CharacterBrain>().health--;
            Destroy(this.gameObject);
        }
        else if (temp.CompareTag("Despawner"))
        {
            Destroy(this.gameObject);
        }
    }
}
