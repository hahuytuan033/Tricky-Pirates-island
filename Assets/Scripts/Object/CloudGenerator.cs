using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    [SerializeField] private CloudPool cloudPool;
    [SerializeField] private float spawnInterval;
    [SerializeField] private GameObject endPoint;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
        Prewarm();
        Invoke("AttemptSpawn", spawnInterval);
    }

    void SpawnCloud(Vector3 startPos)
    {
        int randomIndex = Random.Range(0, 3);
        GameObject cloud = cloudPool.GetCloud(randomIndex);

        float startY = Random.Range(startPos.y - 1f, startPos.y + 1f);
        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float scale = Random.Range(0.8f, 1.2f);
        cloud.transform.localScale = new Vector2(scale, scale);

        float speed = Random.Range(0.5f, 1.5f);
        cloud.GetComponent<Cloud>().StartFloating(speed, endPoint.transform.position.x);
    }

    void AttemptSpawn()
    {
        SpawnCloud(startPos);
        Invoke("AttemptSpawn", spawnInterval);
    }

    void Prewarm()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            SpawnCloud(spawnPos);
        }
    }
}