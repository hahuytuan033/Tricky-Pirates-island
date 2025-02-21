using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i= 0; i< levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            levelButtons[i].interactable = true;
        }
    }

    public void ResetLevel()
    {
        PlayerPrefs.SetInt("UnlockedLevel", 1);
        for (int i= 0; i< levelButtons.Length; i++)
        {
            levelButtons[i].interactable = false;
        }
        levelButtons[0].interactable = true;
        PlayerPrefs.Save();
    }

    public void OpenLevel(int levelId)
    {
        string levelName ="Level " + levelId;
        SceneManager.LoadScene(levelName);
    }

    public void NewPlayButton()
    {
        ResetLevel();
    }
}
