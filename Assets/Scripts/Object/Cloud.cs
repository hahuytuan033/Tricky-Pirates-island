using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float _speed;
    private float _endPosX;
    private CloudPool cloudPool;

    private void Awake()
    {
        cloudPool = FindFirstObjectByType<CloudPool>();
    }

    public void StartFloating(float speed, float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * _speed));
        if (transform.position.x > _endPosX)
        {
            cloudPool.ReturnCloud(gameObject);
        }
    }
}