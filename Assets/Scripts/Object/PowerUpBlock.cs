using UnityEngine;

[RequireComponent(typeof(PolygonCollider2D))]

public class PowerUpBlock : MonoBehaviour
{
    [SerializeField] private Sprite _inactiveSprite;
    [SerializeField] private GameObject _powerUp;
    

    private void Awake()
    {
       
    }

    private bool _used;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerManager>();
        if (!_used && player != null && collision.contacts[0].normal.y > 0)
        {
            GetComponent<SpriteRenderer>().sprite = _inactiveSprite;
            Instantiate(_powerUp, transform.position, Quaternion.identity);
            _used = true; // Set _used to true to prevent creating more _powerUp
        }
    }
}
