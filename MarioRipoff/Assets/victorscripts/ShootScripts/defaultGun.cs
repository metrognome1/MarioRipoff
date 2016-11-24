using UnityEngine;
using System.Collections;

public class defaultGun : MonoBehaviour, IShootable {
    public float fireRate = 0;
    public GameObject projectile;
    public float projectileSpeed;
    public int clipSize = 10;
    public int ammoLifetime;

    private GameObject[] ammoClip;
    private Rigidbody2D[] ammo_rg;
    private float timeToFire = 0;
    private Transform firePoint;
    private int ammoIndex;


    void Awake() {
        ammoClip = new GameObject[clipSize];
        ammo_rg = new Rigidbody2D[clipSize];
        firePoint = transform.FindChild("firePoint");
        ammoIndex = 0;
        if (firePoint == null) {
            Debug.LogError("No firePoint location");
        }
    }

    public void Shoot(Vector2 direction) {
        if (fireRate == 0) {
            makeProjectile(direction);

        }
        else {
            if (Time.time > timeToFire) {
                timeToFire = Time.time + 1 / fireRate;
                makeProjectile(direction);
            }
        }

    }

    //This version of makeProjectile makes bullets until it fills the ammoClip
    //After that point it just calls sets them active. 
    void makeProjectile(Vector2 direction) {
        //Checks if the ammo clip is full or not
        if (ammoClip[ammoIndex] == null) {
            GameObject shot = Instantiate(projectile, firePoint.transform.position, Quaternion.identity) as GameObject;
            Rigidbody2D shot_rg = shot.GetComponent<Rigidbody2D>();
            ammoClip[ammoIndex] = shot;
            ammo_rg[ammoIndex] = shot_rg;
        }
        else {
            ammoClip[ammoIndex].transform.position = firePoint.transform.position;
            ammoClip[ammoIndex].SetActive(true);
        }
        //Deactivates ammoType after ammoLifetime
        StartCoroutine(DeactivateRoutine(ammoLifetime, ammoClip[ammoIndex]));
        ammo_rg[ammoIndex].velocity = direction * projectileSpeed;
        ammoIndex = (ammoIndex + 1) % clipSize;
    }

    //A coroutine to deactivate ammmo after certain amount of time
    IEnumerator DeactivateRoutine(int delay, GameObject ammoType) {
        yield return new WaitForSeconds(delay);
        ammoType.SetActive(false);
    }

}