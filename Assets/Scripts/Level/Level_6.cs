using System.Collections;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [Header("Position of Ground in Game")]
    public Transform startPoint;
    public Transform endPoint;
    public Transform startHoriPoint;
    public Transform endHoriPoint;
    [Header("Objects in Game")]
    public GameObject movingObject;
    public GameObject keyPrefab;
    public GameObject ground;
    public GameObject groundHori;

    [Header("Move Settings")]
    public float moveSpeed = 1.0f;
    private Vector3 startPosition;
    private Vector3 endPosition;
    [SerializeField] private float timeToWait;

    void Start()
    {
        //cái wall dựng lên
        startPosition = startPoint.position;
        endPosition = endPoint.position;
        movingObject.transform.position = startPosition; // Đặt object vào vị trí startPoint

        // cái ground bay ngang ra
        groundHori.transform.position = startHoriPoint.position;
        StartCoroutine(MoveObject());
    }

    IEnumerator MoveObject()
    {
        yield return new WaitForSeconds(timeToWait);

        // Di chuyển object từ startPoint đến endPoint
        while (Vector3.Distance(movingObject.transform.position, endPosition) > 0.01f)
        {
            movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, endPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Giữ object tại endPoint trong 2 giây
        yield return new WaitForSeconds(2.0f);

        // Di chuyển object từ endPoint trở về startPoint
        while (Vector3.Distance(movingObject.transform.position, startPosition) > 0.01f)
        {
            movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position, startPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }

        // Xuất hiện keyPrefab khi movingObject trở lại startPoint
        Instantiate(keyPrefab, new Vector3(-2.95f, -2.23f, 0f), Quaternion.identity);
        ground.SetActive(true);

        // cái này lúc cái GroundHori chạy
        while (Vector3.Distance(groundHori.transform.position, endHoriPoint.position) > 0.01f)
        {
            groundHori.transform.position = Vector3.MoveTowards(groundHori.transform.position, endHoriPoint.position, moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
