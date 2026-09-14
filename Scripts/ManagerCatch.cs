using UnityEngine;

public class ManagerCatch : MonoBehaviour
{
    private Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < 0.7f)
        {
            GameManager.Instance.GameOver();
        }
    }
}