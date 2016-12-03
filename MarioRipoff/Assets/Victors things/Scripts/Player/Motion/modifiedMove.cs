using UnityEngine;
using System.Collections;

public class modifiedMove : MonoBehaviour {
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
    public float extendJump = 70;

	// Use this for initialization
	void Start () {
        jumpHeld = 0.01f;
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
        if (move > 0)
        {
            rBody.velocity = new Vector2(move * maxSpeed, rBody.velocity.y);
        }
        if (move < 0)
        {
            rBody.velocity = new Vector2(move * maxSpeed, rBody.velocity.y);
        }

        if (move > 0 && !facingRight)
            Flip();
        else if (move < 0 && facingRight)
            Flip();


        if (grounded && Input.GetButtonDown("Jump")) {
            //anim.SetBool("Ground", false);
            //jump();
            StartCoroutine(Jump());
        }

        //Adds additional height to jumps.
        //if (Input.GetButton("Jump") && rBody.velocity.y > 0) {
        //    if (jumpHeld < fullJumpTime) {
        //        jumpHeld += Time.deltaTime;
        //        //The various kinds of extended jumps
        //        //rBody.velocity += new Vector2(0f, maxJump * Time.deltaTime);
        //        //rBody.AddForce(new Vector2(0, fullJumpTime - jumpHeld) * extendJump, ForceMode2D.Force);
        //        rBody.AddForce(new Vector2(0, fullJumpTime - jumpHeld) * extendJump, ForceMode2D.Impulse);
        //    }
        //}
        //if (Input.GetButtonUp("Jump")) {
        //    jumpHeld = 0f;
        //}
    }

    IEnumerator Jump() {
        anim.SetBool("Ground", false);
        rBody.AddForce(new Vector2(0, minJump), ForceMode2D.Impulse);
        while (Input.GetButton("Jump") && jumpHeld < fullJumpTime) {
            jumpHeld += Time.deltaTime;
            //The various kinds of extended jumps
            //rBody.velocity += new Vector2(0f, maxJump * Time.deltaTime);
            //rBody.AddForce(new Vector2(0, fullJumpTime - jumpHeld) * extendJump, ForceMode2D.Force);
            rBody.AddForce(new Vector2(0, fullJumpTime - jumpHeld) * extendJump, ForceMode2D.Impulse);
            yield return null;
        }
        jumpHeld = 0f;
    }

    void jump()
    {
        float jumping = minJump + jumpHeld;
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
