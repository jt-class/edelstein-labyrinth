using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayStart()
    {
        SceneManager.LoadSceneAsync(0);
    }
   
}
