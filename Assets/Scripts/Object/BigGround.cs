using UnityEngine;

public class BigGround : MonoBehaviour
{
    public GameObject Player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Check")
        {
            if (Player != null)
            {
                Player.transform.localScale = new Vector3(1, 1, 1);
                Player.GetComponent<PlayerManager>().groundCheck = 1f;
            }
        }
    }
}
