using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {
        LockCursor(); // Oyunun baþýnda imleci kilitler
    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        // ESC tuþuna basýldýðýnda imleci serbest býrakýr
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        // F11 tuþuna basýldýðýnda imleci kilitler
        if (Input.GetKeyDown(KeyCode.F11))
        {
            LockCursor();
        }
    }

    // Ýmleci kilitleyen fonksiyon
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Ýmleci serbest býrakan fonksiyon
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
