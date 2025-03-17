using UnityEditor.Timeline.Actions;
using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("Audio Clips")]
    public AudioClip backgroundMusic;
    public AudioClip deathMusic;
    public AudioClip winMusic;
    public AudioClip keyPickup;
    public AudioClip powerUp;
    public AudioClip powerDown;
    public AudioClip blueDiamond;

    private static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
        musicSource.loop = true;
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip == deathMusic)
        {
            StartCoroutine(PlayDeathMusic(clip));
        }
        else
        {
            sfxSource.PlayOneShot(clip);
        }
    }

    private IEnumerator PlayDeathMusic(AudioClip clip)
    {
        musicSource.Stop();
        sfxSource.PlayOneShot(clip);
        yield return new WaitForSeconds(clip.length); // Chờ đến khi deathMusic kết thúc
        musicSource.Play();
    }

    public static AudioManager Instance
    {
        get { return instance; }
    }
}

