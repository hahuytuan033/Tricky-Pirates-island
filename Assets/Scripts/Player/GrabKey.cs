using UnityEngine;
using UnityEngine.InputSystem;

public class GrabKey : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    private GameObject grabKey;
    private int layerIndex;
    private Animator keyAnimator;
    

    private void Awake()
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Key");
    }

    // Update is called once per frame
    [System.Obsolete]

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (grabKey == null && collision.gameObject.layer == layerIndex)
        {
            // Nhặt chìa khóa
            grabKey = collision.gameObject;
            grabKey.GetComponent<Rigidbody2D>().isKinematic = true;
            grabKey.transform.rotation = Quaternion.Euler(180, 0, 90);
            grabKey.transform.position = grabPoint.position;
            grabKey.transform.SetParent(transform);
          

            // Lấy Animator component
            keyAnimator = grabKey.GetComponent<Animator>();
            keyAnimator.SetBool("isGrabbing", true);
        }
    }
}