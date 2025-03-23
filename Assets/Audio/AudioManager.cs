using System;
using UnityEngine;
using UnityEngine.SceneManagement; // Add SceneManager for scene detection

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("------------Audio Source------------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("------------Audio Clip Player------------")]
    public AudioClip player_pickup;
    public AudioClip player_hurt;

    public AudioClip player_Walk1;
    public AudioClip player_Walk2;
    public AudioClip player_Walk3;
    public AudioClip player_Walk4;
    public AudioClip player_Walk5;
    public AudioClip player_Walk6;

    [Header("------------Audio Clip Enemy------------")]
    public AudioClip enemy_death;
    public AudioClip enemy_hit;

    [Header("------------Audio Clip MainMenu------------")]
    public AudioClip mainmenu_button_back;
    public AudioClip mainmenu_button_press;
    public AudioClip mainmenu_select_tick;
    public AudioClip mainmenu_background;

    [Header("------------Audio Clip BG Music------------")]
    public AudioClip bg_forest;
    public AudioClip bg_summer;
    public AudioClip bg_plain;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Listen for scene changes
        PlayMusic(mainmenu_background); // Play main menu music by default
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // Play Background Music
    public void PlayMusic(AudioClip clip)
    {
        if (musicSource != null && clip != null)
        {
            musicSource.clip = clip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // Stop Background Music
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    // Play Sound Effect
    public void PlaySFX(AudioClip clip)
    {
        if (SFXSource != null && clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }

    // Play a Random Footstep Sound
    public void PlayFootstepSound()
    {
        AudioClip[] footstepSounds = { player_Walk1, player_Walk2, player_Walk3, player_Walk4, player_Walk5, player_Walk6 };
        AudioClip stepSound = footstepSounds[UnityEngine.Random.Range(0, footstepSounds.Length)];
        PlaySFX(stepSound);
    }

    // Detect when a new scene is loaded and change music accordingly
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MainMenu")
        {
            PlayMusic(mainmenu_background);
        }
        else if (scene.name == "GameScene" || scene.buildIndex == 1)
        {
            StopMusic(); // Stop main menu music first
            PlayMusic(bg_forest); // Play in-game music
        }
        else
        {
            StopMusic();
        }
    }
}
