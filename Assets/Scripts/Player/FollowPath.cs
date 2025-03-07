using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float speed = 2f;
    private int pointsIndex;

    void Start()
    {
        transform.position = points[pointsIndex].transform.position;
    }

    void Update()
    {
        if (pointsIndex <= points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position,
                                                    points[pointsIndex].transform.position,
                                                    speed * Time.deltaTime);
            if (transform.position == points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            // để cho nó thành vòng lặp nếu cần
            // if (pointsIndex == points.Length)
            // {
            //     pointsIndex = 0;
            // }
        }
    }
}
