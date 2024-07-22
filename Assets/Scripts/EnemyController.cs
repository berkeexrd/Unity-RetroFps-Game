using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 3;
    public GameObject explosion;

    public float playerRange = 10f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;

    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firePoint;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        // Oyuncuya olan mesafeyi kontrol eder ve ona doðru hareket eder
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.Instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            // Düþmanýn ateþ etme mekanizmasý
            if (shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if (shotCounter <= 0)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                    shotCounter = fireRate;
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;
        }
    }

    // Düþman zarar aldýðýnda çaðrýlan fonksiyon
    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            AudioController.instance.PlayEnemyDeath();
        }
        else
        {
            AudioController.instance.PlayenemyShot();
        }
    }
}
