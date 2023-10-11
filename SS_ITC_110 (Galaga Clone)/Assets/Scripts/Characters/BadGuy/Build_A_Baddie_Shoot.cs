using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build_A_Baddie_Shoot : MonoBehaviour
{
    public GameObject bullet;
    public GameObject firePoint;

    public float bulletForce = 50.0f;

    [SerializeField] private bool canShoot = true;

    void Update()
    {
        if (canShoot)
        {
            StartCoroutine(ShootObject());
        }
    }

    public IEnumerator ShootObject()
    {
        canShoot = false;

        GameObject newBullet = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation) as GameObject;

        // get Rigidbody2D component of instantiated Bullet and control
        Rigidbody2D tempRigidBody = newBullet.GetComponent<Rigidbody2D>();

        tempRigidBody.AddForce(-this.transform.up * bulletForce);

        yield return new WaitForSeconds(3.0f);

        canShoot = true;
        // basic Clean Up, set Bullets to self destruct after 5 seconds
        Destroy(newBullet, 2.0f);
    }
}
