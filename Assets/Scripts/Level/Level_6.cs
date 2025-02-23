using UnityEngine;
using System.Collections;

public class Level_6 : MonoBehaviour
{
    public GameObject Ground;
    [SerializeField] private Transform pointStart;
    [SerializeField] private Transform pointEnd;

    private void Start()
    {
        StartCoroutine(MoveGround());
    }

    private IEnumerator MoveGround()
    {
        // Delay 7 giây trước khi bắt đầu di chuyển
        yield return new WaitForSeconds(7f);

        while (true)
        {
            yield return MoveToPosition(pointStart.position, pointEnd.position, 1f);
            yield return new WaitForSeconds(4f);
            yield return MoveToPosition(pointEnd.position, pointStart.position, 1f);
        }
    }

    private IEnumerator MoveToPosition(Vector3 startPosition, Vector3 endPosition, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            Ground.transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        Ground.transform.position = endPosition;
    }
}