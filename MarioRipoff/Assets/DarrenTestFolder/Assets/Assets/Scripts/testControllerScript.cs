using UnityEngine;
using System.Collections;

public class testControllerScript : MonoBehaviour {
    public float maxSpeed = 6f;
    public bool facingRight = true;
    Animator anim;
    Rigidbody2D rBody;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;

    //public float jumpForce = 500f;
    public float jumpHeld = 0.0f;
    public float fullJumpTime = 0.8f;
    public float minJump = 0.2f;
    public float maxJump = 0.8f;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rBody = GetComponent<Rigidbody2D>();

    }
	
	void FixedUpdate () {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("Speed", rBody.velocity.y);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));
        
    }
    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rBody.velocity = new Vector2(move * maxSpeed, rBody.velocity.y);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rBody.velocity = new Vector2(move * maxSpeed, rBody.velocity.y);
        }
        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("Ground", false);
            jumpHeld = 0.01f;
            rBody.AddForce(new Vector2(0, maxJump), ForceMode2D.Impulse);
            //jump();
        }
        if (Input.GetKey(KeyCode.Space))
        {
            jumpHeld += Time.deltaTime;
            if (jumpHeld < fullJumpTime)
                jump();
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumpHeld = 0f;
        }
    }
    void jump()
    {
        float jumping = maxJump - jumpHeld;
        rBody.AddForce(new Vector2(0, jumping), ForceMode2D.Impulse);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
