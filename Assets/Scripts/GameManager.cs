using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {
        LockCursor(); // Oyunun ba��nda imleci kilitler
    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {
        // ESC tu�una bas�ld���nda imleci serbest b�rak�r
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursor();
        }

        // F11 tu�una bas�ld���nda imleci kilitler
        if (Input.GetKeyDown(KeyCode.F11))
        {
            LockCursor();
        }
    }

    // �mleci kilitleyen fonksiyon
    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // �mleci serbest b�rakan fonksiyon
    public void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}
