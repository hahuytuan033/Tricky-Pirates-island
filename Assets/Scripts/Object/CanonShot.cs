using System.Collections;
using UnityEngine;

public class CanonShot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 2f;
    private Animator canonAnim;
    public int maxBullets = 5; // Giới hạn số lượng đạn
    private int bulletsShot = 0; // Biến đếm số lượng đạn đã bắn

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canonAnim = GetComponent<Animator>();
        StartCoroutine(AutoShoot());
    }

    IEnumerator AutoShoot()
    {
        yield return new WaitForSeconds(3f);

        while (bulletsShot < maxBullets)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            canonAnim.SetTrigger("ShootTrigger");
            // Đặt vận tốc theo hướng trái
            rb.linearVelocity = -firePoint.right * bulletSpeed; 
            bulletsShot++; // Tăng biến đếm số lượng đạn
            yield return new WaitForSeconds(0.5f);
        }
    }
}
