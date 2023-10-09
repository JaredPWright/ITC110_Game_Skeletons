using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Build_A_Baddie : MonoBehaviour
{
    //Put your own functions here!
    public BadGuyBrain badGuyBrain;
    public Rigidbody2D rigidBody;

    private float distance;
    public float speed;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireSpeed = 5f;
    private bool canShoot = true;
    public float fireRate = 1f;

    public float xOffSet;

    private void Start()
    {
        badGuyBrain = GetComponent<BadGuyBrain>();
        speed = badGuyBrain.moveSpeed;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Vector3.Distance(this.gameObject.transform.position, badGuyBrain.player.transform.position) <= 2.0f)
        {
            Explode();
        }

    }

    private void FixedUpdate()
    {
        if (canShoot)
            StartCoroutine(EnemyShoot());

        Movement();
    }

    public void Explode()
    {
        badGuyBrain.player.GetComponent<CharacterBrain>().health--;
        badGuyBrain.Despawn();
    }

    void Movement()
    {
        if (badGuyBrain.player.transform.position.x > 3 || badGuyBrain.player.transform.position.x < -3)
            rigidBody.position = new Vector2(rigidBody.position.x, rigidBody.position.y);
        else
            rigidBody.position = new Vector2(badGuyBrain.player.transform.position.x + xOffSet, rigidBody.position.y);
    }

    public IEnumerator EnemyShoot()
    {
        canShoot = false;

        yield return new WaitForSeconds(fireRate);

        // get Rigidbody2D component of instantiated Bullet and control
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * fireSpeed, ForceMode2D.Impulse);

        canShoot = true;

        Destroy(bullet, 5f);
    }

}
