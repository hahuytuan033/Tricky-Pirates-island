 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int keyLayer;
    private int chestLayer;
    private Animator chestAnimator;
    public Animator SceneTransition;

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
            StartCoroutine(LoadNextLevel(1f));
        }
    }

    private IEnumerator LoadNextLevel(float delay)
    {
        SceneTransition.SetTrigger("Start");

        yield return new WaitForSeconds(delay);

        // Thay đổi chỉ số scene tiếp theo
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
}
