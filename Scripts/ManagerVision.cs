using UnityEngine;

public class ManagerVision : MonoBehaviour
{
    private Transform manager;

    private void Start()
    {
        manager = transform.parent;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("Player"))
            return;

        Vector2 direction =
            other.transform.position - manager.position;

        float distance = direction.magnitude;

        RaycastHit2D[] hits = Physics2D.RaycastAll(
            manager.position,
            direction.normalized,
            distance
        );

        foreach (RaycastHit2D hit in hits)
        {
            // Ignore manager itself
            if (hit.collider.gameObject == manager.gameObject)
                continue;

            // Vision blocked by wall or desk
            if (hit.collider.gameObject.layer ==
                LayerMask.NameToLayer("Obstacle"))
            {
                return;
            }

            // Player is visible
            if (hit.collider.CompareTag("Player"))
            {
                manager.GetComponent<ManagerPatrol>().StartChase();
                return;
            }
        }
    }
}