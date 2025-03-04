using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelScripts : MonoBehaviour
{
    public void Pass()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex>= PlayerPrefs.GetInt("LevelsUnlocked"))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", currentSceneIndex + 1);
        }
    }
}
