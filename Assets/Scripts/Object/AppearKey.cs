using UnityEngine;
using System.Collections;

public class AppearKey : MonoBehaviour
{
    [SerializeField] private GameObject keyPrefab; // Reference to the key prefab
    [SerializeField] private Transform spawnPoint; // Optional: Point where key will spawn
    [SerializeField] private float spawnDelay = 0.5f; // Delay time in seconds
    private bool hasSpawned = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!hasSpawned && other.CompareTag("Player"))
        {
            hasSpawned = true;
            StartCoroutine(SpawnKeyWithDelay());
        }
    }

    private IEnumerator SpawnKeyWithDelay()
    {
        yield return new WaitForSeconds(spawnDelay);
        
        if (keyPrefab != null)
        {
            Vector3 spawnPosition = spawnPoint != null ? spawnPoint.position : transform.position;
            Instantiate(keyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
