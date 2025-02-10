using UnityEngine;
using UnityEngine.InputSystem;

public class GrabKey : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    private GameObject grabKey;
    private int layerIndex;

    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Key");
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayPoint.right, rayDistance);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (grabKey == null && hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
            {
                // Grab key
                grabKey = hitInfo.collider.gameObject;
                grabKey.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabKey.GetComponent<Collider2D>().isTrigger = true;
                grabKey.transform.rotation = Quaternion.Euler(180, 0, 90);
                grabKey.transform.position = grabPoint.position;
                grabKey.transform.SetParent(transform);
            }
            else if (grabKey != null)
            {
                // Release key
                grabKey.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabKey.GetComponent<Collider2D>().isTrigger = false; 
                grabKey.transform.SetParent(null);
                grabKey.transform.rotation = Quaternion.Euler(0, 0, 0);
                grabKey = null;
            }
        }
    }
}
