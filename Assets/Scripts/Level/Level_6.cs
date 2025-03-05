using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMover : MonoBehaviour
{
    // Mảng chứa các GameObject cha (mỗi cha có thể chứa GO con)
    public GameObject[] parentObjects;
    
    // Button để kích hoạt việc xóa
    public Button destroyButton;

    void Start()
    {
        // Gán sự kiện click cho button
        if (destroyButton != null)
        {
            destroyButton.onClick.AddListener(OnButtonClick);
            Debug.Log("Button event listener added successfully");
        }
        else
        {
            Debug.LogError("Destroy Button is not assigned in Inspector!");
        }

        // Kiểm tra mảng parentObjects
        if (parentObjects == null || parentObjects.Length == 0)
        {
            Debug.LogError("Parent Objects array is empty or not assigned!");
        }
    }

    void OnButtonClick()
    {
        Debug.Log("Button clicked!");

        // Duyệt qua từng GameObject cha trong mảng
        foreach (GameObject parent in parentObjects)
        {
            if (parent != null)
            {
                Debug.Log($"Destroying parent object: {parent.name}");
                // Destroy GameObject cha sẽ tự động destroy tất cả các GO con bên trong
                Destroy(parent);
            }
            else
            {
                Debug.LogWarning("Found a null object in parentObjects array");
            }
        }
    }
}