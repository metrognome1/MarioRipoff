using UnityEngine;
using System.Collections;

public class MeleeAI : MonoBehaviour {
    Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    public bool CanMove = true;
    public bool facingRight = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }


    void FixedUpdate()
    {
        if (CanMove == true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }


        if (facingRight == true)
        {
            transform.localScale = new Vector3(.15f, .15f , .15f);
        }
        else if (facingRight == false)
        {
            transform.localScale = new Vector3(-.15f, .15f, .15f);
        }

        float xDifference = target.position.x - transform.position.x;


        if (xDifference > 0)
        {
            if (CanMove)
            {
                rb.MovePosition(transform.position + Vector3.right * Time.deltaTime);
                facingRight = true;
               // print("moving right");
            }
        }
        else if (xDifference < 0)
        {
            if (CanMove)
            {

                rb.MovePosition(transform.position + Vector3.left * Time.deltaTime);
                facingRight = false;
             //   print("Moving left");
                
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "mEnemyDistance")
        {
            CanMove = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "mEnemyDistance")
        {
            CanMove = true;
        }
    }


}
