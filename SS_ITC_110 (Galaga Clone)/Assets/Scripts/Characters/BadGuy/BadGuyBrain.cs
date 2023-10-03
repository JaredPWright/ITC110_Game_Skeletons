using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuyBrain : MonoBehaviour
{
    public GameObject player;

    public float moveSpeed = 0.5f;
    public float timeBetweenStates = 5.0f;

    public int pointVal = 100;

    public enum BadGuyState { Attacking, Idling, Returning  };
    public BadGuyState state;

    [SerializeField] private Vector3 homePos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerShip");
        state = BadGuyState.Idling;
        homePos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == homePos) { state = BadGuyState.Idling; }

        switch(state)
        {
            case BadGuyState.Attacking :
                Vector3.MoveTowards(this.transform.position, player.transform.position, moveSpeed * Time.deltaTime);
                break;
            case BadGuyState.Returning :
                Vector3.MoveTowards(this.transform.position, homePos, moveSpeed * Time.deltaTime);
                break;
            default :
                SeekPlayer();
                break;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameObject temp = other.gameObject;
        if (temp.CompareTag("Player"))
        {   
            Despawn();
            temp.GetComponent<CharacterBrain>().health--;
        }
    }

    IEnumerator SeekPlayer()
    {
        yield return new WaitForSeconds(timeBetweenStates);
        state = BadGuyState.Attacking;
        yield return new WaitForSeconds(timeBetweenStates);
        state = BadGuyState.Returning;
    }

    void Despawn()
    {
        Destroy(this.gameObject);
        GameObject.Find("GameManager").GetComponent<GameManager>().Score = pointVal;
    }
}
