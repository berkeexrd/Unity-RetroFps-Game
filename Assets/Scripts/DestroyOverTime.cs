using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    // Objenin yok edilme s�resi
    public float lifetime;

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {
        // Objenin belirli bir s�re sonra yok edilmesini sa�lar
        Destroy(gameObject, lifetime);
    }
}
