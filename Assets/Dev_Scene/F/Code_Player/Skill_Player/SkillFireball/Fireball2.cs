using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball2 : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float thrust;
    public float knockTime;

    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    private float nextFire = 0f;

    

    private void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            Rigidbody2D enemy = other.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                StartCoroutine(KnockCo(enemy));
            }
        }
    }

    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if (enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            enemy.isKinematic = true;
        }
    }

}
