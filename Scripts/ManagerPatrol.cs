using UnityEngine;

public class ManagerPatrol : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    private Transform target;
    private Transform player;

    public bool isChasing = false;

    private void Start()
    {
        target = pointB;

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");

        player = playerObject.transform;
    }

    private void Update()
    {
        // Movement
        if (isChasing)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                chaseSpeed * Time.deltaTime
            );
        }
        else
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                target.position,
                patrolSpeed * Time.deltaTime
            );

            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                target = target == pointA ? pointB : pointA;
            }
        }

        // Facing direction
        float moveDirection;

        if (isChasing)
        {
            moveDirection = player.position.x - transform.position.x;
        }
        else
        {
            moveDirection = target.position.x - transform.position.x;
        }

        Vector3 scale = transform.localScale;

if (moveDirection < 0)
{
    scale.x = -Mathf.Abs(scale.x);
}
else
{
    scale.x = Mathf.Abs(scale.x);
}

transform.localScale = scale;
    }

    public void StartChase()
    {
        isChasing = true;
    }
}