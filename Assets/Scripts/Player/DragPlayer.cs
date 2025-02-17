using UnityEngine;

public class DragPlayer : MonoBehaviour
{
    private Vector2 difference = Vector2.zero;
    private bool canDrag = true;
    void Update()
    {
        if (transform.position.x >= 10)
        {
            canDrag = false;
        }
    }

    private void OnMouseDown()
    {
        if (!canDrag) return;
        difference = (Vector2)transform.position - (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDrag()
    {
        if (!canDrag) return;
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) + difference;
    }
}
