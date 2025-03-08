using UnityEngine;

public class otter : MonoBehaviour
{
    [SerializeField] private Musicbutton musicButton; // Tham chiếu đến Musicbutton

    private void Start()
    {
        if (musicButton != null)
        {
            musicButton.OnVolumeChanged += CheckAudioStatus;
        }
    }

    private void OnDestroy()
    {
        if (musicButton != null)
        {
            musicButton.OnVolumeChanged -= CheckAudioStatus;
        }
    }

    private void CheckAudioStatus(float musicValue, float sfxValue)
    {
        if (musicValue <= -80f && sfxValue <= -80f)
        {
            Debug.Log("Music off");
        }
        else
        {
            Debug.Log("Music on");
        }
    }
}
