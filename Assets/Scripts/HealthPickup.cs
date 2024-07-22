using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Sa�l�k miktar�n� belirleyen de�i�ken
    public int healthAmount = 25;

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {

    }

    // Oyuncu sa�l�k paketiyle �arp��t���nda �a�r�lan fonksiyon
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.AddHealth(healthAmount); // Oyuncunun sa�l���n� art�r
            AudioController.instance.PlayHealth(); // Sa�l�k alma sesini �al
            Destroy(gameObject); // Sa�l�k paketini yok et
        }
    }

}
