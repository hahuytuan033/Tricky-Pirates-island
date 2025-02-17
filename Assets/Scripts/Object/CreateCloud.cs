using UnityEngine;

public class CreateCloud : MonoBehaviour
{
    public CloudPool cloudPool; //khai báo pool
    public Transform startPoint; //điểm bắt đầu
    public float cloudSpeed; //tốc độ của cloud


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Create();
    }

    // void Create()
    // {
    //     // GameObject cloud = cloudPool.GetCloud(); //lấy object từ pool
    //     cloud.transform.position= startPoint.position; //đặt vị trí của cloud
    //     Rigidbody2D rb= cloud.GetComponent<Rigidbody2D>(); //lấy rigidbody của cloud
    //     rb.linearVelocity = startPoint.right * cloudSpeed; //đặt vận tốc cho cloud
    // }
}
