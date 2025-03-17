using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int keyLayer;
    private int chestLayer;
    private Animator chestAnimator;
    public Animator SceneTransition;

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

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

            // Phát âm thanh win
            audioManager.PlaySFX(audioManager.winMusic);
            // Bật Animator của chest
            if (chestAnimator != null)
            {
                chestAnimator.enabled = true;
            }
            UnlockNewLevel();
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

    void UnlockNewLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex >= PlayerPrefs.GetInt("LevelsUnlocked"))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", currentSceneIndex + 1);
        }
    }
}
