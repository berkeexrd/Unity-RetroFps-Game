using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;

    public float openSpeed;
    private bool shouldOpen;

    // Start, script'in ba�lat�ld���nda �al��t�r�lan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez �a�r�lan fonksiyon
    void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            // Kap�n�n a��lmas�n� sa�lar
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }
        else if (!shouldOpen && doorModel.position.z != 0f)
        {
            // Kap�n�n kapanmas�n� sa�lar
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 0f)
            {
                colObject.SetActive(true);
            }

        }
    }

    // Oyuncu kap�ya girdi�inde kap�y� a�ar
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = true;
        }
    }

    // Oyuncu kap�dan ��kt���nda kap�y� kapat�r
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }

}
