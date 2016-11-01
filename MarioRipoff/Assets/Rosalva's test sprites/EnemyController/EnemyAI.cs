using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    Transform target;
    private Rigidbody2D rb;
    public bool CanMove = true;
    public bool facingRight = false;
	
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Target").transform;
    }
	
	
	void FixedUpdate ()
    {
        if (facingRight == true)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(facingRight==false)
        {
          transform.localScale = new Vector3(-1, 1, 1);
        }

        float xDifference = target.position.x - transform.position.x;


        if (xDifference > 0)
        {
            if (CanMove)
            {
                rb.MovePosition(transform.position + Vector3.right * Time.deltaTime);
                facingRight = true;
            }
        }
        else if (xDifference < 0)
        {
            if (CanMove)
            {

                rb.MovePosition(transform.position + Vector3.left * Time.deltaTime);
                facingRight = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "pEnemyDistance")
        {
            CanMove = false;
        }
    }

    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "pEnemyDistance")
        {
            CanMove = true;
        }
    }


}
