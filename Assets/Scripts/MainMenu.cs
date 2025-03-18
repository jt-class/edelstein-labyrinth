using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayStart()
    {
        SceneManager.LoadSceneAsync(1); //tignan nyo yung buld profile, kung nasaan yung gameplay dun lang lagi dapat nakalagay 
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
