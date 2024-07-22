using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform doorModel;
    public GameObject colObject;

    public float openSpeed;
    private bool shouldOpen;

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {

    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        if (shouldOpen && doorModel.position.z != 1f)
        {
            // Kapýnýn açýlmasýný saðlar
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 1f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 1f)
            {
                colObject.SetActive(false);
            }
        }
        else if (!shouldOpen && doorModel.position.z != 0f)
        {
            // Kapýnýn kapanmasýný saðlar
            doorModel.position = Vector3.MoveTowards(doorModel.position, new Vector3(doorModel.position.x, doorModel.position.y, 0f), openSpeed * Time.deltaTime);

            if (doorModel.position.z == 0f)
            {
                colObject.SetActive(true);
            }

        }
    }

    // Oyuncu kapýya girdiðinde kapýyý açar
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = true;
        }
    }

    // Oyuncu kapýdan çýktýðýnda kapýyý kapatýr
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            shouldOpen = false;
        }
    }

}
