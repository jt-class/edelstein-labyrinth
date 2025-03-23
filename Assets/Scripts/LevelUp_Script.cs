using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp_Script : MonoBehaviour
{
    [SerializeField] GameObject LevelUp_Canvas;
    
    void Start()
    {
        Time.timeScale = 0;
    }

    public void A()
    {
        removeUI();
    }
    public void B()
    {
        removeUI();
    }
    public void C() 
    {
        removeUI();
    }
    public void removeUI() // Removes the UI from the screen and continue the game.
    {
        LevelUp_Canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
