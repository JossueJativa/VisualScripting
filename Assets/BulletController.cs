using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil en el eje X

    void Update()
    {
        // Mueve el proyectil en la dirección del eje X
        Vector3 movement = new Vector3(speed * Time.deltaTime, 0, 0);
        transform.Translate(movement);

        // Elimina el proyectil cuando esté fuera de la vista de la cámara
        if (!IsVisibleByCamera())
        {
            Destroy(gameObject);
        }
    }

    bool IsVisibleByCamera()
    {
        Camera mainCamera = Camera.main;
        if (mainCamera == null)
        {
            return true; // Si no hay cámara, asumimos que es visible
        }

        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(mainCamera);
        return GeometryUtility.TestPlanesAABB(planes, GetComponent<Collider>().bounds);
    }
}
