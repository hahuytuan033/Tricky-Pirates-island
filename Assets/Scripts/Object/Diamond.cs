using UnityEngine;

public class Diamond : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            DiamondManager.Instance.AddDiamond(5);
            Destroy(gameObject);
        }
    }
}
