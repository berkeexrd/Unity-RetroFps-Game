using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damageAmount;

    public float bulletSpeed = 5f;

    public Rigidbody2D theRB;

    private Vector3 direction;

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {
        // Mermi y�n�n� oyuncuya do�ru ayarlar
        direction = PlayerController.Instance.transform.position - transform.position;
        direction.Normalize();
        direction = direction * bulletSpeed;
    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {
        // Merminin hareketini sa�lar
        theRB.velocity = direction * bulletSpeed;
    }

    // Mermi oyuncuya �arpt���nda zarar verir ve mermiyi yok eder
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.TakeDamage(damageAmount);
            Destroy(gameObject);
        }
    }

}
