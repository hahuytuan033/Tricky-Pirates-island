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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Key");
    }

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayPoint.right, rayDistance);

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (grabKey == null && hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
            {
                // Grab key
                grabKey = hitInfo.collider.gameObject;
                grabKey.GetComponent<Rigidbody2D>().isKinematic = true;
                grabKey.transform.rotation = Quaternion.Euler(180, 0, 90);
                grabKey.transform.position = grabPoint.position;
                grabKey.transform.SetParent(transform);

                // Get the animator component
                keyAnimator = grabKey.GetComponent<Animator>();
                keyAnimator.SetBool("isGrabbing", true);

            }
            else if (grabKey != null)
            {
                // Release key
                grabKey.GetComponent<Rigidbody2D>().isKinematic = false;
                grabKey.transform.rotation = Quaternion.Euler(0, 0, 0);
                grabKey.transform.SetParent(null);

                //Set animation to idle
                keyAnimator.SetBool("isGrabbing", false);
                grabKey = null;
            }
        }
    }
}