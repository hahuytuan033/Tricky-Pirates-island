using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    public Vector3 newCamPos, newPlayerPos;

    CamControls camControl;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camControl = Camera.main.GetComponent<CamControls>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            camControl.minPos += newCamPos;
            camControl.maxPos += newCamPos;
            
            collision.transform.position += newPlayerPos;
        }
    }

}
