using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGameLv1 : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
