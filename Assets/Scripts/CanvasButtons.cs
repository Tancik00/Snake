using UnityEngine;

public class CanvasButtons : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void StartGame()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
