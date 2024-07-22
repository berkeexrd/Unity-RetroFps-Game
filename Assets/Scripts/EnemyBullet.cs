using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed = 5f;

    public Rigidbody2D theRB;

    private Vector3 direction;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {
        // Mermi yönünü oyuncuya doðru ayarlar
        direction = PlayerController.Instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        // Merminin hareketini saðlar
        theRB.velocity = direction * bulletSpeed;
    }

    // Mermi oyuncuya çarptýðýnda zarar verir ve mermiyi yok eder
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

}
