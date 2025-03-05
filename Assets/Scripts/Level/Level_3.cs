using UnityEngine;
using UnityEngine.UI;

public class Level_3 : MonoBehaviour
{
    public Button yesButton;
    public Button noButton;
    public GameObject panel1;
    public GameObject volume;
    public GameObject prefabToShow; // Prefab sẽ hiện lên khi nhấn Yes

    private void Start()
    {
        // Thêm sự kiện click cho các nút
        yesButton.onClick.AddListener(OnYesButtonClick);
        noButton.onClick.AddListener(OnNoButtonClick);

        // // Đảm bảo trạng thái ban đầu
        // panel1.SetActive(true);
        // panel2.SetActive(false);
        // if (prefabToShow != null)
        // {
        //     prefabToShow.SetActive(false);
        // }
    }

    private void OnYesButtonClick()
    {
        // Ẩn panel 1
        panel1.SetActive(false);

        // Hiện panel 2
        volume.SetActive(true);

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
        volume.SetActive(true);
        // Không hiện prefab khi nhấn No
    }
}
