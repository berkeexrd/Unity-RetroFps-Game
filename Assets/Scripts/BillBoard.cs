using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    private SpriteRenderer theSR;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true; // Sprite'ý yatay olarak çevirir
    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        // Objenin, oyuncuya bakmasýný saðlar
        transform.LookAt(PlayerController.Instance.transform.position, -Vector3.forward);
    }
}
