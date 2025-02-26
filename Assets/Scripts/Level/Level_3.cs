using UnityEngine;

public class Level_3 : MonoBehaviour
{
   public GameObject objectToHide;
    public GameObject objectToShow;

    public void OnButtonClick()
    {
        objectToHide.SetActive(false);
        objectToShow.SetActive(true);
    }
}
