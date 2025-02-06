using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 5f;
    public Vector2 startPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPosition + Vector2.left * newPosition;
    }
}
