using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clip")]
    public AudioClip backgroundMusic;
    public AudioClip winSound;
    public AudioClip grabKeySound;

    // public GameObject ObjectMusic;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ObjectMusic = GameObject.FindWithTag("Audio");
        // musicSource = ObjectMusic.GetComponent<AudioSource>();
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
    }
}
