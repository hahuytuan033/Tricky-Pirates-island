using UnityEngine;

public class Level_4 : MonoBehaviour, ICustomDrag
{
    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnCurrentDrag()
    {
        rectTransform.position = Input.mousePosition;  
    }
}
