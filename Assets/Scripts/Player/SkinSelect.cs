using UnityEngine;

public class SkinSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedSkin;

    private void Awake()
    {
        selectedSkin = PlayerPrefs.GetInt("SlectedSkin", 0);
        foreach (GameObject player in skins)
        {
            player.SetActive(false);
        }
        skins[selectedSkin].SetActive(true);
    }
}
