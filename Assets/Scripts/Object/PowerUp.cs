using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PowerUp : MonoBehaviour
{
    [SerializeField] private Vector2 _initialVeclocity;
    [SerializeField] float _reenableColliderAfter;
    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _collider2D = GetComponent<Collider2D>();
        _collider2D.enabled = false;
        _rigidbody2D.linearVelocity = _initialVeclocity;
        StartCoroutine(ReenableCollider());
    }

    private IEnumerator ReenableCollider()
    {
        yield return new WaitForSeconds(_reenableColliderAfter);
        _collider2D.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var player = collision.gameObject.GetComponent<PlayerManager>();
        if (player != null)
        {
            audioManager.PlaySFX(audioManager.powerDown);
            Destroy(gameObject);
        }
    }
}
