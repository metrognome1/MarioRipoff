﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    public Transform staffTip;
    public GameObject projectile;
    public float fireRate = 2f;
    public float projectileSpeed = 1f;

    EnemyAI determineDirection;


    void ProjectileAttack()
    {
        GameObject fireBall = Instantiate(projectile, staffTip.transform.position, Quaternion.identity) as GameObject;
        Rigidbody2D fBall_rg = fireBall.GetComponent<Rigidbody2D>();
        if (determineDirection.facingRight)
        {
            fBall_rg.velocity = new Vector3(projectileSpeed, 0, 0);
        }
        else
        {
            fBall_rg.velocity = new Vector3(projectileSpeed * -1, 0, 0);
        }
        
    }
	
	// Update is called once per frame
	void Start ()
    {
        determineDirection = GetComponent<EnemyAI>();
        

        InvokeRepeating("ProjectileAttack", .1f, fireRate);
	
	}
}
