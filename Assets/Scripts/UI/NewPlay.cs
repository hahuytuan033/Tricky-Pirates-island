using UnityEngine;
using UnityEngine.SceneManagement;

public class NewPlay : MonoBehaviour
{
    public void NewPlayGame()
    {
        PlayerPrefs.SetInt("LevelsUnlocked", 1); // Reset về chỉ mở khóa màn đầu tiên
        SceneManager.LoadScene(0); // Tải lại scene đầu tiên (Level 1)
    }
}
