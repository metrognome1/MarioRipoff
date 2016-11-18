using UnityEngine;
using System.Collections;

public class Controller_test: MonoBehaviour {
    public float Speed = 6f;
    bool facingRight = true;
    public float jumpForce = 10f;
    float jumpTime = 0f;
    
    Rigidbody2D rbody;

    // Use this for initialization
    void Start () {
        rbody = GetComponent<Rigidbody2D>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveHorizontal = Input.GetAxis("Horizontal");
        rbody.velocity = new Vector2(moveHorizontal * Speed, rbody.velocity.y);
        if (moveHorizontal > 0 && !facingRight)
            Flip();
        else if (moveHorizontal < 0 && facingRight)
            Flip();
    }
    void Update()
    {
        if (jumpTime == 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                rbody.AddForce(Vector2.up * jumpForce);
                jumpTime = 10;
            }
        }
        else if (jumpTime > 0)
        {
            jumpTime-=Time.deltaTime;
        }
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
