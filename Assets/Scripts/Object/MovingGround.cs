using UnityEngine;

public class MovingGround : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    [SerializeField] private float speed;
    
    //private int direction = 1;
    private Vector2 currentTarget;

    private void Start()
    {
        currentTarget = endPoint.position;
    }

    private void Update()
    {
        platform.position = Vector2.Lerp(platform.position, currentTarget, speed * Time.deltaTime);

        float distance = ((Vector2)currentTarget - (Vector2)platform.position).magnitude;
        if (distance <= 0.1f)
        {
            // Chuyển đổi target khi platform đến gần điểm đích
            currentTarget = (currentTarget == (Vector2)endPoint.position) ? 
                          startPoint.position : endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
}
