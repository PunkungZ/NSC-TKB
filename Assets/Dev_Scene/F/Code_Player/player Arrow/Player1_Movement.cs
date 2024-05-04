using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1_Movement : Base_Player
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    void Update()
    {
        MovementPlayerArrow();
        ShootFireball();
    }

    private void ShootFireball()
    {
        if (Input.GetKeyDown(KeyCode.L) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 playerDirection = transform.localScale.x > 0 ? Vector2.right : Vector2.left;
        bullet.transform.right = playerDirection;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = playerDirection * bulletSpeed;
        Destroy(bullet, 2f);
    }
}
