using UnityEngine;

public class DiamondManager : MonoBehaviour
{
    // quản lý số lượng diamond
    public static DiamondManager Instance { get; private set; }

    private int currentLevelDiamonds = 0; // số diamond thu thập được trong level hiện tại đang chơi
    private const string TOTAL_DIAMONDS_KEY = "Total Diamonds"; // cái lày là key để lưu tổng diamond

    private void Awake()
    {
        // dùng singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // hàm này để thêm diamond vào số lượng tạm thời của level đang chơi hiện tại ấy
    public void AddDiamond(int amount)
    {
        currentLevelDiamonds += amount;
        Debug.Log($"Dimond hiện tại là: {currentLevelDiamonds}");
    }

    // khi nào qua màn thì mới được lưu số Diamond kiếm được
    public void SaveLevelDiamonds(int levelNumber)
    {
        int totalDiamonds = PlayerPrefs.GetInt(TOTAL_DIAMONDS_KEY, 0);
        totalDiamonds += currentLevelDiamonds;
        PlayerPrefs.SetInt(TOTAL_DIAMONDS_KEY, totalDiamonds);
        PlayerPrefs.Save();
        Debug.Log($"Level {levelNumber} bú được {totalDiamonds}");
        ResetCurrentLevelDiamond();
    }

    // Reset số Diamond hiện tại đã kiếm được ở level đó khi level đó được restart game
    public void ResetCurrentLevelDiamond()
    {
        currentLevelDiamonds = 0;
    }

    // tổng số Diamond đã lưu
    public int GetTotalDiamond()
    {
        return PlayerPrefs.GetInt(TOTAL_DIAMONDS_KEY, 0);
    }
}
