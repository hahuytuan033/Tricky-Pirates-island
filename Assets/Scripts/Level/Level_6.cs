using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ObjectMover : MonoBehaviour
{
    public GameObject objectA;  // Object A cần tắt
    public GameObject objectB;  // Object B cần bật
    //public Button yourButton;   // Button để gán trong Inspector

    // void Start()
    // {
    //     // Đảm bảo button được gán sự kiện click
    //     yourButton.onClick.AddListener(ToggleObjects);
    // }

    public void ToggleObjects()
    {
        // Tắt object A
        objectA.SetActive(false);
        // Bật object B
        objectB.SetActive(true);
    }
}