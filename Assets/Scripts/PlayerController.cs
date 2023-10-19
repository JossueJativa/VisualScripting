using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab; // Prefab de la bala
    public Transform shootOrigin;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * speed * Time.deltaTime);
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonUp(0))
        {
            // Instancia la bala
            GameObject bullet = Instantiate(bulletPrefab, shootOrigin.position, Quaternion.identity);
            
            Destroy(bullet, 0.5f);
        }
    }
}
