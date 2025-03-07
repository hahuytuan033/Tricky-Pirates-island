using System.Collections;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Moving Objects")]
    public GameObject[] objectsToMove; // Mảng chứa 7 objects cần di chuyển

    [Header("Target Positions")]
    public Transform[] targetPositions; // Mảng chứa 7 vị trí đích

    [Header("Key Object")]
    public GameObject objectB;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    private bool isMoving = false;
    private Vector3[] originalPositions; // Lưu vị trí ban đầu của các objects

    void Start()
    {
        // Khởi tạo mảng vị trí gốc
        originalPositions = new Vector3[objectsToMove.Length];
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            if (objectsToMove[i] != null)
            {
                originalPositions[i] = objectsToMove[i].transform.position;
            }
        }
    }

    public void ToggleObjects()
    {
        // Kích hoạt objectB
        if (objectB != null)
            objectB.SetActive(true);

        // Bắt đầu di chuyển tất cả objects nếu chưa di chuyển
        if (!isMoving)
        {
            StartCoroutine(MoveObjects());
        }
    }

    private IEnumerator MoveObjects()
    {
        isMoving = true;

        // Di chuyển từng object đến vị trí đích tương ứng
        while (true)
        {
            bool allReached = true;

            for (int i = 0; i < objectsToMove.Length; i++)
            {
                if (objectsToMove[i] != null && targetPositions[i] != null)
                {
                    // Di chuyển object đến target position
                    Vector3 targetPos = targetPositions[i].position;
                    objectsToMove[i].transform.position = Vector3.MoveTowards(
                        objectsToMove[i].transform.position,
                        targetPos,
                        moveSpeed * Time.deltaTime
                    );

                    // Kiểm tra xem object đã đến đích chưa
                    if (Vector3.Distance(objectsToMove[i].transform.position, targetPos) > 0.01f)
                    {
                        allReached = false;
                    }
                }
            }

            // Nếu tất cả objects đã đến đích thì dừng
            if (allReached)
            {
                break;
            }

            yield return null;
        }

        isMoving = false;
    }

    // Phương thức để reset về vị trí ban đầu (tùy chọn)
    public void ResetPositions()
    {
        for (int i = 0; i < objectsToMove.Length; i++)
        {
            if (objectsToMove[i] != null)
            {
                objectsToMove[i].transform.position = originalPositions[i];
            }
        }
    }
}