using UnityEngine;
using UnityEngine.SceneManagement;

public class CollectDiamondLevel : MonoBehaviour
{
    public int currentLevel = 1;
    public void CompleteLevel()
    {
        DiamondManager.Instance.SaveLevelDiamonds(currentLevel);
        currentLevel++;
        SceneManager.LoadScene("Level"+ currentLevel);
    }

    public void ResetLevel()
    {
        DiamondManager.Instance.ResetCurrentLevelDiamond();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
