using UnityEngine;

public class Clouds : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<CloudPool>().ReturnCloud(gameObject);
    }
}
