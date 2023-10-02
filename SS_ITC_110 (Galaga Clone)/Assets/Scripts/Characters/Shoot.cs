using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;
    
    public float bulletForce = 1500.0f;

    [SerializeField] private Movement locMoveRef;

    [SerializeField] private bool canShoot = true;
    
    void Start()
    {
        locMoveRef = GetComponent<Movement>();
    }
    
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && canShoot)
        {
            ShootObject();
        }
    }

    public IEnumerator ShootObject()
    {
        canShoot = false;
        
        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;

        // get Rigidbody2D component of instantiated Bullet and control
        Rigidbody2D tempRigidBody = newBullet.GetComponent<Rigidbody2D>();

        // push the Bullet forward by amount bulletForce
        if (locMoveRef.FacingUp)
        {
            // fireForward is fire to the right
            tempRigidBody.AddForce(transform.up * bulletForce);
        }else
        {
            // fire left, a.k.a. "negative right"
            tempRigidBody.AddForce(-transform.up * bulletForce);
        }

        yield return new WaitForSeconds(1.0f);

        canShoot = true;
        // basic Clean Up, set Bullets to self destruct after 5 seconds
        Destroy(newBullet, 5.0f);
    }
}
