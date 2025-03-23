using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFunction : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>(); // Ensure correct reference
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Press Esc to toggle pause
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        if (playerController != null)
        {
            //Implement pause
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        if (playerController != null)
        {
            //Remove pause
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
