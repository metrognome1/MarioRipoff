using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public Transform Guntip;
    public GameObject projectile;
    public float fireRate = 2f;


    public float projectileSpeed = 2f;
    public AudioClip gunShot;



    EnemyAI determineDirection;
    private Animator anim;


    void ProjectileAttack()
    {
        GameObject fireBall = Instantiate(projectile, Guntip.transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D fBall_rg = fireBall.GetComponent<Rigidbody2D>();
        if (determineDirection.facingRight)
        {
            fBall_rg.velocity = new Vector3(projectileSpeed, 0, 0);
        }
        else
        {
            fBall_rg.velocity = new Vector3(projectileSpeed * -1, 0, 0);
        }
        Destroy(fireBall, 3);


        AudioSource.PlayClipAtPoint(gunShot, Guntip.position);

    }
	

	void Start ()
    {
        anim = GetComponent<Animator>();
        // anim.setbool("isShooting", true)
        determineDirection = GetComponent<EnemyAI>();

        InvokeRepeating("Fire", .000001f, fireRate);
        
	}


    void Fire()
    {

        if (determineDirection.CanMove == false)
        {
            ProjectileAttack();
        }

    }




}
