using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    public Rigidbody2D theRB;

    public float movespeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float maoseSensivity = 1f;

    public Camera viewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool hasDied;

    public Text healthText, ammoText;
    public GameObject health, ammo;
    public Animator anim;

    // Awake, script oluþturulduðunda çaðrýlýr ve instance oluþturur
    private void Awake()
    {
        Instance = this;
    }

    // Start, script'in baþlatýldýðýnda çalýþtýrýlan fonksiyon
    void Start()
    {
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString() + "%";
        ammoText.text = currentAmmo.ToString();
    }

    // Update, her karede bir kez çaðrýlan fonksiyon
    void Update()
    {
        if (!hasDied)
        {
            // Karakter hareketi
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;
            theRB.velocity = (moveHorizontal + moveVertical) * movespeed;

            // Oyuncu görüþ modeli
            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * maoseSensivity;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);
            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));

            // Ateþ etme
            if (Input.GetMouseButtonDown(0))
            {
                if (currentAmmo > 0)
                {
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(bulletImpact, hit.point, transform.rotation);
                        if (hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().TakeDamage();
                        }
                        AudioController.instance.PlayGunShot();
                    }
                    else
                    {
                        Debug.Log("I am looking at nothing");
                    }
                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                    UpdateAmmoUI();
                }
            }

            if (moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
    }

    // Oyuncu zarar aldýðýnda çaðrýlan fonksiyon
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            deadScreen.SetActive(true);
            health.SetActive(false);
            ammo.SetActive(false);
            hasDied = true;
            currentHealth = 0;
        }
        healthText.text = currentHealth.ToString() + "%";
        AudioController.instance.PlayHurt();
    }

    // Oyuncunun saðlýðýný artýran fonksiyon
    public void AddHealth(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString() + "%";
    }

    // Mermi UI'sini güncelleyen fonksiyon
    public void UpdateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }

}
