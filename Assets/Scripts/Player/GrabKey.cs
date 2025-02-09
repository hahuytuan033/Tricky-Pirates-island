using UnityEngine;
using UnityEngine.InputSystem;

public class GrabKey : MonoBehaviour
{
    [SerializeField] private Transform grabPoint;
    [SerializeField] private Transform rayPoint;
    [SerializeField] private float rayDistance;
    private GameObject grabKey;
    private int layerIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Key");
    }

    // Update is called once per frame
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
                grabKey.GetComponent<Animator>().enabled = false;
                grabKey.transform.position = grabPoint.position;
                grabKey.transform.SetParent(transform);
            }
            else if (grabKey != null)
            {
                // Release key
                grabKey.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabKey.GetComponent<Animator>().enabled = true;
                grabKey.transform.SetParent(null);
                grabKey = null;
            }
        }
    }
}