using UnityEngine;

public class Conveyor : MonoBehaviour
{

    public float speed = 0.5f;

    public Vector3 direction = Vector3.left;

    void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;

        if (rb != null && !rb.isKinematic)
        {
            Vector3 movement = direction.normalized;
            movement.y = 0f;

            rb.MovePosition(
                rb.position + movement * speed * Time.fixedDeltaTime
            );
        }
    }
}
