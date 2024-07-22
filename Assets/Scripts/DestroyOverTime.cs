using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    // Objenin yok edilme süresi
    public float lifetime;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        // Objenin belirli bir süre sonra yok edilmesini saðlar
        Destroy(gameObject, lifetime);
    }
}
