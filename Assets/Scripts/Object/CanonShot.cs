using System.Collections;
using UnityEngine;

public class CanonShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        yield return new WaitForSeconds(3f);

        while (true)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            // Đặt vận tốc theo hướng trái
            rb.linearVelocity = -firePoint.right * bulletSpeed; 
            yield return new WaitForSeconds(0.5f);
        }
    }
}
