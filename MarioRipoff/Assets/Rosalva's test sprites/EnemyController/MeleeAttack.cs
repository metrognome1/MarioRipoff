using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{
    private float startingX;
    private float rightX;

    MeleeAI canAttack;
    public AudioClip kick;

    private float attackTimer = 0;

    private bool isAttacking;

  
     
         



    void Start()
    {
        canAttack = GetComponent<MeleeAI>();
    }

    void FixedUpdate()
    {
        if (isAttacking == true)
        { attackTimer += Time.fixedDeltaTime; }
        print("AttackTimer: " + attackTimer);
        DoAttack();
    }

    void DoAttack()
    {
        if (attackTimer > 1.5f && canAttack.CanMove == false)
        {
            attackTimer = 0f;
            print("DamageEnemy");

        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        attackTimer = 0;
        
    }

    void OnTriggerStay2D(Collider2D coll)
    {

        if (coll.gameObject.tag == "mEnemyDistance")
        {
            isAttacking = true;
            attackTimer += Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        isAttacking = false;
    }


}



