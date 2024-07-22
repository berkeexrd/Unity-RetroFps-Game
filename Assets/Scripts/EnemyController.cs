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

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {
        // Oyuncuya olan mesafeyi kontrol eder ve ona do�ru hareket eder
        if (Vector3.Distance(transform.position, PlayerController.Instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.Instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            // D��man�n ate� etme mekanizmas�
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

    // D��man zarar ald���nda �a�r�lan fonksiyon
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
