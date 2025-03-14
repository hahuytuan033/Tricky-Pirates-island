using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartGameLv1 : MonoBehaviour
{
    public Button newPlayBtn;

    void Awake()
    {
        newPlayBtn= GetComponent<Button>();
        newPlayBtn.onClick.AddListener(ResetAllDiamonds);
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

    private void ResetAllDiamonds()
    {
        PlayerPrefs.SetInt("Total Diamonds", 0); // dcm nhớ là cái total key khởi tạo ở bên diamond manager nhé thần đằng
        PlayerPrefs.Save();
        DiamondManager.Instance.ResetCurrentLevelDiamond();
        Debug.Log("All coins have been reset to 0");
    }
}
