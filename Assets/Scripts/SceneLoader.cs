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

    public void LoadInventoryScene()
    {
        SceneManager.LoadScene("Inventory");
    }

    public void LoadEquipmentScene()
    {
        SceneManager.LoadScene("Equipment");
    }

    public void LoadRuneScene()
    {
        SceneManager.LoadScene("Rune");
    }

    public void LoadCharacterScene()
    {
        SceneManager.LoadScene("Character");
    }
}
