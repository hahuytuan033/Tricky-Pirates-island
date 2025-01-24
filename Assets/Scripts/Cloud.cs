using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float floatStrength = 0.5f;
    public float floatDistance = 0.5f;
    public float floatSpeed = 2.0f; // horizontal movement speed

    private Vector3 startPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPosition.y + Mathf.Sin(Time.time) * floatDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        transform.position += Vector3.right * Time.deltaTime * floatSpeed;
    }
}
