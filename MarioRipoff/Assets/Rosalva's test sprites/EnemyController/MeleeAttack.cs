using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour
{

    MeleeAI canAttack;
    float attackRate = 5;
    public AudioClip kick;

    private Animator anim;



    void Start()
    {
        anim = GetComponent<Animator>();
        canAttack = GetComponent<MeleeAI>();
        InvokeRepeating("DoAttack", .000001f, attackRate);
    }

    void DoAttack()
    {
        //transform.position = transform.position + Vector3.down;
        if (canAttack.CanMove == false)
        {
           // transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("Attacking", true);
           // AudioSource.PlayClipAtPoint(kick, transform.position);
        }
    }

    void Update()
    {
        if (canAttack.CanMove == true)
        {
            anim.SetBool("Attacking", false);
        }
    }

}



