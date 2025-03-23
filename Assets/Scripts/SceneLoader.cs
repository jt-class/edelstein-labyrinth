using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameplayScene()
    {
        SceneManager.LoadScene("GamePlay");  
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");  
    }

}
