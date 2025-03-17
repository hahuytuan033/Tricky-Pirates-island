using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGameLv1 : MonoBehaviour
{
    public Button newPlayBtn;

    void Awake()
    {
        newPlayBtn= GetComponent<Button>();
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void NewPlayGame()
    {
        PlayerPrefs.SetInt("LevelsUnlocked", 1); // Reset về chỉ mở khóa màn đầu tiên
        SceneManager.LoadScene(0); // Tải lại scene đầu tiên (Level 1)
    }
}
