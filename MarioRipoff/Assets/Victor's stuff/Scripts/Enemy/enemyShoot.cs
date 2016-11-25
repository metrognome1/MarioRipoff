using UnityEngine;
using System.Collections;

public class enemyShoot : MonoBehaviour {
    public GameObject projectile;
    public float projectileSpeed;
    public int projLifetime;
    public float fireDelay;

    enemyBody enemy;
    private Rigidbody2D projectileRigid;
    private Transform firePoint;



    void Awake() {
        enemy = gameObject.GetComponent<enemyBody>();
        firePoint = transform.FindChild("firePoint");
        if (firePoint == null) {
            Debug.LogError("No firePoint location");
        }
    }

    void Start() {
        StartCoroutine(makeProjectile(fireDelay, enemy));
    }

    IEnumerator makeProjectile(float fireDelay, enemyBody enemy) {
        while (true) {
            yield return new WaitForSeconds(fireDelay);
            GameObject shot = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
            projectileRigid = shot.GetComponent<Rigidbody2D>();
            if (enemy.facingRight == false)
                projectileRigid.AddForce(Vector2.left * projectileSpeed);

            else if (enemy.facingRight == true)
                projectileRigid.AddForce(Vector2.right * projectileSpeed);

            StartCoroutine(destroyRoutine(projLifetime, shot));
        }
    }

    IEnumerator destroyRoutine(float lifetime, GameObject projectile) {
        yield return new WaitForSeconds(lifetime);
        Destroy(projectile, lifetime);
    }
}
