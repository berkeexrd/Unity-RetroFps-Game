using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    // Mermi miktar�n� belirleyen de�i�ken
    public int ammoAmount = 25;

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {

    }

    // OnTriggerEnter2D, ba�ka bir 2D collider ile �arp��ma oldu�unda �a�r�lan fonksiyon
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �arp��an obje "Player" tag'ine sahipse
        if (other.tag == "Player")
        {
            // Oyuncunun mermi miktar�n� art�r
            PlayerController.Instance.currentAmmo += ammoAmount;

            // Mermi UI'sini g�ncelle
            PlayerController.Instance.UpdateAmmoUI();

            // Mermi alma sesini �al
            AudioController.instance.PlayAmmoPickup();

            // Mermi objesini yok et
            Destroy(gameObject);
        }
    }

}
