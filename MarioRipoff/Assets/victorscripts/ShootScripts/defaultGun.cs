using UnityEngine;
using System.Collections;

public class defaultGun : MonoBehaviour, IShootable {
    public float fireRate = 0;
    public GameObject projectile;
    public float projectileSpeed;

    private float timeToFire = 0;
    private Transform firePoint;

    void Awake() {
        firePoint = transform.FindChild("firePoint");
        if (firePoint == null) {
            Debug.LogError("No firePoint location");
        }
    }

    public void Shoot(Vector2 direction) {
        if (fireRate == 0) {
            Debug.Log("Entered shoot");
            makeProjectile(direction);

        }
        else {
            if (Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                makeProjectile(direction);
            }
        }

    }

    void makeProjectile(Vector2 direction) {
        GameObject shot = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D shot_rg = shot.GetComponent<Rigidbody2D>();
        shot_rg.velocity = direction * projectileSpeed;
    }
}