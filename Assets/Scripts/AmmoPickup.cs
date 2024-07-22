using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    // Mermi miktarýný belirleyen deðiþken
    public int ammoAmount = 25;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {

    }

    // OnTriggerEnter2D, baþka bir 2D collider ile çarpýþma olduðunda çaðrýlan fonksiyon
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Çarpýþan obje "Player" tag'ine sahipse
        if (other.tag == "Player")
        {
            // Oyuncunun mermi miktarýný artýr
            PlayerController.Instance.currentAmmo += ammoAmount;

            // Mermi UI'sini güncelle
            PlayerController.Instance.UpdateAmmoUI();

            // Mermi alma sesini çal
            AudioController.instance.PlayAmmoPickup();

            // Mermi objesini yok et
            Destroy(gameObject);
        }
    }

}
