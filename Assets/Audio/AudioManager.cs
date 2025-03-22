using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------------Audio Source------------")]

    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;


    [Header("------------Audio Clip------------")]
    public AudioClip background;
    public AudioClip enemy_death;
    public AudioClip enemy_hit;
    public AudioClip player_pickup;
    public AudioClip player_hurt;


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
