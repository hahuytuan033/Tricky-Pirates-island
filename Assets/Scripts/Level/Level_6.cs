using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMover : MonoBehaviour
{
    public GameObject[] objs;      // Mảng các object cần destroy
    public GameObject hiddenObj;   // Object sẽ hiển thị
    public Button adsButton;       // Button UI để trigger

    void Start()
    {
        // Đảm bảo hiddenObj ẩn khi bắt đầu
        if (hiddenObj != null)
        {
            hiddenObj.SetActive(false);
        }
        else
        {
            Debug.LogError("HiddenObj is not assigned in the Inspector!");
        }

        // Kiểm tra và gắn sự kiện cho button
        if (adsButton != null)
        {
            adsButton.onClick.RemoveAllListeners(); // Xóa các listener cũ nếu có
            adsButton.onClick.AddListener(HiddenKey);
            Debug.Log("Button listener added successfully");
        }
        else
        {
            Debug.LogError("AdsButton is not assigned in the Inspector!");
        }

        // Kiểm tra mảng objs
        if (objs == null || objs.Length == 0)
        {
            Debug.LogError("Objs array is empty or not assigned in the Inspector!");
        }
    }

    public void HiddenKey()
    {
        Debug.Log("HiddenKey function called"); // Debug để kiểm tra hàm có chạy không
        
        // Destroy tất cả object trong mảng
        int destroyedCount = 0;
        foreach (GameObject obj in objs)
        {
            if (obj != null)
            {
                Destroy(obj);
                destroyedCount++;
                Debug.Log($"Destroyed object: {obj.name}");
            }
        }
        Debug.Log($"Total objects destroyed: {destroyedCount}");

        // Hiển thị hiddenObj
        if (hiddenObj != null)
        {
            hiddenObj.SetActive(true);
            Debug.Log("Hidden object activated");
        }
    }

    void OnDestroy()
    {
        if (adsButton != null)
        {
            adsButton.onClick.RemoveListener(HiddenKey);
            Debug.Log("Button listener removed");
        }
    }
}