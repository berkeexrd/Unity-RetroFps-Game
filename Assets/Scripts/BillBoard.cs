using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{

    private SpriteRenderer theSR;

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true; // Sprite'� yatay olarak �evirir
    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {
        // Objenin, oyuncuya bakmas�n� sa�lar
        transform.LookAt(PlayerController.Instance.transform.position, -Vector3.forward);
    }
}
