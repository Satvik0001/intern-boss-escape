using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject startMenuCanvas;

    public GameObject player;
    public GameObject manager;

    public void StartGame()
    {
        startMenuCanvas.SetActive(false);

        player.SetActive(true);
        manager.SetActive(true);

        Time.timeScale = 1f;
    }
}