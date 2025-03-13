using UnityEngine;
using UnityEngine.UI;

public class Level_3 : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public GameObject panel1;
    public GameObject volumeButton;
    public GameObject adsButton;
    public GameObject diamondPanel;
    public GameObject prefabToShow; // Prefab sẽ hiện lên khi nhấn Yes

    private void Start()
    {
        // Thêm sự kiện click cho các nút
        yesButton.onClick.AddListener(OnYesButtonClick);
        noButton.onClick.AddListener(OnNoButtonClick);

    }

    private void OnYesButtonClick()
    {
        // Ẩn panel 1
        panel1.SetActive(false);

        // Hiện panel 2
        volumeButton.SetActive(true);
        adsButton.SetActive(true);
        diamondPanel.SetActive(true);


        // Hiện prefab (chỉ khi nhấn Yes)
        if (prefabToShow != null)
        {
            prefabToShow.SetActive(true);
        }
    }

    private void OnNoButtonClick()
    {
        // Ẩn panel 1
        panel1.SetActive(false);

        // Hiện panel 2
        volumeButton.SetActive(true);
        adsButton.SetActive(true);
        diamondPanel.SetActive(true);
        // Không hiện prefab khi nhấn No
    }
}
