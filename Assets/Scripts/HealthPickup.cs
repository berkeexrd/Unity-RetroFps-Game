using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    // Saðlýk miktarýný belirleyen deðiþken
    public int healthAmount = 25;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {

    }

    // Oyuncu saðlýk paketiyle çarpýþtýðýnda çaðrýlan fonksiyon
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerController.Instance.AddHealth(healthAmount); // Oyuncunun saðlýðýný artýr
            AudioController.instance.PlayHealth(); // Saðlýk alma sesini çal
            Destroy(gameObject); // Saðlýk paketini yok et
        }
    }

}
