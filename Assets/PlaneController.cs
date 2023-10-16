using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del avión
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform cannonTransform; // Transform del cañón
    public float bulletSpeed = 10f; // Velocidad del proyectil
    public Camera mainCamera; // Referencia a la cámara principal

    void Update()
    {
        // Obtén la entrada del jugador para mover el avión
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calcula el desplazamiento horizontal
        float horizontalMovement = horizontalInput * speed * Time.deltaTime * -1;
        transform.Translate(new Vector3(0, 0, horizontalMovement));

        // Dispara el proyectil cuando se presiona la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        // Obtén la posición de inicio del proyectil desde el cañón
        Vector3 bulletStartPosition = cannonTransform.position;

        // Instancia el proyectil en la posición del cañón
        GameObject bullet = Instantiate(bulletPrefab, bulletStartPosition, cannonTransform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
    }
}
