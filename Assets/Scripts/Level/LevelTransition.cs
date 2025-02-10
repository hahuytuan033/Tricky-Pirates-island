using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
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

            // Bắt đầu coroutine để chuyển sang scene tiếp theo
            StartCoroutine(LoadNextSceneAfterDelay(1f));
        }
    }

    private IEnumerator LoadNextSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Thay đổi chỉ số scene tiếp theo theo nhu cầu của bạn
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
