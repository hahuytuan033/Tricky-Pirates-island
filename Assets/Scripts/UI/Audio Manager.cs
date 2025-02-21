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
    public AudioClip gameOverSound;
    public AudioClip jumpUpSound;


    private bool wasMusicPlaying;
    private bool wasSFXPlaying;

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

    public void PlayGameOverSound()
    {
        wasMusicPlaying = musicSource.isPlaying;
        wasSFXPlaying = sfxSource.isPlaying;
        // stop all sound
        musicSource.Stop();
        sfxSource.Stop();

        // play game over sound
        sfxSource.clip = gameOverSound;
        sfxSource.Play();

        StartCoroutine(RestoreAudioState(gameOverSound.length));
    }

    private System.Collections.IEnumerator RestoreAudioState(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (wasMusicPlaying)
        {
            musicSource.Play();
        }

        if (wasSFXPlaying)
        {
            sfxSource.Play();
        }
    }
}
