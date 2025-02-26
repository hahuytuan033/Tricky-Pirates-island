using UnityEngine;
using UnityEngine.UI;

public class Musicbutton : MonoBehaviour
{
    [SerializeField] Image musicOn;
    [SerializeField] Image musicOff;

    private bool muted = false;

    void Start()
    {
        if (PlayerPrefs.HasKey("Muted"))
        {
            PlayerPrefs.SetInt("Muted", 0);
            Load();
        }
        else
        {
            Load();
        }
        UpdateButtonIcon();
        AudioListener.pause = muted;
    }

    public void OnButtonPress()
    {
        if(muted == false)
        {
            muted = true;
            AudioListener.pause= true;
        }
        else
        {
            muted = false;
            AudioListener.pause = false;
        }

        Save();
        UpdateButtonIcon();
    }

    private void UpdateButtonIcon()
    {
        if(muted ==false)
        {
            musicOn.enabled = true;
            musicOff.enabled = false;
        }
        else
        {
            musicOn.enabled = false;
            musicOff.enabled = true;
        }
    }

    private void Load()
    {
        muted= PlayerPrefs.GetInt("Muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("Muted", muted ? 1 : 0);
    }
}
