using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Conveyor : MonoBehaviour
{
    public float speed = 0.5f;
    public Vector3 direction = Vector3.left;

    void OnCollisionStay(Collision collision)
    {
        Rigidbody rb = collision.rigidbody;
        if (rb == null || rb.isKinematic) return;

        XRGrabInteractable grab = rb.GetComponent<XRGrabInteractable>();
        if (grab != null && grab.isSelected) return;

        Vector3 movement = direction.normalized;
        movement.y = 0f;

        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}