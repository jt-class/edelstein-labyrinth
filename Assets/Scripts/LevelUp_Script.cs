//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUp_Script : MonoBehaviour
{
    [SerializeField] GameObject LevelUp_Canvas;
    [SerializeField] PlayerController player;
    public GameObject fireBallProjectile;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void A()
    {
        player.maxHealth *= 2;
        player.HealthSlider.maxValue = player.maxHealth;
        removeUI();
    }
    public void B()
    {
        player.shootCooldown = .5f;
        removeUI();
    }
    public void C() 
    {
        player.arrowObject = fireBallProjectile;
        removeUI();
    }
    public void removeUI() // Removes the UI from the screen and continue the game.
    {
        LevelUp_Canvas.SetActive(false);
        Time.timeScale = 1;
    }
}
