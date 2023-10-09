using UnityEngine;

public class PickUp : MonoBehaviour
{
    public CharacterBrain characterBrain;
    public Movement movement;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            characterBrain.health++;
            movement.movementSpeed++;
        }
    }
}
