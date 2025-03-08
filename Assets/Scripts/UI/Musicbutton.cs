using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Musicbutton : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    public delegate void VolumeChangedHandler(float musicVolume, float sfxVolume);
    public event VolumeChangedHandler OnVolumeChanged;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
        NotifyVolumeChange();
    }

    public void SetSFXVolume()
    {
        float volume = SFXSlider.value;
        audioMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfxVolume", volume);
        NotifyVolumeChange();
    }

    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        SetMusicVolume();
        SetSFXVolume();
    }

    private void NotifyVolumeChange()
    {
        float musicValue, sfxValue;
        audioMixer.GetFloat("music", out musicValue);
        audioMixer.GetFloat("SFX", out sfxValue);
        OnVolumeChanged?.Invoke(musicValue, sfxValue);
    }
}