using System.Collections.Generic;
using UnityEngine;

public class CloudPool : MonoBehaviour
{
    [SerializeField] private GameObject[] cloudPrefabs;
    [SerializeField] private int poolSize = 10;
    private List<Queue<GameObject>> cloudPools;

    private void Awake()
    {
        cloudPools = new List<Queue<GameObject>>();

        // Khởi tạo pool cho mỗi loại cloud
        for (int i = 0; i < cloudPrefabs.Length; i++)
        {
            Queue<GameObject> pool = new Queue<GameObject>();
            for (int j = 0; j < poolSize; j++)
            {
                GameObject cloud = Instantiate(cloudPrefabs[i]);
                cloud.SetActive(false);
                pool.Enqueue(cloud);
            }
            cloudPools.Add(pool);
        }
    }

    public GameObject GetCloud(int index)
    {
        if (cloudPools[index].Count > 0)
        {
            GameObject cloud = cloudPools[index].Dequeue();
            cloud.SetActive(true);
            return cloud;
        }
        return Instantiate(cloudPrefabs[index]);
    }

    public void ReturnCloud(GameObject cloud)
    {
        cloud.SetActive(false);
        for (int i = 0; i < cloudPrefabs.Length; i++)
        {
            if (cloud.name.StartsWith(cloudPrefabs[i].name))
            {
                cloudPools[i].Enqueue(cloud);
                break;
            }
        }
    }
}