using UnityEngine;

public class Level_1 : MonoBehaviour
{
    private int keyLayer;
    private int chestLayer;
    private Animator chestAnimator;

    void Start()
    {
        keyLayer = LayerMask.NameToLayer("Key");
        chestLayer = LayerMask.NameToLayer("Chest");

        // Lấy Animator của chest và tắt nó
        chestAnimator = GetComponent<Animator>();
        if (chestAnimator != null)
        {
            chestAnimator.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.layer == chestLayer && collision.gameObject.layer == keyLayer)
        {
            Debug.Log("You Win");

            // Bật Animator của chest
            if (chestAnimator != null)
            {
                chestAnimator.enabled = true;
            }
        }
    }
}
