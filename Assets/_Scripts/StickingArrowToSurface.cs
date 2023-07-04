using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StickingArrowToSurface : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private SphereCollider myCollider;
    [SerializeField] private GameObject stickingArrow;

    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        myCollider.isTrigger = true;

        GameObject arrow = Instantiate(stickingArrow);
        arrow.transform.position = transform.position;
        arrow.transform.forward = transform.forward;

        if (collision.collider.attachedRigidbody != null)
        {
            arrow.transform.parent = collision.collider.attachedRigidbody.transform;
        }

        IHittable hittableComponent = collision.collider.GetComponent<IHittable>();
        if (hittableComponent != null)
        {
            hittableComponent.GetHit();
            Debug.Log("IHittable component found!");
            if (collision.gameObject.CompareTag("Target"))
            {
                GameManager.instance.IncreaseScore(1);
                Debug.Log("Target hit!");
            }
        }
        else
        {
            Debug.Log("IHittable component not found!");
        }

        Destroy(gameObject);
    }
}

